using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASystem
{
	public AGroup gro;

	public abstract void Tick (double delta);
}
