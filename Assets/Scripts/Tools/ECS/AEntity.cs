using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEntity
{
	public abstract long UID { get; }
	public HashSet<int> compHash;
	public Dictionary<int, AComponent> componentPool;

	public void RegComp (AComponent comp)
	{
		if (compHash.Add (comp.CTID)) {
			componentPool [comp.CTID] = comp;
		} else {
			throw new System.Exception ("Duplicate Component Type \"" + ComponentType (comp.CTID) + "\"");
		}
	}

	public T GetComponent<T> (int CTID) where T : AComponent
	{
		return componentPool [CTID] as T;
	}

	protected abstract string ComponentType (int CTID);
}
