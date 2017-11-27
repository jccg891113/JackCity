using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASystem
{
    public AWorld World { get; private set; }
	public AGroup gro;

    public void SetWorld(AWorld world)
    {
        this.World = world;
    }

    public abstract void Begin ();

	public abstract void Tick (double delta);
}
