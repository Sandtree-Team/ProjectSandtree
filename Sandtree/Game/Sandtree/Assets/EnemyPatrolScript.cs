using UnityEngine;
using System.Collections;

public class EnemyPatrolScript : MonoBehaviour {

	public float speed;
	public Transform [] waypoints;
	public float [] pauses;
	public Vector3 targPos;
	GameObject holdObj;
	public float turnTime;
	public float allowence;
	public int waypointInt;

	void Start () {
	
	}

	void Update () {
		MoveTo ();
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

	void MoveTo ()
	{
		Vector3 pos = transform.position;
		pos += (speed * transform.forward * Time.deltaTime);
		transform.position = pos;

		Vector3 turnTargPos = targPos;
		turnTargPos.y = transform.position.y;
		Quaternion curRot = transform.rotation;
		Vector3 relPos = targPos - pos;
		Quaternion targRot = Quaternion.LookRotation (relPos);
		curRot = Quaternion.Slerp (curRot, targRot, Time.deltaTime / turnTime);
		transform.rotation = curRot;

		if (Vector3.Distance (pos, targPos) < allowence)
		{
			Debug.Log (waypoints.Length);
			Debug.Log (waypointInt);
			if (waypoints.Length - 1 > waypointInt)
			{
				waypointInt += 1;
				targPos = waypoints [waypointInt].position;
			}
			else
			{
				waypointInt = 0;
				targPos = waypoints [waypointInt].position;
			}
		}
	}
}
