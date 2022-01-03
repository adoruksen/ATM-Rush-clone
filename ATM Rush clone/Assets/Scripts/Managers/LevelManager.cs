using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [System.NonSerialized] public static LevelManager instance;
    [System.NonSerialized] public static GameState gameState;

	#region Variables
	[System.NonSerialized] public LevelAssetCreate levelAsset;
	[System.NonSerialized] public RunnerSpecs runnerSpecs;
	[System.NonSerialized] public int levelMoney = 0;


	#endregion
	private void Awake()
	{
        instance = this;
		levelAsset = Resources.Load<LevelAssetCreate>("Scriptables/LevelAsset");
		runnerSpecs = Resources.Load<RunnerSpecs>("Scriptables/RunnerSpecs");
	}

	void Start()
    {
		SceneLoadLayer.instance.PlaySceneLoadAnimation();
    }
}
