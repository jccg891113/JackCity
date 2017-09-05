using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : IMan
{
	#region Properties

	public Sex sex{ get; private set; }

	public int age{ get; set; }

	public ManType work{ get; set; }

	public int posX{ get; set; }

	public int posY{ get; set; }

	public bool working{ get; set; }

	#endregion

	#region Constructors

	public Worker (Sex sex, int age)
	{
		this.sex = sex;
		this.age = age;
		this.posX = 0;
		this.posY = 0;
		this.work = ManType.WORKER;
		this.working = false;
	}

	#endregion
}

