/*#pragma strict

//var movementScript	: PlayerMovement;
var camScript		: CamScript;
var animator		: Animator;

var attackRange		: float;
var attackVelocity	: float;

var attackTarg	: Transform;
var canAttack	: boolean;
var attackTime	: float;
var attackInt	: int;
var attackDis	: float;
var reach		: float;

function Start ()
{
//	movementScript	= GameObject.Find ("PlayerPrototype").GetComponent (PlayerMovement);
//	camScript		= GameObject.Find ("CamObj").GetComponent (CamScript);
}

function Update ()
{
	if (Input.GetButtonDown ("Fire1"))
	{
		if (canAttack)
		{
			if (attackTarg != null)
			{	TargetedAttackFunc ();	}
			else
			{	UntargetedAttackFunc ();	}
		}
	}
}

function TargetedAttackFunc ()
{
	attackDis	= Vector3.Distance (attackTarg.position, transform.position);
	if (attackDis > attackRange)
	{
		UntargetedAttackFunc ();
	}
	else
	{
//		Debug.Log ("TargetedAttack");
		rigidbody.velocity.x	= 0;
		rigidbody.velocity.z	= 0;
		attackInt	= Random.Range (1,4);
		animator.SetInteger	("AttackInt", attackInt);
		VarAssign	();
		
		canAttack					= false;
		/* Bring Back */ //movementScript.inControl	= false;
/*		camScript.inControl			= false;
		
		var velYStore	= rigidbody.velocity.y;
		var clickVector	: Vector3;
		
		if (attackDis > reach)
		{	attackVelocity	= (attackDis - reach) / (attackTime * 0.7);	}
		else if (attackDis < (reach + 0.25))
		{	attackVelocity	= -1;	}
		
		clickVector	= (camScript.pointVector - transform.position).normalized;
		rigidbody.velocity		= clickVector * attackVelocity;
		rigidbody.velocity.y	= velYStore;
		
		yield WaitForSeconds (attackTime * 0.5);
		//Put second attack stuff here
		
		yield WaitForSeconds (attackTime * 0.5);
		animator.SetInteger ("AttackInt", 0);
		canAttack					= true;
		/* Bring Back */ //movementScript.inControl	= true;
/*		camScript.inControl			= true;
		attackTarg			= null;
		camScript.hasTarget	= false;
	}
}

function UntargetedAttackFunc ()
{
//	Debug.Log ("UntargetedAttack");
	attackInt	= Random.Range (1,4);
	animator.SetInteger	("AttackInt", attackInt);
	VarAssign	();
	
	canAttack					= false;
	/* Bring Back */ //movementScript.inControl	= false;
/*	camScript.inControl			= false;
	
	var velYStore	= rigidbody.velocity.y;
	var clickVector	: Vector3;
	attackVelocity	= 2;
	clickVector	= (camScript.pointVector - transform.position).normalized;
	rigidbody.velocity		= clickVector * attackVelocity;
	rigidbody.velocity.y	= velYStore;
	
	yield WaitForSeconds (attackTime * 0.5);
	//Put second attack stuff here
	
	yield WaitForSeconds (attackTime * 0.5);
	animator.SetInteger ("AttackInt", 0);
	canAttack					= true;
	/* Bring Back */ //movementScript.inControl	= true;
/*	camScript.inControl			= true;
}

function VarAssign ()
{
	switch (attackInt)
	{
		case (1):		//Front Stab
			attackTime	= 0.66;
			reach		= 1;
			break;
		case (2):		//Under Stab
			attackTime	= 0.7;
			reach		= 1;
			break;
		case (3):		//Spin Slash
			attackTime	= 0.75;
			reach		= 0.9;
			break;
	}
}
*/