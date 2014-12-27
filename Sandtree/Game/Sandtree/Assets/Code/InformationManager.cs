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
	
	[XmlElement ( "Armour" )]
	public AllArmour armour = new AllArmour ();
	
	[XmlElement ( "Weapons" )]
	public Weapons weapons = new Weapons ();
	
	[XmlElement ( "Shields" )]
	public Shields shields = new Shields ();
}


public class AllArmour
{
	
	[XmlElement ( "Abdomen" )]
	public List<Armour> abdomenArmour = new List<Armour> ();
	
	[XmlElement ( "Bicep" )]
	public List<Armour> bicepArmour = new List<Armour> ();
	
	[XmlElement ( "Chest" )]
	public List<Armour> chestArmour = new List<Armour> ();
	
	[XmlElement ( "Foot" )]
	public List<Armour> footArmour = new List<Armour> ();
	
	[XmlElement ( "Forearm" )]
	public List<Armour> forearmArmour = new List<Armour> ();
	
	[XmlElement ( "Hand" )]
	public List<Armour> handArmour = new List<Armour> ();
	
	[XmlElement ( "Head" )]
	public List<Armour> headArmour = new List<Armour> ();
	
	[XmlElement ( "Neck" )]
	public List<Armour> neckArmour = new List<Armour> ();
	
	[XmlElement ( "Shin" )]
	public List<Armour> shinArmour = new List<Armour> ();
	
	[XmlElement ( "Shoulder" )]
	public List<Armour> shoulderArmour = new List<Armour> ();
	
	[XmlElement ( "Thigh" )]
	public List<Armour> thighArmour = new List<Armour> ();
	
	[XmlElement ( "Waist" )]
	public List<Armour> waistArmour = new List<Armour> ();
	
#region OldSystem
	/*[XmlElement ( "Abdomen" )]
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
	public Waist waist = new Waist ();*/
#endregion
}


public class Armour
{
	
	public string identifier;
	public string bone;
	public string name;
	public string side;
	public string armourRating;
	
	public Armour () : this ( "null", "null", "null", "null", "null" ) {}
	public Armour ( string _identifier, string _bone, string _name, string _side, string _armourRating )
	{
		
		this.identifier = _identifier;
		this.bone = _bone;
		this.name = _name;
		this.side = _side;
		this.armourRating = _armourRating;
	}
}


#region OldSystem
/*
public class Abdomen
{
	
	[XmlElement ( "Armour" )]
	public List<Armour> abdomenArmour = new List<Armour> ();
}

public class Biceps
{
	
	[XmlElement ( "Armour" )]
	public List<Armour> bicepArmour = new List<Armour> ();
}


public class Chest
{
	
	[XmlElement ( "Armour" )]
	public List<Armour> chestArmour = new List<Armour> ();
}


public class Feet
{
	
	[XmlElement ( "Armour" )]
	public List<Armour> footArmour = new List<Armour> ();
}


public class Forearms
{
	
	[XmlElement ( "Armour" )]
	public List<Armour> forearmArmour = new List<Armour> ();
}


public class Hands
{
	
	[XmlElement ( "Armour" )]
	public List<Armour> handArmour = new List<Armour> ();
}


public class Head
{
	
	[XmlElement ( "Armour" )]
	public List<Armour> headArmour = new List<Armour> ();
}


public class Neck
{
	
	[XmlElement ( "Armour" )]
	public List<Armour> neckArmour = new List<Armour> ();
}


public class Shins
{
	
	[XmlElement ( "Armour" )]
	public List<Armour> shinArmour = new List<Armour> ();
}


public class Shoulders
{
	
	[XmlElement ( "Armour" )]
	public List<Armour> shoulderArmour = new List<Armour> ();
}


public class Thighs
{
	
	[XmlElement ( "Armour" )]
	public List<Armour> thighArmour = new List<Armour> ();
}


public class Waist
{
	
	[XmlElement ( "Armour" )]
	public List<Armour> waistArmour = new List<Armour> ();
}
*/

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
#endregion

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
