using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Obstacle : MonoBehaviour
{
    Transform currentObj;
    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        Collectable collectable = other.GetComponent<Collectable>();
        if (collectable && collectable.type == InteractableTypes.StackCollectable)
        {
            //int indexList = StackingFront.instance.stackedParts.IndexOf(other.transform);
            //for (int i = indexList; i < StackingFront.instance.stackedParts.Count-1; i++)
            //{
            //    StackingFront.instance.stackedParts.RemoveAt(i);
            //}
            StackingFront.instance.stackedParts.Remove(other.transform);
            Vector3 throwRandom = new Vector3(Random.Range(-2, 2), Random.Range(other.transform.localPosition.y, other.transform.localPosition.y),
                Random.Range(other.transform.position.z + 7, other.transform.position.z + 15));
            other.transform.DOMove(throwRandom, 1).OnComplete(() => other.transform.parent = ForPlacement.instance.transform);
            other.GetComponent<BoxCollider>().isTrigger = false;
        }
        else
        {
            Player.instance.transform.DOMoveZ(Player.instance.transform.localPosition.z - 25, 1f);
         
        }
    }
}

