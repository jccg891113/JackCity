using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Subway
{
	public class SubwayPassenger
	{
		public bool valid;
		public long fromStation;
		public long toStation;
		public long player;
		public long train;

		public void Copy (SubwayPassenger passenger)
		{
			this.valid = true;
			this.fromStation = passenger.fromStation;
			this.toStation = passenger.toStation;
			this.player = passenger.player;
			this.train = passenger.train;
		}

		public void GoTrain (long train)
		{
			this.train = train;
		}
	}
}
