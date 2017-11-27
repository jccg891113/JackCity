using UnityEngine;
using System.Collections;

public class CompAge : AComponent
{
	public override int CTID { get { return (int) EComponentType.Age; } }

	public long birthDay;
}
