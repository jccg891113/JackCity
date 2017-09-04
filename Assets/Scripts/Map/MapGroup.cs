using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGroup
{
	public int id;
	public MapItem[] datas;

	public MapGroup (int size)
	{
		this.datas = new MapItem[size * size];
	}

	public void SetId (int id)
	{
		this.id = id;
	}
}

