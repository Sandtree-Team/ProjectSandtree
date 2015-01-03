using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	public PlayerWeaponControl playerWeapon;
	public PlayerMelee meleeScript;
	public Animator animator;
	public CamScript camScript;
	public bool alive;
	public bool inControl;

	public Transform camTrans;
	public bool grounded;
	public bool groundContact;
	public float reqContactTime;
	public float contactTime;

	public float velocity;
	public float maxSlope;

	public float moveSpeed;
	public float maxVelocityChange;
	public float movementMultiplyer;
	public float velocityDenom;

	public Vector3 lookPoint;
	public float lookTime;
	public float jumpHeight;
	public Vector3 contextLookPoint;
	
	void Start ()
	{
		//	camTrans	= GameObject.Find ("CamObj").transform;
		//	camScript	= GameObject.Find ("CamObj").GetComponent (CamScript);
		velocityDenom	= moveSpeed;
	}
	
	void Update ()
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
	
	void OnTriggerEnter (Collider col)
	{
		//	Debug.Log (col.name);
		
		if (col.gameObject.tag	== "ContextSpot")
		{
			camScript.contextAvailable	= true;
			meleeScript.canAttack	= false;

			ContextSpotScript contextScript;
			contextScript	= col.transform.parent.GetComponent <ContextSpotScript>();
			
			camScript.newTargPos	= contextScript.camPosV3;
			camScript.newTargRot	= contextScript.camRotV3;
			contextLookPoint		= contextScript.newLookPoint;
		}
	}
	
	void OnTriggerExit ()
	{
		camScript.contextAvailable	= false;
		meleeScript.canAttack	= true;
		
		camScript.newTargPos	= Vector3.zero;
		camScript.newTargRot	= new Quaternion (0,0,0,0);;
	}
	
	void FixedUpdate ()
	{
		if (alive && inControl)
		{
			MovementFixed ();
		}
	}
	
	void RotationFunc ()
	{
		Vector3 targQuatRelPos	= lookPoint - transform.position;
		Quaternion targQuat		= Quaternion.LookRotation (targQuatRelPos);
		targQuat	= targQuat * Quaternion.Euler (0,0,0);
		Quaternion targQuatStore = targQuat;
		Vector3 targQuatStoreV3 = targQuatStore.eulerAngles;
		targQuatStoreV3 = targQuatStore.eulerAngles;
		targQuatStoreV3.x = 0;
		targQuatStoreV3.z = 0;
		targQuatStore.eulerAngles = targQuatStoreV3;
	//	targQuatStore.eulerAngles.z	= 0;
		targQuat = targQuatStore;
		transform.rotation	= Quaternion.Slerp (transform.rotation, targQuat, Time.deltaTime / lookTime);
		
	}
	
	void MovementUpdate ()
	{
		if (Input.GetButtonDown ("Jump") && grounded)
		{
			//		rigidbody.velocity.y += jumpVel;
			Vector3 rigidVelStore = rigidbody.velocity;
			rigidVelStore.y = Mathf.Sqrt (2 * Mathf.Abs (Physics.gravity.magnitude) * jumpHeight);
			rigidbody.velocity	= rigidVelStore;
		}
	}
	
	void MovementFixed ()
	{
		if (grounded)
		{
			Vector3 targetVelocity;
			targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			targetVelocity = Vector3.ClampMagnitude (targetVelocity, 1);
			targetVelocity = camTrans.TransformDirection(targetVelocity);
			targetVelocity *= moveSpeed;
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
	
	void OnCollisionExit	()
	{
		groundContact	= false;
	}
	
	void AnimationFunc ()
	{
		Vector3 horVel	= rigidbody.velocity;
		horVel.y	= 0;
		//	var inputVector	= Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")).normalized;
		float lookVelDif	= Vector3.Angle (transform.forward, horVel.normalized);
		//	Debug.DrawRay	(transform.position + Vector3.up, horVel.normalized * 5, Color.red);
		//	Debug.DrawRay	(transform.position + Vector3.up, transform.forward * 5, Color.green);
		animator.SetBool	("Grounded", grounded);
		animator.SetFloat 	("VelocityHor", (horVel / velocityDenom).magnitude);
		animator.SetFloat	("LookVelDif", lookVelDif);
		//	Debug.Log	(lookVelDif);
	}
}
