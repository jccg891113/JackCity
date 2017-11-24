using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AWorld
{
	private long entityUIDCounter;
	public Dictionary<long, AEntity> entityPool;
	public List<ASystem> systemPool;

	public AWorld ()
	{
		entityUIDCounter = 0;
		entityPool = new Dictionary<long, AEntity> ();
		systemPool = new List<ASystem> ();
	}

	public void RegSystem (ASystem system)
	{
		systemPool.Add (system);
	}

	/// <summary>
	/// 注册实体
	/// </summary>
	public void RegEntity (AEntity entity)
	{
		entityPool.Add (entity.UID, entity);
		for (int i = 0, imax = systemPool.Count; i < imax; i++) {
			systemPool [i].gro.RegEntity (entity);
		}
	}

	/// <summary>
	/// 删除实体
	/// </summary>
	public void DelEntity (AEntity entity)
	{
		DelEntity (entity.UID);
	}

	/// <summary>
	/// 通过实体UID删除实体
	/// </summary>
	public void DelEntity (long entityUID)
	{
		for (int i = 0, imax = systemPool.Count; i < imax; i++) {
			systemPool [i].gro.DelEntity (entityUID);
		}
	}
}
