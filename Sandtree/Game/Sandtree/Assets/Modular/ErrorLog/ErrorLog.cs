using System;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//Written by Michael Bethke
[RequireComponent (typeof (ErrorUI))]
public class ErrorLog : MonoBehaviour
{
	
	ErrorUI userInterface;
	
	public string projectTitle = "New Project";
	
	public bool startupWriteToScreen = true;
	public bool startupWriteToDisk = true;
	
	bool debugLogActive = false;
	bool writeLogToScreen = false;
	bool writeLogToDisk = false;
	public string writePath = null;
	
	internal List<String> log = new List<String> ();
	

	void Start ()
	{
		
		userInterface = gameObject.GetComponent<ErrorUI>();
		
		writeLogToScreen = startupWriteToScreen;
		writeLogToDisk = startupWriteToDisk;
		//writePath = ; // In the case that you don't need the path to be public, make the variable a private string, and uncomment this line.
	
		if ( writeLogToScreen == true || writeLogToDisk == true )
		{
			
			debugLogActive = true;
		} else {
			
			debugLogActive = false;
		}
	
		if ( debugLogActive == true )
		{
			
			if ( writeLogToScreen == true )
			{
				
				userInterface.enabled = true;
			} else {
				
				userInterface.enabled = false;
			}
			
			log.Add ( "Error Log Active\n" ); // Comment out this line in any kind of public build.
			
			if ( writeLogToDisk == true )
			{
				
				string writingWarning = "Writing to disk";
				
				if ( String.IsNullOrEmpty ( writePath.Trim ()) == true )
				{
					
					writingWarning = writingWarning + ", no destination given! Writing to default directory: User > Desktop.";
					writePath = Environment.GetFolderPath ( Environment.SpecialFolder.Desktop );
				}
				writePath = writePath + Path.DirectorySeparatorChar + projectTitle + " ErrorLog" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".txt";
				
				log.Add ( writingWarning );
			}
		} else {
			
			UnityEngine.Debug.LogWarning ( "ErrorLog disabled." );
		}
	}
	
	
	public void Post ( string logString )
	{
		
		if ( AddMessage ( logString + " (Manual)\n" ) == false )
		{
			
			UnityEngine.Debug.LogError ( "Unable to AddMessage from Post, " + logString );
		}
	}
	
	
	void OnEnable ()
	{
		
		Application.RegisterLogCallback ( HandleLog );
	}
	
	
	void OnDisable ()
	{
		
		Application.RegisterLogCallback ( null );
	}
	
	
	void HandleLog ( string logString, string stackTrace, LogType type )
	{
		
		UnityEngine.Debug.Log ( "MESSAGE" );
		
		if ( AddMessage ( logString + " (" + type + ") " + stackTrace ) == false )
		{
			
			UnityEngine.Debug.LogError ( "Unable to AddMessage from CallBack, " + logString );
		}
	}
	
	
	bool AddMessage ( string messageToAdd )
	{
		
		try
		{
			
			messageToAdd = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + " - " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "." + DateTime.Now.Millisecond + " || " + messageToAdd;
			log.Add ( messageToAdd );
			
			if ( writeLogToScreen == true )
			{
				
				userInterface.debugScrollPosition.y = Mathf.Infinity;
			}
			
			if ( writeLogToDisk == true )
			{
				using ( StreamWriter streamWriter = File.AppendText ( writePath )) 
				{
					
					streamWriter.WriteLine ( messageToAdd );
				}
			}
		} catch ( Exception e ) {
			
			UnityEngine.Debug.LogError ( e );
			return false;
		}
		
		return true;
	}
}