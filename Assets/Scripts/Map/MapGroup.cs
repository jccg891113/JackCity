using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGroup
{
	#region Fields

	public int baseSize;
	public MapItem[] datas;

	#endregion

	#region Constructors

	public MapGroup (int size)
	{
		this.baseSize = size;
		this.datas = new MapItem[size * size];
		for (int i = 0, imax = size * size; i < imax; i++) {
			this.datas [i] = new MapItem ();
		}
	}

	#endregion

	#region Methods

	public void SetPos (int x, int y, int totalX, int totalY)
	{
		int xDelta = x * baseSize;
		int yDelta = y * baseSize;
		for (int i = 0; i < baseSize; i++) {
			for (int j = 0; j < baseSize; j++) {
				datas [i * baseSize + j].SetPos (i + xDelta, j + yDelta);
			}
		}
	}

	#endregion
}

