using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DistanceScript : MonoBehaviour
{
    public static DistanceScript instance;
    private void Awake()
    {
        instance = this;
    }
    [System.NonSerialized] public Image img;
    Text txt;
    float distance;
    float distanceFill;
    void Start()
    {
        img = transform.GetChild(1).GetChild(0).GetComponent<Image>();
        txt = transform.GetChild(0).GetComponent<Text>();
    }

    void Update()
    {
        DetechDistance();
    }
    void DetechDistance()
    {
        txt.text = "distance";
        distance = Finishbilmemnesi.instance.transform.position.z - Player.instance.transform.position.z;
        distanceFill = distance / Finishbilmemnesi.instance.transform.position.z;
        img.fillAmount = 1- distanceFill;
        if (distanceFill<0)
        {
            distanceFill = 0;
            txt.text = "ortakoye geldiniz";
        }
    }
}
