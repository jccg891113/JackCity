using System;

public interface IFSMCtrl<T>
{
	void Tick (float deltaTime);

	void Goto (T nextStateType, bool allowSameState);
}