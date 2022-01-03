using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableEvolve : MonoBehaviour
{
    #region singleton
    public static CollectableEvolve instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion
    private void OnTriggerEnter(Collider other)
    {
        Collectable collectable = other.GetComponent<Collectable>();
        if (collectable)
        {
            if (collectable.type == InteractableTypes.GatePositive)
            {
                transform.GetChild(0).GetComponent<PlayerEvolutionControl>().OneSidedCharacterSwitch();
            }
            if (other.GetComponent<Collectable>() && collectable.type == InteractableTypes.StackCollectable)
            {
                PlayerCollideControl.instance.StackInteract(other.gameObject);
            }
        }
    }
    public void EvolveInteract(GameObject objectEvolve)
    {
        PlayerCollideControl.instance.Scaler(StackingFront.instance.stackedParts.Count - 1);
    }
   
}
