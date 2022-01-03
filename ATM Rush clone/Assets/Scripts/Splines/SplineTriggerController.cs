using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineTriggerController : MonoBehaviour
{
    [System.NonSerialized] public static SplineTriggerController instance;
	#region Variables

	#endregion
	private void Awake()
	{
        instance = this;
	}
}
