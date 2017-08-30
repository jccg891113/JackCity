using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMBaseState<T, M> : IFSMState<T> where M : IFSMCtrl<T>
{
	#region Fields

	protected readonly M _ctrl;
	private float _runningBeforeTime;
	private float _runningTime;

	#endregion

	public T StateType{ get; private set; }

	#region Constructors

	public FSMBaseState (T stateType, M controller)
	{
		this.StateType = stateType;
		this._ctrl = controller;
		_runningTime = 0;
	}

	#endregion

	#region Methods

	public void _Enter ()
	{
		ResetRunningTime ();
		this.Enter ();
	}

	private void ResetRunningTime ()
	{
		_runningBeforeTime = -1;
		_runningTime = 0;
	}

	protected virtual void Enter ()
	{
	}

	public void _Tick (float delta)
	{
		_runningBeforeTime = _runningTime;
		_runningTime += delta;
		this.Tick (delta);
	}

	protected virtual void Tick (float delta)
	{
	}

	protected bool AtTimePoint (float time)
	{
		return _runningBeforeTime < time && time <= _runningTime;
	}

	public void _Leave ()
	{
		this.Leave ();
	}

	protected virtual void Leave ()
	{
	}

	protected void Goto (T nextStateType)
	{
		_ctrl.Goto (nextStateType, false);
	}

	#endregion
}
