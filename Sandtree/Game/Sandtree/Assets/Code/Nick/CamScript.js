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

var obstructionMask		: LayerMask;
var obstructionHit		: RaycastHit;
var obstructionHitHold	: RaycastHit;

var ShaderHold			: Shader;
var transparent			: Shader;
var transparencyValue	: float;
var transparencyHold	: float;
var obstructionRenderer	: MeshRenderer;

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
	
	if (Physics.Linecast (camTrans.position, (followTarg.position + (Vector3.up * 1)), obstructionHit, obstructionMask))
	{
		if (obstructionHit != obstructionHitHold)
		{
			if (obstructionRenderer	!= null)
			{
				obstructionRenderer.material.color.a	= transparencyHold;
				obstructionRenderer.material.shader	= ShaderHold;
			}
			
			obstructionRenderer	= obstructionHit.transform.gameObject.GetComponent (MeshRenderer);
			ShaderHold			= obstructionRenderer.material.shader;
			obstructionRenderer.material.shader	= transparent;
			transparencyHold	= obstructionRenderer.material.color.a;
			
			if (transparencyHold > transparencyValue)
			{
				obstructionRenderer.material.color.a	= transparencyValue;
				obstructionHitHold	= obstructionHit;
			}
		}
	}
	else
	{
		if (obstructionRenderer	!= null)
		{
			obstructionRenderer.material.color.a	= transparencyHold;
			obstructionRenderer.material.shader	= ShaderHold;
			
//			obstructionHit		= null;
//			obstructionHitHold	= null;
		}
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