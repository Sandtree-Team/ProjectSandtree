using UnityEngine;
using System.Collections;
//Written by Michael Bethke
public class CurrentEquipment
{
	
	/*
	Abdomen		- Baulds / Culet
	BicepL		- Rerebrace / Brassart
	BicepR		//
	Chest		- Brigandine / Haubergeon / Cuirass / Pixane / Plackart / Faulds / Culet / Besagew
	Elbow		- Couter
	FootL		- Sabaton / Solleret
	FootR		//
	ForearmL	- Vambrace / Gauntlet
	ForearmR	//
	HandL		- Glove?
	HandR		//
	Head		- Coif / Helm / Bassinet / Armet / Sallet / Barbute / Burgonet
	KneeL		- Poleyn
	KneeR		//
	Neck		- Aventail / Gorget / Bevor
	ShinL		- Chausses / Schynbald / Greave
	ShinR		//
	Shoulder	- Spaulder / Pauldron / Gardbrace
	ThighL		- Cuisse / Lame
	ThighR		//
	Waist		- Belt?
	*/
	
	
	internal Helmet helmet;
	
	public CurrentEquipment () : this ( null ) {}
	public CurrentEquipment ( Helmet _helmet )
	{
		
		this.helmet = _helmet;
	}
}


public class Inventory
{
	
	
}

public class PlayerStorage : MonoBehaviour
{

	internal CurrentEquipment currentEquipment = new CurrentEquipment ();
}
