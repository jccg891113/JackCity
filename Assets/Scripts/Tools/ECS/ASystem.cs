using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASystem
{
	public AWorld World { get; private set; }

	public HashSet<int> careCompHash;

	public HashSet<long> entityUIDHash;
	public List<AEntity> entityList;

	public void SetWorld (AWorld world)
	{
		this.World = world;
	}

	/// <summary>
	/// 注册实体
	/// </summary>
	public void RegEntity (AEntity entity)
	{
		if (careCompHash.IsSubsetOf (entity.compHash)) {
			entityUIDHash.Add (entity.UID);
			entityList.Add (entity);
		}
	}

	/// <summary>
	/// 删除实体
	/// </summary>
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

	public abstract void Begin ();

	public abstract void Tick (double delta);
}
