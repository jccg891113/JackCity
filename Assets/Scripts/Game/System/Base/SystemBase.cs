using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SystemBase : ASystem
{
	public SystemBase (int[] CTIDArray)
	{
		this.gro = new GroupBase (CTIDArray);
	}
}
