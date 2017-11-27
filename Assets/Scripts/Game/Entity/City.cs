using UnityEngine;
using System.Collections;

public class City : EntityBase
{
	public CompAge cityAge;

	public City () : base ()
	{
		cityAge = new CompAge ();
		RegComp (cityAge);
	}
}
