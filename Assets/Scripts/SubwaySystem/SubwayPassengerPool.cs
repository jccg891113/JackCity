using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Subway
{
	public class SubwayPassengerPool
	{
		public int realCount;
		public List<SubwayPassenger> passengerList = new List<SubwayPassenger> ();

		public SubwayPassengerPool ()
		{
			realCount = 0;
			passengerList = new List<SubwayPassenger> ();
		}

		public void AddPassenger (SubwayPassenger passenger)
		{
			if (realCount < passengerList.Count) {
				foreach (var item in passengerList) {
					if (!item.valid) {
						item.Copy (passenger);
						realCount++;
						break;
					}
				}
			} else {
				passengerList.Add (passenger);
				realCount++;
			}
		}

		public void RemovePassenger (long passenger)
		{
			foreach (var item in passengerList) {
				if (item.player == passenger) {
					item.valid = false;
					realCount--;
					break;
				}
			}
		}
	}
}

