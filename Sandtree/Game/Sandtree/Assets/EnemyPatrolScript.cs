using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPatrolScript : MonoBehaviour {

	public bool shouldPatrol;

	public Animator animator;
	public float speed;
	float speedBase;
	//public Transform [] waypoints;
	
	private List<Vector3> waypoints = new List<Vector3> ();
	float [] pauses;

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

		GroundingFunc ();
		if (shouldPatrol)
		{
			StartCoroutine (MoveTo ());
		}
		AnimationFunc ();
	}

	void FixedUpdate ()
	{
		if (shouldPatrol)
		{
			MovementFixed ();
		}
	}

	/* Original TriggerEnter function, based on physical objects
	
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
	}*/
	
	void OnTriggerEnter (Collider col)
	{
		
		if (col.gameObject.tag == "PatrolObject" && holdObj != col.gameObject)
		{
			shouldPatrol = true;
			holdObj = col.gameObject;
			PatrolVisualizer informer = col.gameObject.GetComponent <PatrolVisualizer>();

			waypoints = informer.patrolWaypoints;
			pauses = informer.patrolPauses;

			waypointInt = 0;
			targPos = waypoints [waypointInt];
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
			if (waypoints.Count - 1 > waypointInt)
			{
				waypointInt += 1;
				//targPos = transform.position;
				//yield return new WaitForSeconds (pauses [waypointInt]);
				targPos = waypoints [waypointInt];
			}
			else
			{
				waypointInt = 0;
				//yield return new WaitForSeconds (pauses [waypointInt]);
				targPos = waypoints [waypointInt];
			}
			speed = 0;

			//Debug.Log (waypointInt);

			if (waypointInt != 0)
			{
					//this one is the intended behavior
				yield return new WaitForSeconds (pauses [waypointInt - 1]);
				//yield return new WaitForSeconds ( waypointInt );
			}
			else
			{
				yield return new WaitForSeconds (pauses [pauses.Length -1]);
				//yield return new WaitForSeconds ( waypointInt );
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
