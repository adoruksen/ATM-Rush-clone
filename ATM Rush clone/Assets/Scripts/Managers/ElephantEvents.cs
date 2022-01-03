using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using ElephantSDK;
public class ElephantEvents : MonoBehaviour
{
    public static ElephantEvents instance;
	private void Awake()
	{
		instance = this;
	}
	public void LevelCompletedEvent(int level)
	{
        //Elephant.LevelCompleted(level);
    }
	public void LevelFailedEvent(int level)
	{
        //Elephant.LevelFailed(level);
    }
	public void LevelStartedEvent(int level)
	{
        //Elephant.LevelStarted(level);
    }
}
