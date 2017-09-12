using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Subway
{
	public class SubwaySubLine
	{
		public long fromStation;
		public long toStation;
		public double length;

		public SubwaySubLine (long fromS, long toS, double length)
		{
			this.fromStation = fromS;
			this.toStation = toS;
			this.length = length;
		}
	}
}

