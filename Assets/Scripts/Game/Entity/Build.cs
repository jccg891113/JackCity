using UnityEngine;
using System.Collections;

public class Build : EntityBase
{
	public CompAge buildAge;

	public Build () : base ()
	{
		buildAge = new CompAge ();
		RegComp (buildAge);
	}
}
