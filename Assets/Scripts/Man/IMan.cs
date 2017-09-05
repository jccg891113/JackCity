public interface IMan
{
	Sex sex{ get; }

	int age{ get; set; }

	ManType work{ get; set; }

	int posX{ get; set; }

	int posY{ get; set; }

	bool working{ get; set; }
}
