#pragma strict

var skySetMode	: int;

var sky		: MeshRenderer;
var sun		: Light;
var reverse	: Light;
var low		: Light;

var sk1	: Color;
var su1	: Color;
var re1	: Color;
var lo1	: Color;

var sk2	: Color;
var su2	: Color;
var re2	: Color;
var lo2	: Color;

function Start ()
{
	SkySet ();
}

function SkySet ()
{
	sky.enabled	= true;
	switch (skySetMode)
	{
		case (0):
			sky.enabled	= false;
			sun.color	= Color.white;
			break;
		case (1):
			sky.material.color	= sk1;
			sun.color			= su1;
			reverse.color		= re1;
			low.color			= lo1;
			break;
		case (2):
			sky.material.color	= sk2;
			sun.color			= su2;
			reverse.color		= re2;
			low.color			= lo2;
			break;
	}
}