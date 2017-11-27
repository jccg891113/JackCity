using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SystemBase : ASystem
{
	public SystemBase (int [] CTIDArray)
	{
		this.careCompHash = new HashSet<int> ();
		for (int i = 0, imax = CTIDArray.Length; i < imax; i++) {
			this.careCompHash.Add (CTIDArray [i]);
		}
		this.entityUIDHash = new HashSet<long> ();
		this.entityList = new List<AEntity> ();
	}
}
