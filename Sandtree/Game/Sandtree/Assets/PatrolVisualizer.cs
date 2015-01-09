using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//Written by Michael Bethke
public class PatrolVisualizer : MonoBehaviour
{
	
	public List<Vector3> patrolWaypoints = new List<Vector3> ();
	//public List<float> patrolPauses = new List<float> ();
	public float [] patrolPauses;

	void Start ()
	{
		renderer.enabled = false;
	}

	void OnDrawGizmos ()
	{
		
		int vectorIndex = 0;
		while ( vectorIndex < patrolWaypoints.Count )
		{

			Gizmos.color = new Color ( 0.8F, 0.8F, 0.2F, 0.9F );
			Gizmos.DrawCube ( patrolWaypoints[vectorIndex], new Vector3 ( 0.5f, 0.5f, 0.5f ));
			
			vectorIndex += 1;
		}
	}
}
