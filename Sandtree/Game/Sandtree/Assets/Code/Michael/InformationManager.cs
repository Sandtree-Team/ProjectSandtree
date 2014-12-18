using System.Xml;
using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.Collections.Generic;
//Written by Michael Bethke
[XmlRoot ( "Preferences" )]
public class Preferences
{
	
	[XmlElement ( "Version" )]
	public string version;

	[XmlElement ( "LastPlayerID" )]
	public string lastPlayerID;
}


[XmlRoot ( "SavedGames" )]
public class SavedGames
{
	
	[XmlElement ( "SavedGame" )]
	public List<SavedGame> all;
	
	
	public SavedGames ()
	{
		
		all = new List<SavedGame> ();
	}
}


public class SavedGame
{
	
	[XmlAttribute ( "usingVersion" )]
	public string usingVersion;
	
	//[XmlElement ( "PlayerID" )]
	public string playerID;
	
	//[XmlIgnore]
	public SavedGame () : this ( "0", "0" ) {}
	public SavedGame ( string _usingVersion, string _playerID )
	{
		
		this.usingVersion = _usingVersion;
		this.playerID = _playerID;
	}
}


[XmlRoot ( "AssetMasterlist" )]
public class AssetMasterlist
{
	
	[XmlElement ( "AssetCatalogue" )]
	public List<AssetCatalogue> catalogues;
}


public class AssetCatalogue
{
	
	public string name;
}


[XmlRoot ( "Helmets" )]
public class Helmets
{
	
	[XmlElement ( "Helmet" )]
	public List<Helmet> helmets;
}


public class Helmet
{
	
	public string identifier;
	public string name;
	public string armourRating;
	
	string modelPath;
}


public class InformationManager : MonoBehaviour
{
	
	public string version;
	internal Preferences preferences = new Preferences ();
	internal SavedGames savedGames = new SavedGames ();
	
	internal AssetMasterlist assetMasterlist = new AssetMasterlist ();
	internal Helmets helmets = new Helmets ();
	
	
	internal bool NewPreferences ()
	{
		
		preferences = new Preferences ();
		
		preferences.version = version;
		preferences.lastPlayerID = "lastPlayerID";
		
		return true;
	}
	
	
	internal bool PrefsUpToDate ()
	{
		
		if ( preferences.version != version )
		{
			
			UnityEngine.Debug.Log ( "Preferences not up to date" );
			return false;
		}
		
		return true;
	}
	
	
	internal bool NewSavedGames ()
	{
		
		savedGames = new SavedGames ();
		
		return true;
	}
}
