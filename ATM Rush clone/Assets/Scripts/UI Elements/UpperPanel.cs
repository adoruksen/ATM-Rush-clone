using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections;
public class UpperPanel : MonoBehaviour
{
    public static UpperPanel instance;

    #region Variables 
    [System.NonSerialized] public Text levelText;
    [System.NonSerialized] public Text coinText;

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
        levelText = transform.GetChild(3).GetComponent<Text>();
        coinText = transform.GetChild(2).GetChild(2).GetComponent<Text>();

        coinText.text = GameManager.Coin + string.Empty;
        levelText.text = "Level " + GameManager.Level + string.Empty;
    }
    public void UpdateCoin(int amount)
    {
        int before = GameManager.Coin;
        GameManager.Coin += amount;
        DOTween.To(() => before, x => before = x, GameManager.Coin, 1).OnUpdate(() => coinText.text = before + string.Empty);
    }

    public void RetryButtonHandleEvent()
    {
        ElephantEvents.instance.LevelFailedEvent(GameManager.Level);
        StartCoroutine(Delay());

        IEnumerator Delay()
		{
            SceneLoadLayer.instance.PlaySceneLoadAnimation(false);
            LevelManager.gameState = GameState.Failed;
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
   }
