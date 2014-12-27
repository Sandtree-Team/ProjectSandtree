using UnityEngine;
using System.Collections;
//Written by Michael Bethke
public class CurrentEquipment
{
	
	/*
	Abdomen		- Baulds / Culet
	Biceps		- Rerebrace / Brassart
	Chest		- Brigandine / Haubergeon / Cuirass / Pixane / Plackart / Faulds / Culet / Besagew
	Feet		- Sabaton / Solleret
	Forearms	- Vambrace / Gauntlet
	Hands		- Glove?
	Head		- Coif / Helm / Bassinet / Armet / Sallet / Barbute / Burgonet
	Neck		- Aventail / Gorget / Bevor
	Shins		- Chausses / Schynbald / Greave
	Shoulders	- Spaulder / Pauldron / Gardbrace
	Thighs		- Cuisse / Lame
	Waist		- Belt?
	*/
	
	public AbdomenArmour abdomenArmour = new AbdomenArmour ();
	
	public BicepArmour bicepArmourLeft = new BicepArmour ();
	public BicepArmour bicepArmourRight = new BicepArmour ();
	
	public ChestArmour chestArmour = new ChestArmour ();
	
	public FootArmour footArmourLeft = new FootArmour ();
	public FootArmour footArmourRight = new FootArmour ();
	
	public ForearmArmour forearmArmourLeft = new ForearmArmour ();
	public ForearmArmour forearmArmourRight = new ForearmArmour ();
	
	public HandArmour handArmourLeft = new HandArmour ();
	public HandArmour handArmourRight = new HandArmour ();
	
	public HeadArmour headArmour = new HeadArmour ();
	
	public NeckArmour neckArmour = new NeckArmour ();
	
	public ShinArmour shinArmourLeft = new ShinArmour ();
	public ShinArmour shinArmourRight = new ShinArmour ();
	
	public ShoulderArmour shoulderArmourLeft = new ShoulderArmour ();
	public ShoulderArmour shoulderArmourRight = new ShoulderArmour ();
	
	public ThighArmour thighArmourLeft = new ThighArmour ();
	public ThighArmour thighArmourRight = new ThighArmour ();
	
	public WaistArmour waistArmour = new WaistArmour ();
	
	
	//public CurrentEquipment () : this ( null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null ) {}
	public CurrentEquipment ( AbdomenArmour _abdomenArmour = null, BicepArmour _bicepArmourLeft = null, BicepArmour _bicepArmourRight = null, ChestArmour _chestArmour = null, FootArmour _footArmourLeft = null, FootArmour _footArmourRight = null, ForearmArmour _forearmArmourLeft = null, ForearmArmour _forearmArmourRight = null, HandArmour _handArmourLeft = null, HandArmour _handArmourRight = null, HeadArmour _headArmour = null, NeckArmour _neckArmour = null, ShinArmour _shinArmourLeft = null, ShinArmour _shinArmourRight = null, ShoulderArmour _shoulderArmourLeft = null, ShoulderArmour _shoulderArmourRight = null, ThighArmour _thighArmourLeft = null, ThighArmour _thighArmourRight = null, WaistArmour _waistArmour = null )
	{
		
		this.abdomenArmour = _abdomenArmour ?? this.abdomenArmour;
		this.bicepArmourLeft = _bicepArmourLeft ?? this.bicepArmourLeft;
		this.bicepArmourRight = _bicepArmourRight ?? this.bicepArmourRight;
		this.chestArmour = _chestArmour ?? this.chestArmour;
		this.footArmourLeft = _footArmourLeft ?? this.footArmourLeft;
		this.footArmourRight = _footArmourRight ?? this.footArmourRight;
		this.forearmArmourLeft = _forearmArmourLeft ?? this.forearmArmourLeft;
		this.forearmArmourRight = _forearmArmourRight ?? this.forearmArmourRight;
		this.handArmourLeft = _handArmourLeft ?? this.handArmourLeft;
		this.handArmourRight = _handArmourRight ?? this.handArmourRight;
		this.headArmour = _headArmour ?? this.headArmour;
		this.neckArmour = _neckArmour ?? this.neckArmour;
		this.shinArmourLeft = _shinArmourLeft ?? this.shinArmourLeft;
		this.shinArmourRight = _shinArmourRight ?? this.shinArmourRight;
		this.shoulderArmourLeft = _shoulderArmourLeft ?? this.shoulderArmourLeft;
		this.shoulderArmourRight = _shoulderArmourRight ?? this.shoulderArmourRight;
		this.thighArmourLeft = _thighArmourLeft ?? this.thighArmourLeft;
		this.thighArmourRight = _thighArmourRight ?? this.thighArmourRight;
		this.waistArmour = _waistArmour ?? this.waistArmour;
	}
}


public class Inventory
{
	
	
}

public class PlayerStorage : MonoBehaviour
{

	internal CurrentEquipment currentEquipment = new CurrentEquipment ();
}
