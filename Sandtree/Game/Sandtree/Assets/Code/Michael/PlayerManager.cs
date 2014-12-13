using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//Written by Michael Bethke
public class PlayerCharacter
{
	
	internal List<Equipment> equipment = new List<Equipment> ();
}


public class Equipment
{
	
	string id;
}


public class Helmet : Equipment
{
	
	string modelParent = "helmet";
	string modelID = "egyptCat";
}


public class PlayerManager : MonoBehaviour
{

	
}
