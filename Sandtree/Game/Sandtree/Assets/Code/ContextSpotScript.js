#pragma strict

var camPosV3	: Vector3;
var camRotV3	: Quaternion;
var newLookPoint: Vector3;

var	posObj	: Transform;
var targObj	: Transform;

function Start ()
{
	posObj. gameObject.GetComponent (MeshRenderer).enabled	= false;
	targObj.gameObject.GetComponent (MeshRenderer).enabled	= false;
	newLookPoint	= targObj.position;
	var relative	= targObj.position - posObj.position;
	camPosV3	= posObj.position;
	camRotV3	= Quaternion.LookRotation (relative);
}