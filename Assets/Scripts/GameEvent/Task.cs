using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task
{
	public ManType receiverType;
	public TaskState state;
	public float statePercent;
}