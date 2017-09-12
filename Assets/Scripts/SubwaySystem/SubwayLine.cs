using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Subway
{
	public class SubwayLine
	{
		public long line;
		public List<SubwaySubLine> subLineList;

		public SubwayLine (params long[] stations)
		{
			subLineList = new List<SubwaySubLine> ();
			for (int i = stations.Length - 1, j = 0; j < stations.Length; i++,j++) {
				subLineList.Add (new SubwaySubLine (stations [i], stations [j], 100));
			}
		}
	}
}