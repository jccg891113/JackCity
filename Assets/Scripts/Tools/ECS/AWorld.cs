using UnityEngine;using System.Collections;using System.Collections.Generic;public abstract class AWorld{	private long entityUIDCounter;	public Dictionary<long, AEntity> entityPool;	public List<ASystem> systemPool;	public AWorld ()	{		entityUIDCounter = 0;		entityPool = new Dictionary<long, AEntity> ();		systemPool = new List<ASystem> ();	}	public void RegSystem (ASystem system)	{        system.SetWorld (this);		systemPool.Add (system);	}    /// <summary>
    /// 世界开始运行
    /// </summary>    public virtual void Begin ()
    {
        for(int i = 0, imax = systemPool.Count; i < imax; i++) {
            systemPool[i].Begin ();
        }
    }    /// <summary>
    /// 世界心跳
    /// </summary>    public virtual void Tick(double delta)
    {
        for (int i = 0, imax = systemPool.Count; i < imax; i++) {
            systemPool[i].Tick (delta);
        }
    }	/// <summary>	/// 注册实体	/// </summary>	public void RegEntity (AEntity entity)	{        entity.SetUID (entityUIDCounter++);
        entityPool.Add (entity.UID, entity);		for (int i = 0, imax = systemPool.Count; i < imax; i++) {			systemPool [i].RegEntity (entity);		}	}	/// <summary>	/// 删除实体	/// </summary>	public void DelEntity (AEntity entity)	{		DelEntity (entity.UID);	}	/// <summary>	/// 通过实体UID删除实体	/// </summary>	public void DelEntity (long entityUID)	{		for (int i = 0, imax = systemPool.Count; i < imax; i++) {			systemPool [i].DelEntity (entityUID);		}	}}