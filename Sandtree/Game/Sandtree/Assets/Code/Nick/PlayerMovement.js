#pragma strict

var animator	: Animator;
var alive		: boolean;

var camTrans		: Transform;
var grounded		: boolean;
var groundContact	: boolean;
var contactTime		: float;

var velocity		: float;
var maxSlope		: float;

var moveSpeed			: float;
var maxVelocityChange	: float;
var movementMultiplyer	: float;
var velocityDenom		: float;

var lookPoint	: Vector3;
var lookTime	: float;
var jumpVel		: float;

function Start ()
{
	camTrans	= GameObject.Find ("CamObj").transform;
	velocityDenom	= moveSpeed;
}

function Update ()
{
	if (alive)
	{
		GroundingFunc ();
		RotationFunc ();
		MovementUpdate ();
	}
	AnimationFunc ();
}

function FixedUpdate ()
{
	MovementFixed ();
}

function RotationFunc ()
{
	var targQuatRelPos	= lookPoint - transform.position;
	var targQuat		= Quaternion.LookRotation (targQuatRelPos);
	targQuat	= targQuat * Quaternion.Euler (0,0,0);
	targQuat.eulerAngles.x	= 0;
	targQuat.eulerAngles.z	= 0;
	transform.rotation	= Quaternion.Slerp (transform.rotation, targQuat, lookTime / Time.deltaTime);

}

function MovementUpdate ()
{
	if (Input.GetButtonDown ("Jump") && grounded)
	{
		rigidbody.velocity.y += jumpVel;
	}
}

function MovementFixed ()
{
	if (grounded)
	{
		var targetVelocity	: Vector3;
		targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
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
		contactTime	= 0.075;		
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
	Debug.DrawRay	(transform.position + Vector3.up, horVel.normalized * 5, Color.red);
	Debug.DrawRay	(transform.position + Vector3.up, transform.forward * 5, Color.green);
	animator.SetBool	("Grounded", grounded);
	animator.SetFloat 	("VelocityHor", (horVel / velocityDenom).magnitude);
	animator.SetFloat	("LookVelDif", lookVelDif);
//	Debug.Log	(lookVelDif);
}