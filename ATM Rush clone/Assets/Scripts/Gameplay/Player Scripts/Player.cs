using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [System.NonSerialized] public static Player instance;

    #region Variables
    public float objScale = 2;
    

	#endregion

	private void Awake()
	{
        instance = this;
	}
	void Start()
    {
        SetValues();
    }
    void Update()
    {

    }
    void SetValues()
	{
		
    }
}
