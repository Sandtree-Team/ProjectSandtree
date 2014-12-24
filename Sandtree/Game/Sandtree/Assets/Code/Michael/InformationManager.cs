using System;
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


public class Meta
{
	
	public string version;
	
	public Meta () : this ( "0" ) {}
	public Meta ( string _version )
	{
		
		this.version = _version;
	}
}


[XmlRoot ( "Audio" )]
public class Audio
{
	
	[XmlElement ( "Meta" )]
	public Meta meta = new Meta ();
}


[XmlRoot ( "Equipment" )]
public class Equipment
{
	
	[XmlElement ( "Meta" )]
	public Meta meta = new Meta ();
	
	[XmlElement ( "Helmets" )]
	public Helmets helmets = new Helmets ();
}


public class Helmets
{
	
	[XmlElement ( "Helmet" )]
	public List<Helmet> helmet = new List<Helmet> ();
}


public class Helmet
{
	
	public string identifier;
	public string name;
	public string armourRating;
	
	public Helmet () : this ( "null", "null", "null" ) {}
	public Helmet ( string _identifier, string _name, string _armourRating )
	{
		
		this.identifier = _identifier;
		this.name = _name;
		this.armourRating = _armourRating;
	}
}


[XmlRoot ( "Localizations" )]
public class Localizations
{
	
	[XmlElement ( "Meta" )]
	public Meta meta = new Meta ();
	
	
}


[XmlRoot ( "Models" )]
public class Models
{
	
	[XmlElement ( "Meta" )]
	public Meta meta = new Meta ();
	
	
}


[XmlRoot ( "Textures" )]
public class Textures
{
	
	[XmlElement ( "Meta" )]
	public Meta meta = new Meta ();
	
	
}


[XmlRoot ( "Videos" )]
public class Videos
{
	
	[XmlElement ( "Meta" )]
	public Meta meta = new Meta ();
	
	
}


public class InformationManager : MonoBehaviour
{
	
	public string version;
	internal Preferences preferences = new Preferences ();
	internal SavedGames savedGames = new SavedGames ();
	
	internal AssetMasterlist assetMasterlist = new AssetMasterlist ();
	
	internal Audio audioCatalogue = new Audio ();
	internal Equipment equipmentCatalogue = new Equipment ();
	internal Localizations localizationsCatalogue = new Localizations ();
	internal Models modelsCatalogue = new Models ();
	internal Textures texturesCatalogue = new Textures ();
	internal Videos videosCatalogue = new Videos ();
	
	
	
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
