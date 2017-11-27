using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntityBase : AEntity
{
	public EntityBase ()
	{
		compHash = new HashSet<int> ();
		componentPool = new Dictionary<int, AComponent> ();
	}

	protected override string ComponentType (int CTID)
	{
		return ((EComponentType) CTID).ToString ();
	}
}
