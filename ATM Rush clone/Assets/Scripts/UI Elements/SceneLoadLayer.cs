using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SceneLoadLayer : MonoBehaviour
{
    public static SceneLoadLayer instance;

	#region Variables

	GameObject img_sceneLoad;

	#endregion

	private void Awake()
	{
		instance = this;
		img_sceneLoad = transform.GetChild(0).gameObject;
	}

	public void PlaySceneLoadAnimation(bool isStart = true)
	{
		if (isStart)
		{
			img_sceneLoad.transform.localScale = new Vector2(75, 75);
			img_sceneLoad.transform.DOScale(0, 1);
		}
		else
		{
			img_sceneLoad.transform.DOScale(75, 1);
		}
	}
}
