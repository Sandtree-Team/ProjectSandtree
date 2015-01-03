using UnityEngine;
using System.Collections;

public class PlayerMelee : MonoBehaviour {

	public PlayerMovement movementScript;
	public CamScript camScript;
	public Animator animator;

	public float attackRange;
	public float attackVelocity;

	public Transform attackTarg;
	public bool canAttack;
	public float attackTime;
	public int attackInt;
	public float attackDis;
	public float reach;

	void Start ()
	{
		//	movementScript	= GameObject.Find ("PlayerPrototype").GetComponent (PlayerMovement);
		//	camScript		= GameObject.Find ("CamObj").GetComponent (CamScript);
	}
	
	void Update ()
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
	
	IEnumerator TargetedAttackFunc ()
	{
		attackDis	= Vector3.Distance (attackTarg.position, transform.position);
		if (attackDis > attackRange)
		{
			UntargetedAttackFunc ();
		}
		else
		{
			//		Debug.Log ("TargetedAttack");
			Vector3 rigVelStore = rigidbody.velocity;
			rigVelStore.x = 0;
			rigVelStore.z = 0;
			rigidbody.velocity = rigVelStore;

			attackInt	= Random.Range (1,4);
			animator.SetInteger	("AttackInt", attackInt);
			VarAssign	();
			
			canAttack					= false;
			movementScript.inControl	= false;
			camScript.inControl			= false;
			
			float velYStore	= rigidbody.velocity.y;
			Vector3 clickVector;
			
			if (attackDis > reach)
			{
				attackVelocity	= (attackDis - reach) / (attackTime * 0.7f);
			}
			else if (attackDis < (reach + 0.25f))
			{
				attackVelocity	= -1;
			}
			
			clickVector	= (camScript.pointVector - transform.position).normalized;
			rigidbody.velocity		= clickVector * attackVelocity;
			Vector3 rigVelStore2 = rigidbody.velocity;
			rigVelStore2.y = velYStore;
			rigidbody.velocity = rigVelStore2;
			
			yield return new WaitForSeconds (attackTime * 0.5f);
			//Put second attack stuff here
			
			yield return new WaitForSeconds (attackTime * 0.5f);
			animator.SetInteger ("AttackInt", 0);
			canAttack					= true;
			movementScript.inControl	= true;
			camScript.inControl			= true;
			attackTarg			= null;
			camScript.hasTarget	= false;
		}
	}
	
	IEnumerator UntargetedAttackFunc ()
	{
		//	Debug.Log ("UntargetedAttack");
		attackInt	= Random.Range (1,4);
		animator.SetInteger	("AttackInt", attackInt);
		VarAssign	();
		
		canAttack					= false;
		movementScript.inControl	= false;
		camScript.inControl			= false;
		
		float velYStore	= rigidbody.velocity.y;
		Vector3 clickVector;
		attackVelocity	= 2;
		clickVector	= (camScript.pointVector - transform.position).normalized;
		rigidbody.velocity		= clickVector * attackVelocity;
		Vector3 rigVelStore3 = rigidbody.velocity;
		rigVelStore3.y = velYStore;
		rigidbody.velocity = rigVelStore3;

		yield return new WaitForSeconds (attackTime * 0.5f);
		//Put second attack stuff here
		
		yield return new WaitForSeconds (attackTime * 0.5f);
		animator.SetInteger ("AttackInt", 0);
		canAttack					= true;
		movementScript.inControl	= true;
		camScript.inControl			= true;
	}
	
	void VarAssign ()
	{
		switch (attackInt)
		{
		case (1):		//Front Stab
			attackTime	= 0.66f;
			reach		= 1f;
			break;
		case (2):		//Under Stab
			attackTime	= 0.7f;
			reach		= 1f;
			break;
		case (3):		//Spin Slash
			attackTime	= 0.75f;
			reach		= 0.9f;
			break;
		}
	}
}
