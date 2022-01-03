using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [System.NonSerialized] public static PlayerMovement instance;

    #region Variables

    float mouseSensitivity = 1;
    float movementSpeed = 10;
    [System.NonSerialized] public Transform[] otherMovingObjects = new Transform[3];

	#endregion

	private void Awake()
	{
        instance = this;
	}
    private void Start()
    {
        otherMovingObjects[0] = StackingFront.instance.transform;
        otherMovingObjects[1] = PlayerCollideControl.instance.transform;
        otherMovingObjects[2] = DistanceScript.instance.transform;
    }
    private void Update()
    {
        MoveForward();
    }

    public void MovementFunc(float xForce, float yForce)
    {
        Vector3 temp = otherMovingObjects[0].localPosition;
        temp.x += xForce * Time.deltaTime * 1000 * mouseSensitivity;
        temp.x = Mathf.Clamp(temp.x, -2, 2);
        otherMovingObjects[0].localPosition = Vector3.Lerp(otherMovingObjects[0].localPosition, temp, 0.8f);
        for (int i = 0; i < otherMovingObjects.Length; i++)
        {
            Vector3 pos = new Vector3(temp.x, otherMovingObjects[i].localPosition.y);
            otherMovingObjects[i].localPosition = Vector3.Lerp(otherMovingObjects[i].localPosition, pos, 0.8f);
        }
    }

    public void MoveForward()
	{
        if (LevelManager.gameState == GameState.Normal)
        {
            Vector3 pos = transform.localPosition;
            pos.z += movementSpeed * Time.deltaTime;
            transform.localPosition = pos;
        }
    }
}
