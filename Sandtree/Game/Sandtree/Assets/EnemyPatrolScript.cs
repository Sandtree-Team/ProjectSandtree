using UnityEngine;
using System.Collections;

public class EnemyPatrolScript : MonoBehaviour {

	public bool shouldPatrol;

	public Animator animator;
	public float speed;
	float speedBase;
	public Transform [] waypoints;
	public float [] pauses;
	public Vector3 targPos;
	GameObject holdObj;
	public float turnTime;
	public float allowence;
	public int waypointInt;
	public bool grounded;
	public bool groundContact;
	public float contactTime;
	public float reqContactTime;
	public float maxSlope;

	//public float moveSpeed;
	public float maxVelocityChange;
	public float movementMultiplyer;
	public float velocityDenom;

	void Start () {
		speedBase = speed;
		velocityDenom = speedBase;

		animator.SetInteger ("WeaponMode", 1);
	}

	void Update () {

		if (shouldPatrol)
		{
			GroundingFunc ();
			StartCoroutine (MoveTo ());
			AnimationFunc ();
		}
	}

	void FixedUpdate ()
	{
		if (shouldPatrol)
		{
			MovementFixed ();
		}
	}

	void OnTriggerEnter (Collider col)
	{
//		Debug.Log (col.gameObject.tag);
		if (col.gameObject.tag == "PatrolObject" && holdObj != col.gameObject)
		{
			holdObj = col.gameObject;
			PatrolObjectScript informer;
			informer = col.gameObject.GetComponent <PatrolObjectScript>();

			waypoints = informer.waypoints;
			pauses = informer.pauses;

			waypointInt = 0;
			targPos = waypoints [waypointInt].position;
		}
	}

	IEnumerator MoveTo ()
	{
		Vector3 pos = transform.position;
		//pos += (speed * transform.forward * Time.deltaTime);
		//transform.position = pos;

		Vector3 turnTargPos = targPos;
		turnTargPos.y = transform.position.y;
		Quaternion curRot = transform.rotation;
		Vector3 relPos = turnTargPos - pos;
		Quaternion targRot = Quaternion.LookRotation (relPos);
		curRot = Quaternion.Slerp (curRot, targRot, Time.deltaTime / turnTime);
		transform.rotation = curRot;

		if (Vector3.Distance (pos, targPos) < allowence)
		{
			if (waypoints.Length - 1 > waypointInt)
			{
				waypointInt += 1;
				//targPos = transform.position;
				//yield return new WaitForSeconds (pauses [waypointInt]);
				targPos = waypoints [waypointInt].position;
			}
			else
			{
				waypointInt = 0;
				//yield return new WaitForSeconds (pauses [waypointInt]);
				targPos = waypoints [waypointInt].position;
			}
			speed = 0;

			if (waypointInt != 0)
			{
				yield return new WaitForSeconds (pauses [waypointInt - 1]);
			}
			else
			{
				yield return new WaitForSeconds (pauses [pauses.Length -1]);
			}
			speed = speedBase;
		}
	}

	void GroundingFunc ()
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
	
	void OnCollisionStay (Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			//		Debug.Log (Vector3.Angle(contact.normal, Vector3.up));
			if (Vector3.Angle(contact.normal, Vector3.up) < maxSlope)
			{
				groundContact	= true;
			}
		}
	}

	void AnimationFunc ()
	{
		Vector3 horVelV3 = rigidbody.velocity;
		horVelV3.y = 0;
		float horVel = horVelV3.magnitude;

		//Debug.Log (horVel);

		animator.SetBool ("Grounded", grounded);
		animator.SetFloat ("VelocityHor", horVel / velocityDenom);
	}

	void MovementFixed ()
	{
		if (grounded)
		{
			Vector3 targetVelocity;
			targetVelocity = transform.forward;
			targetVelocity *= speed;
			targetVelocity *= movementMultiplyer;
			
			Vector3 moveVelocity;
			Vector3 moveVelocityChange;
			moveVelocity = rigidbody.velocity;
			moveVelocityChange = (targetVelocity - moveVelocity);
			moveVelocityChange.x = Mathf.Clamp(moveVelocityChange.x, -maxVelocityChange, maxVelocityChange);
			moveVelocityChange.z = Mathf.Clamp(moveVelocityChange.z, -maxVelocityChange, maxVelocityChange);
			moveVelocityChange.y = 0;
			rigidbody.AddForce (moveVelocityChange, ForceMode.VelocityChange);
		}
	}
}
