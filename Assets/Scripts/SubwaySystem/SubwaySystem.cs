using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Subway
{
	public class SubwaySystem
	{
		public List<SubwayLine> lineList;
		public List<SubwayTrain> trainList;
		public SubwayPassengerPool passengerPool;

		public SubwaySystem ()
		{
			lineList = new List<SubwayLine> ();
			trainList = new List<SubwayTrain> ();
			passengerPool = new SubwayPassengerPool ();
		}

		public void AddLine (params long[] stations)
		{
			SubwayLine newLine = new SubwayLine (stations);
			lineList.Add (newLine);
		}
	}
}
