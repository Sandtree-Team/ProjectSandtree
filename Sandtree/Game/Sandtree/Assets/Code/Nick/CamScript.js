#pragma strict

var playerMovement	: PlayerMovement;
var playerMelee		: PlayerMelee;
var inControl	: boolean;
var hasTarget	: boolean;

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
	playerMelee		= followTarg.GetComponent (PlayerMelee);
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
		if (rayHit.transform.gameObject.tag	== "Enemy")
		{
			pointVector	= rayHit.transform.position;
			if (!hasTarget)
			{
				hasTarget	= true;
				playerMelee.attackTarg	= rayHit.transform;
//				Debug.Log ("TargetAcquired");
			}
		}
		else
		{	
			pointVector	= rayHit.point;
			if (hasTarget)
			{
				hasTarget	= false;
				playerMelee.attackTarg	= null;
//				Debug.Log ("TargetLost");
			}
		}
		
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