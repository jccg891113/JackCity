using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
///    |<------------------X------------------>|
/// ___|_______________________________________|
///  | |                                       |
///  | |                                       |
///  | |                                       |
///  | |                                       |
///  Y |                                       |
///  | |                                       |
///  | |                                       |
///  | |                                       |
/// _|_|_______________________________________|
/// 
/// </summary>
public class MapData
{
	public int baseSize;
	public int x;
	public int y;
	public MapGroup[] datas;

	public MapData (MapInitSize size)
	{
		baseSize = 100;
		int n = 0;
		switch (size) {
		case MapInitSize.SMALL:
			n = 1;
			break;
		case MapInitSize.MIDDLE:
			n = 2;
			break;
		case MapInitSize.LARGE:
			n = 4;
			break;
		}
		x = n;
		y = n;
		int realSize = n * n;
		datas = new MapGroup[realSize];
		for (int i = 0; i < realSize; i++) {
			datas [i] = new MapGroup (baseSize);
			datas [i].SetId (i);
		}
	}

	public void ExtendMap (Direction direction)
	{
		MapGroup[] tmp = new MapGroup[datas.Length];
		datas.CopyTo (tmp, 0);
		switch (direction) {
		case Direction.UP:
			{
				y++;
				datas = new MapGroup[x * y];
				int oldId = 0;
				for (int i = 0; i < x; i++) {
					for (int j = 0; j < y; j++) {
						int id = i * y + j;
						if (j == 0) {
							datas [id] = new MapGroup (baseSize);
						} else {
							datas [id] = tmp [oldId++];
						}
						datas [id].SetId (id);
					}
				}
			}
			break;
		case Direction.Down:
			{
				y++;
				datas = new MapGroup[x * y];
				int oldId = 0;
				for (int i = 0; i < x; i++) {
					for (int j = 0; j < y; j++) {
						int id = i * y + j;
						if (j == y - 1) {
							datas [id] = new MapGroup (baseSize);
						} else {
							datas [id] = tmp [oldId++];
						}
						datas [id].SetId (id);
					}
				}
			}
			break;
		case Direction.LEFT:
			{
				x++;
				int realSize = x * y;
				datas = new MapGroup[realSize];
				for (int i = 0; i < realSize; i++) {
					if (i < y) {
						datas [i] = new MapGroup (baseSize);
					} else {
						datas [i] = tmp [i - y];
					}
					datas [i].SetId (i);
				}
			}
			break;
		case Direction.RIGHT:
			{
				int oldSize = x * y;
				x++;
				int realSize = x * y;
				datas = new MapGroup[realSize];
				for (int i = 0; i < realSize; i++) {
					if (i < oldSize) {
						datas [i] = tmp [i];
					} else {
						datas [i] = new MapGroup (baseSize);
					}
					datas [i].SetId (i);
				}
			}
			break;
		}
	}
}
