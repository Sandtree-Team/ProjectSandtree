#pragma strict

var playerMovement	: PlayerMovement;

var targString	: String;
var followTarg	: Transform;
var rayHit		: RaycastHit;
var rayMask		: LayerMask;
var camera1		: Camera;
var pointVector	: Vector3;

function Start ()
{
	followTarg	= GameObject.Find (targString).transform;
	playerMovement	= followTarg.GetComponent (PlayerMovement);
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
/*				//Just For Testing Purposes

	if (Input.GetKey (KeyCode.E))
	{	transform.eulerAngles.y += (60 * Time.deltaTime);	}
	if (Input.GetKey (KeyCode.Q))
	{	transform.eulerAngles.y -= (60 * Time.deltaTime);	}
*/
}