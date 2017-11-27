using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupBase : AGroup
{
	public GroupBase (int[] CTID)
	{
		this.careCompHash = new HashSet<int> ();
		for (int i = 0, imax = CTID.Length; i < imax; i++) {
			this.careCompHash.Add (CTID [i]);
		}
		this.entityUIDHash = new HashSet<long> ();
		this.entityList = new List<AEntity> ();
	}
}
