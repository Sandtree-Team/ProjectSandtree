using UnityEngine;
using System.Collections;

public class SkyScript : MonoBehaviour {

	public int skySetMode;

	public MeshRenderer sky;
	public Light sun;
	public Light reverse;
	public Light low;

	public Color [] skArray;
	public Color [] suArray;
	public Color [] reArray;
	public Color [] loArray;

	void Start ()
	{
		SkySet ();
	}
	
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.P) && (skySetMode < skArray.Length))
		{
			skySetMode ++;
			SkySet ();
		}
		if (Input.GetKeyDown (KeyCode.O) && (skySetMode > 0))
		{
			skySetMode --;
			SkySet ();
		}
	}
	
	void SkySet ()
	{
		sky.enabled	= true;
		if (skySetMode != 0)
		{
			sky.material.color	= skArray [skySetMode -1];
			sun.color			= suArray [skySetMode -1];
			reverse.color		= reArray [skySetMode -1];
			low.color			= loArray [skySetMode -1];
		}
		else
		{
			sky.enabled	= false;
			sun.color	= Color.white;
		}
	}
}
