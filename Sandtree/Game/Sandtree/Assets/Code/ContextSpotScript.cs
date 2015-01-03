using UnityEngine;
using System.Collections;

public class ContextSpotScript : MonoBehaviour {

	public Vector3 camPosV3;
	public Quaternion camRotV3;
	public Vector3 newLookPoint;

	public Transform posObj;
	public Transform targObj;

	void Start ()
	{
		posObj.gameObject.GetComponent <MeshRenderer>().enabled = false;
		targObj.gameObject.GetComponent <MeshRenderer>().enabled	= false;
		newLookPoint	= targObj.position;
		var relative	= targObj.position - posObj.position;
		camPosV3	= posObj.position;
		camRotV3	= Quaternion.LookRotation (relative);
	}
}
