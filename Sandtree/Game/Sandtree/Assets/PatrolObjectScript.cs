using UnityEngine;
using System.Collections;

public class PatrolObjectScript : MonoBehaviour {

	public Transform [] waypoints;
	public float [] pauses;

	void Start ()
	{
		foreach (Transform waypoint in waypoints)
		{
			waypoint.renderer.enabled = false;
			renderer.enabled = false;
		}
	}
}
