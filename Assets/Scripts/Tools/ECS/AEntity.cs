using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEntity
{
    public long UID { get; private set; }
	public HashSet<int> compHash;
	public Dictionary<int, AComponent> componentPool;

    public void SetUID(long UID)
    {
        this.UID = UID;
    }

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
