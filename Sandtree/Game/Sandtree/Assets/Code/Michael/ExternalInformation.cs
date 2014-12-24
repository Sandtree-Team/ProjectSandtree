using System;
using System.IO;
using System.Net;
using UnityEngine;
using System.Text;
using System.Linq;
using System.Threading;
using System.Collections;
using System.Xml.Serialization;
//Written by Michael Bethke
public class ExternalInformation : MonoBehaviour
{
	
	InformationManager informationManager;

	string developerPath;
	string sandtreePath;
	string supportPath;
	string savedGamesPath;
	string assetsPath;
	string localizationPath;
	
	string[] audioPaths = new string [1];
	string[] modelsPaths = new string [23];
	string[] texturesPaths = new string [1];
	string[] videosPaths = new string [1];
	

	void Start ()
	{
		
		informationManager = /*GameObject.FindGameObjectWithTag ( "InformationManager" )*/gameObject.GetComponent<InformationManager> ();
	
		if ( Environment.OSVersion.ToString ().Substring ( 0, 4 ) == "Unix" )
		{

			developerPath = Path.DirectorySeparatorChar + "Users" + Path.DirectorySeparatorChar  + Environment.UserName + Path.DirectorySeparatorChar + "Library" + Path.DirectorySeparatorChar  + "Application Support" + Path.DirectorySeparatorChar + "Nick and Michael" + Path.DirectorySeparatorChar;
		} else
		{

			developerPath = Environment.GetFolderPath ( Environment.SpecialFolder.CommonApplicationData ) + Path.DirectorySeparatorChar  + "2Cat Studios" + Path.DirectorySeparatorChar;
		}
		
		sandtreePath = developerPath + "ProjectSandtree";
		supportPath = sandtreePath + Path.DirectorySeparatorChar + "Support";
		savedGamesPath = sandtreePath + Path.DirectorySeparatorChar + "Saved Games";

		if ( Directory.Exists ( supportPath ) == false )
		{
			
			Directory.CreateDirectory ( supportPath );
		}
		
#region preferences 
		if ( ReadPreferences () != true )
		{
			
			if ( WritePreferences ( true ) != true )
			{
				
				UnityEngine.Debug.Log ( "Unable to Write Preferences!" );
			} else {
				
				if ( ReadPreferences () != true )
				{
					
					UnityEngine.Debug.LogError ( "Unable to R+WR Preferences" );
				} else { UnityEngine.Debug.Log ( "New Preferences File Created" ); }
			}
		}
		
#endregion
#region savedGames 

		if ( Directory.Exists ( savedGamesPath ) == false )
		{
			
			Directory.CreateDirectory ( savedGamesPath );
		}
		
		if ( ReadSavedGames () != true )
		{
			
			if ( WriteSavedGames ( true ) != true )
			{
				
				UnityEngine.Debug.Log ( "Unable to Write SavedGames!" );
			} else {
				
				if ( ReadSavedGames () != true )
				{
					
					UnityEngine.Debug.LogError ( "Unable to R+WR SavedGames" );
				} else { UnityEngine.Debug.Log ( "New SavedGames File Created" ); }
			}
		}
		
#endregion
#region assets 
		
		//Thread internetConnectionsThread = new Thread (() => InternetConnections ( preferences.checkForUpdate, preferences.enableOMB ));
		//internetConnectionsThread.Start ();
		
		if ( LoadDefaultAssets () == false )
		{
			
			UnityEngine.Debug.LogError ( "Unable to load default assets. This needs to force a crash." );
			Application.Quit ();
		}
		
		if ( CreateAssetMasterlist () == false )
		{
			
			UnityEngine.Debug.LogError ( "This should not have happened. Error calling CreateAssetMasterlist!" );
		}
		
		assetsPath = sandtreePath + Path.DirectorySeparatorChar + "Assets";
		
		if ( Directory.Exists ( assetsPath ) == false )
		{
			
			Directory.CreateDirectory ( assetsPath );
		}
		
		localizationPath = assetsPath + Path.DirectorySeparatorChar + "Localizations";
		
		if ( Directory.Exists ( localizationPath ) == false )
		{
			
			Directory.CreateDirectory ( localizationPath );
		}
		
		/***************************************************************************/
/**/	audioPaths [0] = assetsPath + Path.DirectorySeparatorChar + "Audio";			/**/
/**/	texturesPaths [0] = assetsPath + Path.DirectorySeparatorChar + "Textures";		/**/
/**/	videosPaths [0] = assetsPath + Path.DirectorySeparatorChar + "Video";			/**/
		/***************************************************************************/
		
		/*
		ModelsPaths
		
		[00] Models
			[01] Models/Character
				[02] Models/Character/Humanoid
					[03] Models/Character/Humanoid/Abdomen
					[04] Models/Character/Humanoid/BicepL
					[05] Models/Character/Humanoid/BicepR
					[06] Models/Character/Humanoid/Chest
					[07] Models/Character/Humanoid/FootL
					[08] Models/Character/Humanoid/FootR
					[09] Models/Character/Humanoid/ForearmL
					[10] Models/Character/Humanoid/ForearmR
					[11] Models/Chatacter/Humanoid/HandL
					[12] Models/Chatacter/Humanoid/HandR
					[13] Models/Character/Humanoid/Head
					[14] Models/Character/Humanoid/KneeL
					[15] Models/Character/Humanoid/KneeR
					[16] Models/Character/Humanoid/Neck
					[17] Models/Character/Humanoid/ShinL
					[18] Models/Character/Humanoid/ShinR
					[19] Models/Character/Humanoid/ThighL
					[20] Models/Character/Humanoid/ThighR
					[21] Models/Character/Humanoid/Waist
				[22] Models/Character/NonHumanoid
		*/
		
		modelsPaths [0] = assetsPath + Path.DirectorySeparatorChar + "Models";
		modelsPaths [1] = modelsPaths [0] + Path.DirectorySeparatorChar + "Character";
		modelsPaths [2] = modelsPaths [1] + Path.DirectorySeparatorChar + "Humanoid";
		modelsPaths [3] = modelsPaths [2] + Path.DirectorySeparatorChar + "Abdomen";
		modelsPaths [4] = modelsPaths [2] + Path.DirectorySeparatorChar + "BicepL";
		modelsPaths [5] = modelsPaths [2] + Path.DirectorySeparatorChar + "BicepR";
		modelsPaths [6] = modelsPaths [2] + Path.DirectorySeparatorChar + "Chest";
		modelsPaths [7] = modelsPaths [2] + Path.DirectorySeparatorChar + "FootL";
		modelsPaths [8] = modelsPaths [2] + Path.DirectorySeparatorChar + "FootR";
		modelsPaths [9] = modelsPaths [2] + Path.DirectorySeparatorChar + "ForearmL";
		modelsPaths [10] = modelsPaths [2] + Path.DirectorySeparatorChar + "ForearmR";
		modelsPaths [11] = modelsPaths [2] + Path.DirectorySeparatorChar + "HandL";
		modelsPaths [12] = modelsPaths [2] + Path.DirectorySeparatorChar + "HandR";
		modelsPaths [13] = modelsPaths [2] + Path.DirectorySeparatorChar + "Head";
		modelsPaths [14] = modelsPaths [2] + Path.DirectorySeparatorChar + "KneeL";
		modelsPaths [15] = modelsPaths [2] + Path.DirectorySeparatorChar + "KneeR";
		modelsPaths [16] = modelsPaths [2] + Path.DirectorySeparatorChar + "Neck";
		modelsPaths [17] = modelsPaths [2] + Path.DirectorySeparatorChar + "ShinL";
		modelsPaths [18] = modelsPaths [2] + Path.DirectorySeparatorChar + "ShinR";
		modelsPaths [19] = modelsPaths [2] + Path.DirectorySeparatorChar + "ThighL";
		modelsPaths [20] = modelsPaths [2] + Path.DirectorySeparatorChar + "ThighR";
		modelsPaths [21] = modelsPaths [2] + Path.DirectorySeparatorChar + "Waist";
		modelsPaths [22] = modelsPaths [1] + Path.DirectorySeparatorChar + "NonHumanoid";
		
		int modelsPathsIndex = 0;
		while ( modelsPathsIndex < modelsPaths.Length )
		{
			
			//UnityEngine.Debug.Log ( modelsPaths [modelsPathsIndex] );
			modelsPathsIndex += 1;
		}
		
		if ( Directory.Exists ( supportPath + Path.DirectorySeparatorChar + "AssetCatalogues" ) == false )
		{
			
			Directory.CreateDirectory ( supportPath + Path.DirectorySeparatorChar + "AssetCatalogues" );
		}
		
		ReadCatalogues ();
		
		if ( MergeAssetLists () == false )
		{
			
			UnityEngine.Debug.LogError ( "Unable to merge lists! This should force shutdown." );
		}
		
		//UnityEngine.Debug.Log ( "Begin Loading OBJ" );
		
		/*try
		{
			
			ObjImporter objImporter = new ObjImporter ();
			GameObject tempGameObject = new GameObject ();
			tempGameObject.AddComponent <MeshFilter> ();
			tempGameObject.AddComponent <MeshRenderer> ();
			
			Material tempMaterial = new Material ( Shader.Find ( " Diffuse" ));
			
			tempGameObject.GetComponent <MeshFilter> ().mesh = objImporter.ImportFile ( Environment.GetFolderPath ( Environment.SpecialFolder.Desktop ) + Path.DirectorySeparatorChar + "FishHelmet1.obj" );
			tempGameObject.GetComponent <MeshRenderer> ().material = tempMaterial;
		} catch ( Exception error )
		{
				
			UnityEngine.Debug.Log ( "Error in importing OBJ, " + error );
			
			//Attempt to download broken asset
		}*/
		
#endregion
		
	}
	
	
	bool LoadDefaultAssets ()
	{
		
		try
		{
		
			using ( StreamReader streamReader = new StreamReader ( Application.streamingAssetsPath + Path.DirectorySeparatorChar + "Audio" + Path.DirectorySeparatorChar + "Audio.xml" ))
			{
	    	
				string xml = streamReader.ReadToEnd ();
				informationManager.audioCatalogue = xml.DeserializeXml<Audio>();
			}
			
			using ( StreamReader streamReader = new StreamReader ( Application.streamingAssetsPath + Path.DirectorySeparatorChar + "Equipment" + Path.DirectorySeparatorChar + "Equipment.xml" ))
			{
	    	
				string xml = streamReader.ReadToEnd ();
				informationManager.equipmentCatalogue = xml.DeserializeXml<Equipment>();
			}
			
			using ( StreamReader streamReader = new StreamReader ( Application.streamingAssetsPath + Path.DirectorySeparatorChar + "Localizations" + Path.DirectorySeparatorChar + "Localizations.xml" ))
			{
	    	
				string xml = streamReader.ReadToEnd ();
				informationManager.localizationsCatalogue = xml.DeserializeXml<Localizations>();
			}
			
			using ( StreamReader streamReader = new StreamReader ( Application.streamingAssetsPath + Path.DirectorySeparatorChar + "Models" + Path.DirectorySeparatorChar + "Models.xml" ))
			{
	    	
				string xml = streamReader.ReadToEnd ();
				informationManager.modelsCatalogue = xml.DeserializeXml<Models>();
			}
			
			using ( StreamReader streamReader = new StreamReader ( Application.streamingAssetsPath + Path.DirectorySeparatorChar + "Textures" + Path.DirectorySeparatorChar + "Textures.xml" ))
			{
	    	
				string xml = streamReader.ReadToEnd ();
				informationManager.texturesCatalogue = xml.DeserializeXml<Textures>();
			}
			
			using ( StreamReader streamReader = new StreamReader ( Application.streamingAssetsPath + Path.DirectorySeparatorChar + "Videos" + Path.DirectorySeparatorChar + "Videos.xml" ))
			{
	    	
				string xml = streamReader.ReadToEnd ();
				informationManager.videosCatalogue = xml.DeserializeXml<Videos>();
			}
		} catch ( Exception error )
		{
			
			UnityEngine.Debug.LogError ( "Unable to read/deserialize default assets! " + error );
			return false;
		}
		
		return true;
	}
	
	
	bool CreateAssetMasterlist ()
	{
		
		if ( File.Exists ( supportPath + Path.DirectorySeparatorChar + "AssetMasterlist.xml" ))
		{
			
			File.Delete ( supportPath + Path.DirectorySeparatorChar + "AssetMasterlist.xml" );
		}
		
		try
		{
			
			using ( WebClient client = new WebClient ())
			{
			
				client.DownloadFile ( new Uri ( "http://2catstudios.github.io/ProjectSandtree/AssetMasterlist.xml" ), supportPath + Path.DirectorySeparatorChar + "AssetMasterlist.xml" );
			}
			
			using ( StreamReader streamReader = new System.IO.StreamReader ( supportPath + Path.DirectorySeparatorChar + "AssetMasterlist.xml" ))
			{
				
				string xml = streamReader.ReadToEnd();
				informationManager.assetMasterlist = xml.DeserializeXml<AssetMasterlist>();
			}
			
			return true;
		} catch
		{
			
			UnityEngine.Debug.Log ( "Unable to Download AssetMasterlist. FOREACH XML IN ASSETCATEGORIES" );
			//Populate XML based on available files
			//Foreach file in Support/AssetCatalogues
			//return true ?
		}
		
		return false;
	}
	
	
	/*
	Catalogues to Read|
		Audio
		Equipment		*
		Localizations
		Models
		Textures
		Videos
	*/
	
	
	//http://2catstudios.github.io/ProjectSandtree/Assets/Equipment/<MODEL>
	
	
	bool ReadCatalogues ()
	{
		
		//Make required assetsList
		
		/*int requiredCatalogueIndex = 0;
		while ( requiredCatalogueIndex < informationManager.requiredCatalogues.Length )
		{
			
			if ( File.Exists ( supportPath + Path.DirectorySeparatorChar + "AssetCatalogues" + Path.DirectorySeparatorChar + informationManager.requiredCatalogues[requiredCatalogueIndex].name + ".xml" ) == false )
			{
				
				DownloadCatalogues ( informationManager.requiredCatalogues[requiredCatalogueIndex].name + ".xml" );
			} else {
				
				try {
			
					using ( StreamReader streamReader = new StreamReader ( supportPath + Path.DirectorySeparatorChar + "AssetCatalogues" + Path.DirectorySeparatorChar + informationManager.requiredCatalogues[requiredCatalogueIndex].name + ".xml" ))
					{
				
						string xml = streamReader.ReadToEnd ();
						//informationManager.equipment = xml.DeserializeXml<informationManager.requiredCatalogues[requiredCatalogueIndex].type>();
			
						UnityEngine.Debug.Log ( "Deserialized" );
					}
				} catch ( Exception e ) {
			
					UnityEngine.Debug.LogError ( "ERROR: " + e );
					return false;
				}
			}
			
			requiredCatalogueIndex += 1;
		}*/
		
		return true;
	}
	
	
	bool VerifyCatalogues ()
	{
		
		return true;
	}
	
	
	bool DownloadCatalogues ( string catalogueToDownload )
	{
		
		UnityEngine.Debug.Log ( "Attempting Download for " + catalogueToDownload );
		
		Uri url = new Uri ( "http://2catstudios.github.io/ProjectSandtree/AssetCatalogues/" + catalogueToDownload );
		
		try
		{
			
			HttpWebRequest request = WebRequest.Create ( url ) as HttpWebRequest;
			request.Method = "HEAD";
			
			HttpWebResponse response = request.GetResponse() as HttpWebResponse;
			
			if ( response.StatusCode == HttpStatusCode.OK )
			{
				
				try
				{
				
					using ( WebClient client = new WebClient ())
					{
					
						client.DownloadFile ( url, supportPath + Path.DirectorySeparatorChar + "AssetCatalogues" + Path.DirectorySeparatorChar + catalogueToDownload );
					}
					
					UnityEngine.Debug.Log ( "Successfully downloaded " + catalogueToDownload );
					
				} catch ( Exception downloadError )
				{
			
					UnityEngine.Debug.LogError ( "Error Downloading from " + url + " : " + downloadError );
					Application.Quit ();
				}
			}
		} catch ( Exception httpError )
		{

			UnityEngine.Debug.LogError ( httpError );
		}
		
		return true;
	}
	
	
	/*bool DownloadEquipmentMasterlists ()
	{
		
		UnityEngine.Debug.Log ( "Downloading Equipment Masterlist" );

		try {
			
			using ( StreamReader streamReader = new StreamReader ( WebRequest.Create ( URL ).GetResponse ().GetResponseStream ()))
			{
				
				string xml = streamReader.ReadToEnd ();
			
				UnityEngine.Debug.Log( "Downloaded and Read into Memory" );
			
				informationManager.helmets = xml.DeserializeXml<Helmets>();
			
				UnityEngine.Debug.Log ( "Deserialized" );
			}
		} catch ( Exception e ) {
			
			UnityEngine.Debug.LogError ( "ERROR: " + e );
			return false;
		}
		
		return true;
		
		//Thread downloadMissingEquipmentThread = new Thread ( new ThreadStart ( DownloadMissingEquipment ));
		//downloadMissingEquipmentThread.Start ();
	}*/
	
	
	bool MergeAssetLists ()
	{
		
		//list = list1.Concat(list2).ToList();
		
		return true;
	}
	
	
	bool ReadPreferences ()
	{
		
		try {
			
			StreamReader prefsReader = new System.IO.StreamReader ( supportPath + Path.DirectorySeparatorChar + "Preferences.xml" );
			string prefsXML = prefsReader.ReadToEnd();
			prefsReader.Close();
			
			informationManager.preferences = prefsXML.DeserializeXml<Preferences> ();
			
			if ( informationManager.PrefsUpToDate () != true )
			{
				
				return false;
			}
		} catch ( Exception error )
		{
			
			UnityEngine.Debug.LogWarning ( "Unable to Read Preferences, " + error );
			return false;
		}
		return true;
	}
	
	
	bool WritePreferences ( bool rewrite = false )
	{
		
		if ( rewrite == true )
		{
			
			UnityEngine.Debug.Log ( "Rewriting Preferences" );
			if ( informationManager.NewPreferences () != true )
			{
				
				return false;
			}
		}
		
		try {
			
			XmlSerializer prefsSerializer = new XmlSerializer ( informationManager.preferences.GetType ());
			StreamWriter prefsWriter = new StreamWriter ( supportPath + Path.DirectorySeparatorChar + "Preferences.xml" );
			prefsSerializer.Serialize ( prefsWriter.BaseStream, informationManager.preferences );
			prefsWriter.Close ();
		} catch ( Exception error ) {
			
			UnityEngine.Debug.LogError ( "Unable to Write Preferences, " + error );
			return false;
		}
		return true;
	}


