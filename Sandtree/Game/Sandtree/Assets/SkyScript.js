#pragma strict

var skySetMode	: int;

var sky		: MeshRenderer;
var sun		: Light;
var reverse	: Light;
var low		: Light;

var skArray	: Color [];
var suArray	: Color [];
var reArray : Color [];
var loArray : Color [];

function Start ()
{
	SkySet ();
}

function Update ()
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

function SkySet ()
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