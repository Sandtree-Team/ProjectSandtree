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
	
	[XmlElement ( "Head" )]
	public Head head = new Head ();
	
	[XmlElement ( "Torso" )]
	public Torso torso = new Torso ();
	
	[XmlElement ( "Forearm" )]
	public Forearm forearm = new Forearm ();
	
	[XmlElement ( "Shin" )]
	public Shin shin = new Shin ();
	
	[XmlElement ( "Weapons" )]
	public Weapons weapons = new Weapons ();
	
	[XmlElement ( "Shields" )]
	public Shields shields = new Shields ();
}


public class Head
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


public class Torso
{
	
	[XmlElement ( "ChestArmour" )]
	public List<ChestArmour> chestArmour = new List<ChestArmour> ();
}


public class ChestArmour
{
	
	public string identifier;
	public string name;
	public string armourRating;
	
	public ChestArmour () : this ( "null", "null", "null" ) {}
	public ChestArmour ( string _identifier, string _name, string _armourRating )
	{
		
		this.identifier = _identifier;
		this.name = _name;
		this.armourRating = _armourRating;
	}
}


public class Forearm
{
	
	[XmlElement ( "Gauntlet" )]
	public List<Gauntlet> gauntlet = new List<Gauntlet> ();
}


public class Gauntlet
{
	
	public string identifier;
	public string name;
	public string armourRating;
	
	public Gauntlet () : this ( "null", "null", "null" ) {}
	public Gauntlet ( string _identifier, string _name, string _armourRating )
	{
		
		this.identifier = _identifier;
		this.name = _name;
		this.armourRating = _armourRating;
	}
}


public class Shin
{
	
	[XmlElement ( "Greave" )]
	public List<Greave> shinArmour = new List<Greave> ();
}


public class Greave
{
	
	public string identifier;
	public string name;
	public string armourRating;
	
	public Greave () : this ( "null", "null", "null" ) {}
	public Greave ( string _identifier, string _name, string _armourRating )
	{
		
		this.identifier = _identifier;
		this.name = _name;
		this.armourRating = _armourRating;
	}
}


public class Weapons
{
	
	[XmlElement ( "Sword" )]
	public List<Sword> sword = new List<Sword> ();
}


public class Sword
{
	
	public string identifier;
	public string name;
	public string baseDamage;
	
	public Sword () : this ( "null", "null", "null" ) {}
	public Sword ( string _identifier, string _name, string _baseDamage )
	{
		
		this.identifier = _identifier;
		this.name = _name;
		this.baseDamage = _baseDamage;
	}
}


public class Shields
{
	
	[XmlElement ( "Shield" )]
	public List<Shield> shield = new List<Shield> ();
}


public class Shield
{
	
	public string identifier;
	public string name;
	public string baseDefence;
	
	public Shield () : this ( "null", "null", "null" ) {}
	public Shield ( string _identifier, string _name, string _baseDefence )
	{
		
		this.identifier = _identifier;
		this.name = _name;
		this.baseDefence = _baseDefence;
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