	bool ReadSavedGames ()
	{
	
		try {
			
			StreamReader savesReader = new System.IO.StreamReader ( savedGamesPath + Path.DirectorySeparatorChar + "SavedGames.xml" );
			string savesXML = savesReader.ReadToEnd();
			savesReader.Close();
			
			informationManager.savedGames = savesXML.DeserializeXml<SavedGames> ();
		} catch ( Exception error )
		{
			
			UnityEngine.Debug.LogWarning ( "Unable to Read SavedGames, " + error );
			return false;
		}
		return true;
	}
	
	
	bool WriteSavedGames ( bool rewrite = false )
	{
		
		if ( rewrite == true )
		{
			
			UnityEngine.Debug.Log ( "Rewriting SavedGames" );
			if ( informationManager.NewSavedGames () != true )
			{
				
				return false;
			}
		}
		
		try {
			
			XmlSerializer savedGamesSerializer = new XmlSerializer ( informationManager.savedGames.GetType ());
			StreamWriter savedGamesWriter = new StreamWriter ( savedGamesPath + Path.DirectorySeparatorChar + "SavedGames.xml" );
			savedGamesSerializer.Serialize ( savedGamesWriter.BaseStream, informationManager.savedGames );
			savedGamesWriter.Close ();
		} catch ( Exception error ) {
			
			UnityEngine.Debug.LogError ( "Unable to Write SavedGames, " + error );
			return false;
		}
		return true;
	}
}


public static class XMLSupport 
{
	
	public static T DeserializeXml<T> (this string xml) where T : class
	{
		
		if( xml != null )
		{
			
			var s = new XmlSerializer ( typeof ( T ) );
			using ( var m = new MemoryStream ( Encoding.UTF8.GetBytes ( xml )))
			{
				
				return ( T ) s.Deserialize ( m );
			}
		}
	
		UnityEngine.Debug.LogError ( "A wild error has apperaed!" );
		return null;
	}
}