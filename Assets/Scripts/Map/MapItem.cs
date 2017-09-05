using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItem
{
	#region Fields

	public int x;
	public int y;
	public int topObjId;

	#endregion

	#region Constructors

	public MapItem ()
	{
	}

	#endregion

	#region Methods

	public void SetPos (int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	#endregion
}

