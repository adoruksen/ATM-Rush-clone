using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CurveScripts : MonoBehaviour
{
    public AnimationCurve curve;
    void Start()
    {
        
    }

    void Update()
    {
        Movement();
    }
    void Movement()
    {
        transform.position = new Vector3(transform.position.x, curve.Evaluate(Time.time), transform.position.z);
        Destroy(gameObject, 5);
    }
}
