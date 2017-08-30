using System;

public interface IFSMState<T>
{
	T StateType{ get; }

	void _Enter ();

	void _Tick (float delta);

	void _Leave ();
}