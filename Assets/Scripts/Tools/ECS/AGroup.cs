using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AGroup
{
	public HashSet<int> careCompHash;

	public HashSet<long> entityUIDHash;
	public List<AEntity> entityList;

	public void RegEntity (AEntity entity)
	{
		if (careCompHash.IsSubsetOf (entity.compHash)) {
			entityUIDHash.Add (entity.UID);
			entityList.Add (entity);
		}
	}

	public void DelEntity (long entityUID)
	{
		if (entityUIDHash.Contains (entityUID)) {
			entityUIDHash.Remove (entityUID);
			for (int i = 0, imax = entityList.Count; i < imax; i++) {
				if (entityList [i].UID == entityUID) {
					entityList.RemoveAt (i);
					break;
				}
			}
		}
	}
}
