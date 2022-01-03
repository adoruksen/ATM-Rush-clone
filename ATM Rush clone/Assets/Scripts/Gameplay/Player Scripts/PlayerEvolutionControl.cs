using DG.Tweening;
using UnityEngine;

public class PlayerEvolutionControl : MonoBehaviour
{
    public static PlayerEvolutionControl instance;

    #region Variables
    LevelManager _levelManager;
    [System.NonSerialized] public GameObject[] collectables;
    [System.NonSerialized] public int characterIndex = 0;
    [System.NonSerialized] public float evolutionProcess = 0;


    PlayerCanvas _playercanvas;
    #region Double Sided Variables
    [System.NonSerialized] public bool isGoodSide;
    [System.NonSerialized] public int interactedGates = 0;

    #endregion

    #endregion
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SetValues();
    }
    void SetValues()
    {
        _levelManager = LevelManager.instance;
        _playercanvas = PlayerCanvas.instance;


        if (_levelManager.runnerSpecs.isOneSided)
        {
            collectables = new GameObject[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                collectables[i] = transform.GetChild(i).gameObject;
            }
        }
    }
    public void OneSidedCharacterSwitch()
    {
        for (int i = 0; i < collectables.Length; i++)
        {
            if (collectables[i].activeInHierarchy)
            {
                if (collectables.Length == i+1)
                {
                    break;
                }
                collectables[characterIndex].SetActive(false);
                collectables[i + 1].SetActive(true);
                PlayerCollideControl.instance.ScalerOnGate(collectables[i + 1]);
                characterIndex = i;
                break;
            }
        }
    }
}
    
