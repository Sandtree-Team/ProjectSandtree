using UnityEngine;
using System.Collections;

public class CamScript : MonoBehaviour {

	// Use this for initialization

	public PlayerMovement playerMovement;
	public PlayerMelee playerMelee;
	public bool inControl;
	public bool hasTarget;

	public Vector3 camTargPos;
	public Quaternion camTargRot;
	public Vector3 camTargRotV3;
	public Vector3 newTargPos;
	public Quaternion newTargRot;
	public Vector3 camTargPosBase;
	public Quaternion camTargRotBase;

	public float camMoveTime;
	public float camRotTime;
	public string targString;
	public Transform followTarg;
	public RaycastHit rayHit;
	public LayerMask rayMask;
	public Camera camera1;
	public Transform camTrans;
	public Vector3 pointVector;
	public GameObject groundPlane;
		
	public LayerMask obstructionMask;
	public RaycastHit obstructionHit;
	public RaycastHit obstructionHitHold;

	public Shader ShaderHold;
	public Shader transparent;
	public float transparencyValue;
	public float transparencyHold;
	public MeshRenderer obstructionRenderer;

	public bool shouldSend;
	public bool contextLooking;
	public bool contextAvailable;
	
	IEnumerator Start ()
	{
		//	transform.parent	= null;
		//	followTarg	= GameObject.Find (targString).transform;
		//	playerMovement	= followTarg.GetComponent (PlayerMovement);
		//	playerMelee		= followTarg.GetComponent (PlayerMelee);
		groundPlane.SetActive (true);
		camTargRot	= Quaternion.Euler (camTargRotV3);
		camTargPosBase	= camTargPos;
		camTargRotBase	= camTargRot;
		yield return new WaitForSeconds (camRotTime);
		shouldSend	= true;
	}
	
	void Update ()
	{
		transform.position = followTarg.position;
		
		if (Input.GetButtonDown ("ContextLook") && newTargRot.eulerAngles != Vector3.zero && contextAvailable)
		{
			contextLooking	= true;
			camTargPos			= transform.InverseTransformPoint (newTargPos);
			camTargRot			= newTargRot;
			playerMovement.inControl	= false;
			shouldSend	= false;
			playerMovement.lookPoint	= playerMovement.contextLookPoint;
		}
		if (Input.GetButtonUp ("ContextLook"))
		{
			contextLooking	= false;
			camTargPos			= camTargPosBase;
			camTargRot			= camTargRotBase;
			//		newTargPos	= Vector3.zero;
			//		newTargRot	= Vector3.zero;
			playerMovement.inControl	= true;
			shouldSend	= true;
		}
		
		Ray ray	= camera1.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out rayHit, Mathf.Infinity, rayMask))
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
			
			if (shouldSend)
			{
				playerMovement.lookPoint	= pointVector;
			}
		}
		
	/*	if (Physics.Linecast (camTrans.position, (followTarg.position + (Vector3.up * 1)), out obstructionHit, obstructionMask))
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
		*/
		//	camTargRotQuat	= Quaternion.Euler (camTargRot);
		camTrans.localPosition		= Vector3.Lerp  (camTrans.localPosition,    camTargPos, Time.deltaTime / camMoveTime);
		camTrans.localRotation		= Quaternion.Lerp (camTrans.localRotation, camTargRot, Time.deltaTime / camRotTime);
		/*				//Just For Testing Purposes

	if (Input.GetKey (KeyCode.E))
	{	transform.eulerAngles.y += (60 * Time.deltaTime);	}
	if (Input.GetKey (KeyCode.Q))
	{	transform.eulerAngles.y -= (60 * Time.deltaTime);	}
*/
	}
}
