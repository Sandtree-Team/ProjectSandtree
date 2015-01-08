using UnityEngine;
using System.Collections;

public class EnemyPatrolScript : MonoBehaviour {

	public Transform [] waypoints;
	public float [] pauses;

	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter (Collider col)
	{
		Debug.Log (col.gameObject.tag);
		if (col.gameObject.tag == "PatrolObject")
		{
			PatrolObjectScript informer;
			informer = col.gameObject.GetComponent <PatrolObjectScript>();

			waypoints = informer.waypoints;
			pauses = informer.pauses;
		}
	}
}
