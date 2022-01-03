using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    [System.NonSerialized] public static EventManager instance;
	#region Variables

	public event Action MyEvent;

	#endregion
	private void Awake()
	{
		instance = this;
	}

	public void SampleEventListener(bool status)
	{
		MyEvent();
	}
}
