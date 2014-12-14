#pragma strict

var movementScript	: PlayerMovement;
var camScript		: CamScript;
var animator		: Animator;

var attackVelocity	: float;

var canAttack	: boolean;
var attackTime	: float;
var attackInt	: int;

function Start ()
{
	movementScript	= GameObject.Find ("PlayerPrototype").GetComponent (PlayerMovement);
	camScript		= GameObject.Find ("CamObj").GetComponent (CamScript);
}

function Update ()
{
	if (Input.GetButtonDown ("Fire1"))
	{
		if (canAttack)
		{
			AttackFunc ();
		}
	}
}

function AttackFunc ()
{
//	Debug.Log ("AttackFunc");
	attackInt	= Random.Range (1,4);
	animator.SetInteger	("AttackInt", attackInt);
	VarAssign	();
	
	canAttack					= false;
	movementScript.inControl	= false;
	camScript.inControl			= false;
	
	var velYStore	= rigidbody.velocity.y;
	var clickVector	: Vector3;
	clickVector	= (camScript.pointVector - transform.position).normalized;
	rigidbody.velocity		= clickVector * attackVelocity;
	rigidbody.velocity.y	= velYStore;
	
	yield WaitForSeconds (attackTime * 0.5);
	//Put second attack stuff here
	
	yield WaitForSeconds (attackTime * 0.5);
	animator.SetInteger ("AttackInt", 0);
	canAttack					= true;
	movementScript.inControl	= true;
	camScript.inControl			= true;
}

function VarAssign ()
{
	switch (attackInt)
	{
		case (1):
			attackTime	= 0.66;
			attackVelocity	= 3;
			break;
		case (2):
			attackTime	= 0.8;
			attackVelocity	= 3;
		case (3):
			attackTime	= 0.75;
			attackVelocity	= 3;
	}
}