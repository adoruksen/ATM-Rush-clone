using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [System.NonSerialized] public static PlayerAnimationController instance;

	#region Variables

	[System.NonSerialized] public Animator animator;
	[System.NonSerialized] public PlayerAnimStates currentState;

	#endregion

	private void Awake()
	{
        instance = this;
	}
	private void Start()
	{
		animator = transform.GetChild(0).GetComponent<Animator>();
	}

	public void SetAnimState(PlayerAnimStates state)
	{
		string animName = Enum.GetName(typeof(PlayerAnimStates), state);
		currentState = state;

		if (animator != null)
		{
			animator.Play(animName);
		}
	}
}
