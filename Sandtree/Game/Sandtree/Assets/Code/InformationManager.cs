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
	
	/*
		Save player equipment
	*/
	
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
	
	[XmlElement ( "Abdomen" )]
	public Abdomen abdomen = new Abdomen ();
	
	[XmlElement ( "Biceps" )]
	public Biceps biceps = new Biceps ();
	
	[XmlElement ( "Chest" )]
	public Chest chest = new Chest ();
	
	[XmlElement ( "Feet" )]
	public Feet feet = new Feet ();
	
	[XmlElement ( "Forearms" )]
	public Forearms forearms = new Forearms ();
	
	[XmlElement ( "Hands" )]
	public Hands hands = new Hands ();
	
	[XmlElement ( "Head" )]
	public Head head = new Head ();
	
	[XmlElement ( "Neck" )]
	public Neck neck = new Neck ();
	
	[XmlElement ( "Shins" )]
	public Shins shins = new Shins ();
	
	[XmlElement ( "Shoulders" )]
	public Shoulders shoulders = new Shoulders ();
	
	[XmlElement ( "Thighs" )]
	public Thighs thighs = new Thighs ();
	
	[XmlElement ( "Waist" )]
	public Waist waist = new Waist ();
	
	[XmlElement ( "Weapons" )]
	public Weapons weapons = new Weapons ();
	
	[XmlElement ( "Shields" )]
	public Shields shields = new Shields ();
}


public class Abdomen
{
	
	[XmlElement ( "Armour" )]
	public List<AbdomenArmour> abdomenArmour = new List<AbdomenArmour> ();
}


public class AbdomenArmour
{
	
	public string identifier;
	public string name;
	public string armourRating;
	
	public AbdomenArmour () : this ( "null", "null", "null" ) {}
	public AbdomenArmour ( string _identifier, string _name, string _armourRating )
	{
		
		this.identifier = _identifier;
		this.name = _name;
		this.armourRating = _armourRating;
	}
}


public class Biceps
{
	
	[XmlElement ( "Armour" )]
	public List<BicepArmour> bicepArmour = new List<BicepArmour> ();
}


public class BicepArmour
{
	
	public string identifier;
	public string name;
	public string armourRating;
	
	public BicepArmour () : this ( "null", "null", "null" ) {}
	public BicepArmour ( string _identifier, string _name, string _armourRating )
	{
		
		this.identifier = _identifier;
		this.name = _name;
		this.armourRating = _armourRating;
	}
}


public class Chest
{
	
	[XmlElement ( "Armour" )]
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


public class Feet
{
	
	[XmlElement ( "Armour" )]
	public List<FootArmour> footArmour = new List<FootArmour> ();
}


public class FootArmour
{
	
	public string identifier;
	public string name;
	public string armourRating;
	
	public FootArmour () : this ( "null", "null", "null" ) {}
	public FootArmour ( string _identifier, string _name, string _armourRating )
	{
		
		this.identifier = _identifier;
		this.name = _name;
		this.armourRating = _armourRating;
	}
}


public class Forearms
{
	
	[XmlElement ( "Armour" )]
	public List<ForearmArmour> forearmArmour = new List<ForearmArmour> ();
}


public class ForearmArmour
{
	
	public string identifier;
	public string name;
	public string armourRating;
	
	public ForearmArmour () : this ( "null", "null", "null" ) {}
	public ForearmArmour ( string _identifier, string _name, string _armourRating )
	{
		
		this.identifier = _identifier;
		this.name = _name;
		this.armourRating = _armourRating;
	}
}


public class Hands
{
	
	[XmlElement ( "Armour" )]
	public List<HandArmour> handArmour = new List<HandArmour> ();
}


public class HandArmour
{
	
	public string identifier;
	public string name;
	public string armourRating;
	
	public HandArmour () : this ( "null", "null", "null" ) {}
	public HandArmour ( string _identifier, string _name, string _armourRating )
	{
		
		this.identifier = _identifier;
		this.name = _name;
		this.armourRating = _armourRating;
	}
}


public class Head
{
	
	[XmlElement ( "Armour" )]
	public List<HeadArmour> headArmour = new List<HeadArmour> ();
}


public class HeadArmour
{
	
	public string identifier;
	public string name;
	public string armourRating;
	
	public HeadArmour () : this ( "null", "null", "null" ) {}
	public HeadArmour ( string _identifier, string _name, string _armourRating )
	{
		
		this.identifier = _identifier;
		this.name = _name;
		this.armourRating = _armourRating;
	}
}


public class Neck
{
	
	[XmlElement ( "Armour" )]
	public List<NeckArmour> neckArmour = new List<NeckArmour> ();
}


public class NeckArmour
{
	
	public string identifier;
	public string name;
	public string armourRating;
	
	public NeckArmour () : this ( "null", "null", "null" ) {}
	public NeckArmour ( string _identifier, string _name, string _armourRating )
	{
		
		this.identifier = _identifier;
		this.name = _name;
		this.armourRating = _armourRating;
	}
}


public class Shins
{
	
	[XmlElement ( "Armour" )]
	public List<ShinArmour> shinArmour = new List<ShinArmour> ();
}


public class ShinArmour
{
	
	public string identifier;
	public string name;
	public string armourRating;
	
	public ShinArmour () : this ( "null", "null", "null" ) {}
	public ShinArmour ( string _identifier, string _name, string _armourRating )
	{
		
		this.identifier = _identifier;
		this.name = _name;
		this.armourRating = _armourRating;
	}
}


public class Shoulders
{
	
	[XmlElement ( "Armour" )]
	public List<ShoulderArmour> shoulderArmour = new List<ShoulderArmour> ();
}


public class ShoulderArmour
{
	
	public string identifier;
	public string name;
	public string armourRating;
	
	public ShoulderArmour () : this ( "null", "null", "null" ) {}
	public ShoulderArmour ( string _identifier, string _name, string _armourRating )
	{
		
		this.identifier = _identifier;
		this.name = _name;
		this.armourRating = _armourRating;
	}
}


public class Thighs
{
	
	[XmlElement ( "Armour" )]
	public List<ThighArmour> thighArmour = new List<ThighArmour> ();
}


public class ThighArmour
{
	
	public string identifier;
	public string name;
	public string armourRating;
	
	public ThighArmour () : this ( "null", "null", "null" ) {}
	public ThighArmour ( string _identifier, string _name, string _armourRating )
	{
		
		this.identifier = _identifier;
		this.name = _name;
		this.armourRating = _armourRating;
	}
}


public class Waist
{
	
	[XmlElement ( "Armour" )]
	public List<WaistArmour> waistArmour = new List<WaistArmour> ();
}


public class WaistArmour
{
	
	public string identifier;
	public string name;
	public string armourRating;
	
	public WaistArmour () : this ( "null", "null", "null" ) {}
	public WaistArmour ( string _identifier, string _name, string _armourRating )
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
