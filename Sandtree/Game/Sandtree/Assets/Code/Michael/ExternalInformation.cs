using System;
using System.IO;
using UnityEngine;
using System.Text;
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
		}// else { UnityEngine.Debug.Log ( "Read Preferences Successfully" ); }
		
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
		}// else { UnityEngine.Debug.Log ( "Read SavedGames Successfully" ); }
#endregion
#region assets 
		
		//assetsPaths[0] = sandtreePath + Path.DirectorySeparatorChar + "Assets" + Path.DirectorySeparatorChar;
		assetsPath = sandtreePath + Path.DirectorySeparatorChar + "Assets"/* + Path.DirectorySeparatorChar*/;
		
		if ( Directory.Exists ( assetsPath ) == false )
		{
			
			Directory.CreateDirectory ( assetsPath );
		}
		
		audioPaths [0] = assetsPath + Path.DirectorySeparatorChar + "Audio";
		
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
			
			UnityEngine.Debug.Log ( modelsPaths [modelsPathsIndex] );
			modelsPathsIndex += 1;
		}
		
		//string audioPath = assetsPath + Path.DirectorySeparatorChar + "Audio";
		
		//string modelsPath = assetsPath + Path.DirectorySeparatorChar + "Models";
			//string characterModels = modelsPath + Path.DirectorySeparatorChar + "Character";
				//string helmetModels = modelsPath + Path.DirectorySeparatorChar + "Helmets";
		
		/*string texturesPath = assetsPath + Path.DirectorySeparatorChar + "Textures";
		
		if ( Directory.Exists ( audioPath ) == false )
		{
			
			Directory.CreateDirectory ( audioPath );
		}
		
		if ( Directory.Exists ( modelsPath ) == false )
		{
			
			Directory.CreateDirectory ( modelsPath );
		}
		
		if ( Directory.Exists ( texturesPath ) == false )
		{
			
			Directory.CreateDirectory ( texturesPath );
		}*/
		
		if ( ReadEquipment () != true )
		{
			
			
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
	
	
	bool ReadEquipment ()
	{
		
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