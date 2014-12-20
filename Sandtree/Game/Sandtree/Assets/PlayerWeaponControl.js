#pragma strict

var weaponMode	: int;

var sword	: GameObject;
var shield	: GameObject;
var bow		: GameObject;

var meleeScript	: PlayerMelee;
var rangedScript: PlayerRanged;

function Start ()
{
	InformWeaponType ();
}

function InformWeaponType ()
{
	switch (weaponMode)
	{
		case (0):
			sword.SetActive		(false);
			shield.SetActive	(false);
			bow.SetActive		(false);
			
			meleeScript.canAttack	= false;
			rangedScript.canAttack	= false;
			break;
		case (1):
			sword.SetActive		(true);
			shield.SetActive	(true);
			bow.SetActive		(false);
			
			meleeScript.canAttack	= true;
			rangedScript.canAttack	= false;
			break;
		case (2):
			sword.SetActive		(false);
			shield.SetActive	(false);
			bow.SetActive		(true);
			
			meleeScript.canAttack	= false;
			rangedScript.canAttack	= true;
			break;
	}
}