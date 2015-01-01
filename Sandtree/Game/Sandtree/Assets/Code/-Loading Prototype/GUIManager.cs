using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour
{
	
	public Slider loadingBar;
	public Text loadingMessage;
	
	string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	System.Random random = new System.Random ();
	
	
	void Start ()
	{
		
		InvokeRepeating ( "TEMPVoid", 2, 1 );
	}
	
	
	void TEMPVoid ()
	{
		
		UpdateUser ( UnityEngine.Random.Range ( 0.01f, 0.12f ), new string ( Enumerable.Repeat ( chars, UnityEngine.Random.Range ( 3, 36 )).Select ( s => s[random.Next ( s.Length )]).ToArray()));
	}
	

	void UpdateUser ( float percentage, string message )
	{
		
		loadingMessage.text = "Loading: " + message;
		loadingBar.value = loadingBar.value + percentage;
		
		if ( loadingBar.value == 1 )
		{
			
			CancelInvoke ( "TEMPVoid" );
			
			loadingMessage.text = "Startup Completed";
			loadingBar.value = 1;
		}
	}
}
