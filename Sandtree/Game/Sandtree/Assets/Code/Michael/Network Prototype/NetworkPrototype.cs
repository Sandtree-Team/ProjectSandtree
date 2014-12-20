using System;
using UnityEngine;
using System.Collections;
//Written by Michael Bethke
public class NetworkPrototype : MonoBehaviour
{
	
	public bool externalConnection = false;
	public string publicIPAddress = "71.63.239.44";
	string externalIP;
	
	public Transform networkPlayerPrefab;

	void Start ()
	{
		
		if ( externalConnection == true )
		{
			
			externalIP = publicIPAddress;
			TryConnect ();
		} else {
			
			TryHost ();
		}
	}
	
	
	public void TryHost ()
	{
		
		if ( BeginHost () == true )
		{
			
			InstantiateNetworkPlayer ();
		}
	}
	
	
	protected bool BeginHost ()
	{
		
		UnityEngine.Debug.Log ( "NAT: " + Network.HavePublicAddress() );
		
		/*if ( Network.HavePublicAddress () == false )
		{
			
			UnityEngine.Debug.LogWarning ( "Unable to determin public address. NAT returned false." );
			return false;
		}*/

		Network.InitializeServer ( 2, 23120, !Network.HavePublicAddress() );
		
		return true;
	}
	
	
	void OnServerInitialized ()
	{
		
		UnityEngine.Debug.Log ( "Successfully hosting server." );
	}
	
	
	void OnPlayerConnected ( NetworkPlayer connectedPlayer )
	{
		
		UnityEngine.Debug.Log ( connectedPlayer.ipAddress + " connected." );
	}
	
	
	void OnPlayerDisconnected ( NetworkPlayer disconnectedPlayer )
	{
		
		UnityEngine.Debug.Log ( disconnectedPlayer.ipAddress + " disconnected." );
		//Network.RemoveRPCs ( disconnectedPlayer );
		//Network.DestroyPlayerObjects ( disconnectedPlayer );
	}
	
	
	public void TryConnect ()
	{
		
		if ( BeginConnect () == true )
		{
			
			InstantiateNetworkPlayer ();
		}
	}
	
	
	protected bool BeginConnect ()
	{
		
		try
		{
			
			if ( externalConnection == true )
			{
				
				Network.Connect ( externalIP, 23120);
			}
		} catch ( Exception connectionError )
		{
			
			UnityEngine.Debug.LogError ( "Unable to connect to server! " + connectionError );
			return false;
		}
		
		return true;
	}
	
	
	void OnConnectedToServer ()
	{
			
		UnityEngine.Debug.Log ( "Successfully connected." );
	}
	
	
	void OnFailedToConnect ( NetworkConnectionError connectionError )
	{
		
		UnityEngine.Debug.Log ( "Unable to connect. " + connectionError );
	}
	
	
	void InstantiateNetworkPlayer ()
	{
		
		Instantiate ( networkPlayerPrefab, new Vector3 ( -10, 2, -3 ), Quaternion.identity );
	}
}
