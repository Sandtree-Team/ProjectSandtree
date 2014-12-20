#pragma strict

var meleeScript	: PlayerMelee;
var animator	: Animator;
var camScript	: CamScript;
var alive		: boolean;
var inControl	: boolean;

var camTrans		: Transform;
var grounded		: boolean;
var groundContact	: boolean;
var reqContactTime	: float;
var contactTime		: float;

var velocity		: float;
var maxSlope		: float;

var moveSpeed			: float;
var maxVelocityChange	: float;
var movementMultiplyer	: float;
var velocityDenom		: float;

var lookPoint	: Vector3;
var lookTime	: float;
var jumpHeight	: float;
var contextLookPoint	: Vector3;

function Start ()
{
//	camTrans	= GameObject.Find ("CamObj").transform;
//	camScript	= GameObject.Find ("CamObj").GetComponent (CamScript);
	velocityDenom	= moveSpeed;
}

function Update ()
{
//	RotationFunc ();
	if (alive)
	{
		RotationFunc ();
	}
	
	if (alive && inControl)
	{
		GroundingFunc ();
		MovementUpdate ();
		AnimationFunc ();
	}
//	Debug.Log (rigidbody.velocity.magnitude);
}

function OnTriggerEnter (col : Collider)
{
//	Debug.Log (col.name);
	
	camScript.contextAvailable	= true;
	meleeScript.canAttack	= false;
	
	var contextScript	: ContextSpotScript;
	contextScript	= col.transform.parent.GetComponent (ContextSpotScript);
	
	camScript.newTargPos	= contextScript.camPosV3;
	camScript.newTargRot	= contextScript.camRotV3;
	contextLookPoint		= contextScript.newLookPoint;
}

function OnTriggerExit ()
{
	camScript.contextAvailable	= false;
	meleeScript.canAttack	= true;
	
	camScript.newTargPos	= Vector3.zero;
	camScript.newTargRot	= Quaternion (0,0,0,0);;
}

function FixedUpdate ()
{
	if (alive && inControl)
	{
		MovementFixed ();
	}
}

function RotationFunc ()
{
	var targQuatRelPos	= lookPoint - transform.position;
	var targQuat		= Quaternion.LookRotation (targQuatRelPos);
	targQuat	= targQuat * Quaternion.Euler (0,0,0);
	targQuat.eulerAngles.x	= 0;
	targQuat.eulerAngles.z	= 0;
	transform.rotation	= Quaternion.Slerp (transform.rotation, targQuat, Time.deltaTime / lookTime);

}

function MovementUpdate ()
{
	if (Input.GetButtonDown ("Jump") && grounded)
	{
//		rigidbody.velocity.y += jumpVel;
		rigidbody.velocity.y	= Mathf.Sqrt (2 * Mathf.Abs (Physics.gravity.magnitude) * jumpHeight);
	}
}

function MovementFixed ()
{
	if (grounded)
	{
		var targetVelocity	: Vector3;
		targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		targetVelocity = Vector3.ClampMagnitude (targetVelocity, 1);
		targetVelocity = camTrans.TransformDirection(targetVelocity);
		targetVelocity *= moveSpeed;
		targetVelocity *= movementMultiplyer;

		var moveVelocity		: Vector3;
		var moveVelocityChange	: Vector3;
		moveVelocity = rigidbody.velocity;
		moveVelocityChange = (targetVelocity - moveVelocity);
		moveVelocityChange.x = Mathf.Clamp(moveVelocityChange.x, -maxVelocityChange, maxVelocityChange);
		moveVelocityChange.z = Mathf.Clamp(moveVelocityChange.z, -maxVelocityChange, maxVelocityChange);
		moveVelocityChange.y = 0;
		rigidbody.AddForce (moveVelocityChange, ForceMode.VelocityChange);
	}
}

function GroundingFunc ()
{
	if (groundContact)
	{
		contactTime	= reqContactTime;		
		grounded	= true;
//		jumpReady	= true;
	}
	else
	{
		contactTime	-= Time.deltaTime;
			
		if (contactTime <= 0)
		{
			grounded	= false;
		}
	}
//	Debug.Log (groundContact);
}

function OnCollisionStay (collision : Collision)
{
	for(var contact : ContactPoint in collision.contacts)
	{
//		Debug.Log (Vector3.Angle(contact.normal, Vector3.up));
		if (Vector3.Angle(contact.normal, Vector3.up) < maxSlope)
		{
			groundContact	= true;
		}
	}
}

function OnCollisionExit	()
{
	groundContact	= false;
}

function AnimationFunc ()
{
	var horVel	= rigidbody.velocity;
	horVel.y	= 0;
//	var inputVector	= Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")).normalized;
	var lookVelDif	= Vector3.Angle (transform.forward, horVel.normalized);
//	Debug.DrawRay	(transform.position + Vector3.up, horVel.normalized * 5, Color.red);
//	Debug.DrawRay	(transform.position + Vector3.up, transform.forward * 5, Color.green);
	animator.SetBool	("Grounded", grounded);
	animator.SetFloat 	("VelocityHor", (horVel / velocityDenom).magnitude);
	animator.SetFloat	("LookVelDif", lookVelDif);
//	Debug.Log	(lookVelDif);
}