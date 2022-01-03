using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CompletePanel : MonoBehaviour
{
	public static CompletePanel instance;

	#region Variables 

	GameObject multiplierArrow;
	int multiplyCount = 1;
	GameObject b_getMultiply;
	Text multiplyText;
	GameObject b_getNormal;
	GameObject t_levelEarn;
	GameObject b_fail;
	GameObject p_BG;
	GameObject t_statusText;
	GameObject img_multiply;

	#endregion

	private void Awake()
	{
		instance = this;
		SetValues(); 
	}
	void SetValues()
	{
		multiplierArrow = transform.GetChild(4).GetChild(1).gameObject;
		b_getMultiply = transform.GetChild(2).gameObject;
		multiplyText = b_getMultiply.transform.GetChild(0).GetComponent<Text>();
		b_getNormal = transform.GetChild(5).gameObject;
		t_levelEarn = transform.GetChild(6).gameObject;
		b_fail = transform.GetChild(3).gameObject;
		p_BG = transform.GetChild(0).gameObject;
		t_statusText = transform.GetChild(1).gameObject;
		img_multiply = transform.GetChild(4).gameObject;
	}
	public void FailedButtonHandle()
	{
		StartCoroutine(SceneLoadDelay());
	}
	public void GetButtonHandle()
	{
		UpperPanel.instance.UpdateCoin(LevelManager.instance.levelMoney);
		StartCoroutine(SceneLoadDelay());
	}
	public void MultiplierGetButtonHandle()
	{
		multiplierArrow.transform.DOKill();
		int multiplyCount = 1;

		UpperPanel.instance.UpdateCoin(LevelManager.instance.levelMoney * multiplyCount);
		StartCoroutine(SceneLoadDelay());
	}
	void ButtonDisable()
	{
		b_getNormal.GetComponent<Button>().interactable = false;
		b_getMultiply.GetComponent<Button>().interactable = false;
		b_fail.GetComponent<Button>().interactable = false;
	}
	IEnumerator SceneLoadDelay(float delay = 1f)
	{
		ButtonDisable();
		SceneLoadLayer.instance.PlaySceneLoadAnimation(false);
		yield return new WaitForSeconds(delay);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void Activator(bool status = true)
	{
		if (status)
		{
			ElephantEvents.instance.LevelCompletedEvent(GameManager.Level);
			LevelManager.gameState = GameState.Finish;
			GameManager.Level++;
			StartCoroutine(PanelOpenDelay());
		}
		else
		{
			ElephantEvents.instance.LevelFailedEvent(GameManager.Level);
			LevelManager.gameState = GameState.Failed;
			StartCoroutine(PanelOpenDelay());
		}

		IEnumerator PanelOpenDelay()
		{
			yield return new WaitForSeconds(1f);

			p_BG.SetActive(true);
			t_statusText.SetActive(true);
			t_levelEarn.SetActive(true);
			t_levelEarn.transform.GetChild(0).GetComponent<Text>().text = LevelManager.instance.levelMoney + string.Empty;

			if (status)
			{
				b_getMultiply.SetActive(true);
				img_multiply.SetActive(true);
				t_statusText.GetComponent<Text>().text = "VICTORY!";

				multiplierArrow.transform.DOLocalMoveX(250, 1.5f).SetLoops(-1, LoopType.Yoyo).OnUpdate(() =>
				{
					if (Mathf.Abs(multiplierArrow.GetComponent<RectTransform>().anchoredPosition.x) >= 190)
					{
						multiplyCount = 2;
					}
					else if (Mathf.Abs(multiplierArrow.GetComponent<RectTransform>().anchoredPosition.x) >= 65)
					{
						multiplyCount = 4;
					}
					else
					{
						multiplyCount = 6;
					}
					multiplyText.text = "Get x" + multiplyCount;
				});


				yield return new WaitForSeconds(1.5f);
				b_getNormal.SetActive(true);
				b_getNormal.transform.GetChild(0).GetComponent<Text>().text = LevelManager.instance.levelMoney + " is enough";
			}
			else
			{
				b_fail.gameObject.SetActive(true);
				t_statusText.GetComponent<Text>().text = "FAILED!";
			}
		}
	}
}
