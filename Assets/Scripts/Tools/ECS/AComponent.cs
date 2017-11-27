using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AComponent
{
	public abstract int CTID { get; }
	public AEntity owner;
}
