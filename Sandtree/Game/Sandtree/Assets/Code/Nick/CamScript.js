#pragma strict

var playerMovement	: PlayerMovement;
var inControl	: boolean;

var camTargPos	: Vector3;
var camTargRot	: Vector3;
var camMoveTime	: float;
var camRotTime	: float;
var targString	: String;
var followTarg	: Transform;
var rayHit		: RaycastHit;
var rayMask		: LayerMask;
var camera1		: Camera;
var camTrans	: Transform;
var pointVector	: Vector3;
var groundPlane	: GameObject;

function Start ()
{
	followTarg	= GameObject.Find (targString).transform;
	playerMovement	= followTarg.GetComponent (PlayerMovement);
	groundPlane.SetActive (true);
	camTargPos	= Vector3 (0,4.5,-4.75);
	camTargRot	= Vector3 (35,0,0);
}

function Update ()
{
	transform.position = followTarg.position;
	
	var ray	= camera1.ScreenPointToRay (Input.mousePosition);
	if (Physics.Raycast (ray, rayHit, Mathf.Infinity, rayMask))
	{
		pointVector	= rayHit.point;
		playerMovement.lookPoint	= pointVector;
	}
	
//	camTrans.localPosition		= Vector3.Lerp  (camTrans.localPosition,    camTargPos, camMoveTime);
//	camTrans.localEulerAngles	= Vector3.Slerp (camTrans.localEulerAngles, camTargRot, camRotTime);
/*				//Just For Testing Purposes

	if (Input.GetKey (KeyCode.E))
	{	transform.eulerAngles.y += (60 * Time.deltaTime);	}
	if (Input.GetKey (KeyCode.Q))
	{	transform.eulerAngles.y -= (60 * Time.deltaTime);	}
*/
}