using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackingFront : MonoBehaviour
{
    #region Singleton
    public static StackingFront instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    [System.NonSerialized] public List<Transform> stackedParts = new List<Transform>();
    Transform prevObj;
    Transform curObj;
    private float distanceBtweenObj;
    [System.NonSerialized] private float minDistance = 0.025f;
    private float curspeed = 7;
    void Start()
    {
        stackedParts.Add(transform);
    }
    void FollowEachother()
    {
        for (int i = 1; i < stackedParts.Count; i++)
        {
            curObj = stackedParts[i];
            prevObj = stackedParts[i - 1];

            distanceBtweenObj = Vector3.Distance(prevObj.localPosition, curObj.localPosition);

            Vector3 newPos;
            newPos.x = prevObj.localPosition.x;
            newPos.y = stackedParts[0].localPosition.y -0.02f;
            newPos.z = Player.instance.objScale * i;

            float T = Time.deltaTime * distanceBtweenObj/minDistance * curspeed;
            if (T > 0.5f) T = 0.5f;
            curObj.localPosition = Vector3.Lerp(curObj.localPosition, newPos, T);
        }
    }

    void Update()
    {
        FollowEachother();
    }
   
}
