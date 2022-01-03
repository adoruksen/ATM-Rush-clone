using DG.Tweening;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class PlayerCollideControl : MonoBehaviour
{
    public static PlayerCollideControl instance;
    private void Awake()
    {
        instance = this;
    }
    Vector3 scaleObj;
    [System.NonSerialized ]public Vector3 scaleBigObj;
    Vector3 normalScale;
    private void Start()
    {
        scaleObj = new Vector3(.5f, .5f, .5f);
        scaleBigObj = new Vector3(1.5f, 1.5f, 1.5f);
        normalScale = new Vector3(1, 1, 1);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collectable>() != null)
        {
            Collectable collectable = other.GetComponent<Collectable>();
            if (collectable.type == InteractableTypes.StackCollectable)
            {
                StackInteract(other.gameObject);
            }
        }
    }
    public void StackInteract(GameObject obj)
    {
        if (obj.transform.parent != StackingFront.instance.transform.parent)
        {
            obj.GetComponent<Collider>().isTrigger = true;
            obj.transform.parent = StackingFront.instance.transform.parent;
            if (StackingFront.instance.stackedParts.Count <= 1)
            {
                StackingFront.instance.stackedParts.Add(obj.transform);
            }
            else
            {
                StackingFront.instance.stackedParts.Add(obj.transform);
                Transform temp = StackingFront.instance.stackedParts[StackingFront.instance.stackedParts.Count - 1];
                temp.SetAsLastSibling();
                Scaler(StackingFront.instance.stackedParts.Count - 1);
            }
        }
    }
    public void Scaler(int i)
    {
        float timer = 0;
        bool isTriggered = false;
        StackingFront.instance.stackedParts[i].DOScale(scaleBigObj, .1f).OnUpdate(() =>
        {
            timer += Time.deltaTime;
            if (!isTriggered && timer >= .015f && i > 1)
            {
                isTriggered = true;
                Scaler(i-1);
            }
        }).OnComplete(() => StackingFront.instance.stackedParts[i].DOScale(normalScale, .15f));
    }

    public void ScalerOnGate(GameObject objs)
    {
        objs.transform.DOScale(scaleBigObj, .1f).OnComplete(() => objs.transform.DOScale(normalScale, .15f));
    }

    
}

