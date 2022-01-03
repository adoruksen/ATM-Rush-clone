using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Capsule : MonoBehaviour
{
    float _cycLength = 2;
    void Start()
    {
        transform.DORotate(new Vector3(0, 0, 360), _cycLength * 0.5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
        transform.DOLocalMove(new Vector3(0, +3, 0), _cycLength * 0.5f).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
    }
}
