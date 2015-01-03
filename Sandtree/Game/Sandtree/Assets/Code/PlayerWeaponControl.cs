using UnityEngine;
using System.Collections;

public class PlayerWeaponControl : MonoBehaviour {

	public int weaponMode;

	public GameObject sword;
	public GameObject shield;
	public GameObject bow;

	public PlayerMelee meleeScript;
	public PlayerRanged rangedScript;
	public Animator animator;

	void Start ()
	{
		InformWeaponType ();
	}
	
	void InformWeaponType ()
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
		animator.SetInteger ("WeaponMode", weaponMode);
	}
}
