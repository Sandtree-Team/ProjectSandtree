using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//Written by Michael Bethke
public class Player
{
	
	internal GameObject playerObject;
	
	public float sizeModifier = 1.0f;
	
	public CurrentEquipment currentEquipment = new CurrentEquipment ();
	public Inventory inventory = new Inventory ();
}


public class CurrentEquipment
{
	
	public List<Armour> currentArmour = new List<Armour> () { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
	
	public CurrentEquipment ( Armour _headArmour = null, Armour _neckArmour = null, Armour _chestArmour = null, Armour _shoulderArmourLeft = null, Armour _shoulderArmourRight = null, Armour _bicepArmourLeft = null, Armour _bicepArmourRight = null, Armour _forearmArmourLeft = null, Armour _forearmArmourRight = null, Armour _handArmourLeft = null, Armour _handArmourRight = null, Armour _abdomenArmour = null, Armour _waistArmour = null, Armour _thighArmourLeft = null, Armour _thighArmourRight = null, Armour _shinArmourLeft = null, Armour _shinArmourRight = null, Armour _footArmourLeft = null, Armour _footArmourRight = null )
	{

		this.currentArmour[0] = _headArmour ?? this.currentArmour[0];
		this.currentArmour[1] = _neckArmour ?? this.currentArmour[1];
		this.currentArmour[2] = _chestArmour ?? this.currentArmour[2];
		this.currentArmour[3] = _shoulderArmourLeft ?? this.currentArmour[3];
		this.currentArmour[4] = _shoulderArmourRight ?? this.currentArmour[4];
		this.currentArmour[5] = _bicepArmourLeft ?? this.currentArmour[5];
		this.currentArmour[6] = _bicepArmourRight ?? this.currentArmour[6];
		this.currentArmour[7] = _forearmArmourLeft ?? this.currentArmour[7];
		this.currentArmour[8] = _forearmArmourRight ?? this.currentArmour[8];
		this.currentArmour[9] = _handArmourLeft ?? this.currentArmour[9];
		this.currentArmour[10] = _handArmourRight ?? this.currentArmour[10];
		this.currentArmour[11] = _abdomenArmour ?? this.currentArmour[11];
		this.currentArmour[12] = _waistArmour ?? this.currentArmour[12];
		this.currentArmour[13] = _thighArmourLeft ?? this.currentArmour[13];
		this.currentArmour[14] = _thighArmourRight ?? this.currentArmour[14];
		this.currentArmour[15] = _shinArmourLeft ?? this.currentArmour[15];
		this.currentArmour[16] = _shinArmourRight ?? this.currentArmour[16];
		this.currentArmour[17] = _footArmourLeft ?? this.currentArmour[17];
		this.currentArmour[18] = _footArmourRight ?? this.currentArmour [18];
		
		/*this.currentArmour.abdomenArmour = _abdomenArmour ?? this.currentArmour.abdomenArmour;
		this.currentArmour.bicepArmourLeft = _bicepArmourLeft ?? this.currentArmour.bicepArmourLeft;
		this.currentArmour.bicepArmourRight = _bicepArmourRight ?? this.currentArmour.bicepArmourRight;
		this.currentArmour.chestArmour = _chestArmour ?? this.currentArmour.chestArmour;
		this.currentArmour.footArmourLeft = _footArmourLeft ?? this.currentArmour.footArmourLeft;
		this.currentArmour.footArmourRight = _footArmourRight ?? this.currentArmour.footArmourRight;
		this.currentArmour.forearmArmourLeft = _forearmArmourLeft ?? this.currentArmour.forearmArmourLeft;
		this.currentArmour.forearmArmourRight = _forearmArmourRight ?? this.currentArmour.forearmArmourRight;
		this.currentArmour.handArmourLeft = _handArmourLeft ?? this.currentArmour.handArmourLeft;
		this.currentArmour.handArmourRight = _handArmourRight ?? this.currentArmour.handArmourRight;
		this.currentArmour.headArmour = _headArmour ?? this.currentArmour.headArmour;
		this.currentArmour.neckArmour = _neckArmour ?? this.currentArmour.neckArmour;
		this.currentArmour.shinArmourLeft = _shinArmourLeft ?? this.currentArmour.shinArmourLeft;
		this.currentArmour.shinArmourRight = _shinArmourRight ?? this.currentArmour.shinArmourRight;
		this.currentArmour.shoulderArmourLeft = _shoulderArmourLeft ?? this.currentArmour.shoulderArmourLeft;
		this.currentArmour.shoulderArmourRight = _shoulderArmourRight ?? this.currentArmour.shoulderArmourRight;
		this.currentArmour.thighArmourLeft = _thighArmourLeft ?? this.currentArmour.thighArmourLeft;
		this.currentArmour.thighArmourRight = _thighArmourRight ?? this.currentArmour.thighArmourRight;
		this.currentArmour.waistArmour = _waistArmour ?? this.currentArmour.waistArmour;*/
	}
}


public class Inventory
{
	
	
}


public class PlayerManager : MonoBehaviour
{
	
	InformationManager informationManager;

	internal Player player = new Player ();
	
	
	void Start ()
	{
		
		informationManager = GameObject.FindGameObjectWithTag ( "Manager" ).GetComponent<InformationManager> ();
		
		player.playerObject = gameObject;
		
		player.currentEquipment = new CurrentEquipment ( informationManager.equipmentCatalogue.armour.abdomenArmour[0], informationManager.equipmentCatalogue.armour.bicepArmour[0], informationManager.equipmentCatalogue.armour.bicepArmour[1], informationManager.equipmentCatalogue.armour.chestArmour[0], informationManager.equipmentCatalogue.armour.footArmour[0], informationManager.equipmentCatalogue.armour.footArmour[1], informationManager.equipmentCatalogue.armour.forearmArmour[0], informationManager.equipmentCatalogue.armour.forearmArmour[1], informationManager.equipmentCatalogue.armour.handArmour[0], informationManager.equipmentCatalogue.armour.handArmour[1], informationManager.equipmentCatalogue.armour.headArmour[0], null, /*informationManager.equipmentCatalogue.armour.neckArmour[0]*/ informationManager.equipmentCatalogue.armour.shinArmour[0], informationManager.equipmentCatalogue.armour.shinArmour[1], informationManager.equipmentCatalogue.armour.shoulderArmour[0], informationManager.equipmentCatalogue.armour.shoulderArmour[1], informationManager.equipmentCatalogue.armour.thighArmour[0], informationManager.equipmentCatalogue.armour.thighArmour[1], informationManager.equipmentCatalogue.armour.waistArmour[0] );
		
		if ( GameObject.FindGameObjectWithTag ( "Manager" ).GetComponent<ExternalInformation> ().TESTequipArmour ( player.playerObject, player.currentEquipment ) != true )
		{
			
			UnityEngine.Debug.LogError ( "Unable to equip test armour!" );
		}
	}
}
