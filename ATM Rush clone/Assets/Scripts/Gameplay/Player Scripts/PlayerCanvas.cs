using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCanvas : MonoBehaviour
{
	public static PlayerCanvas instance;

	#region Variables
	LevelManager _levelManager;
	PlayerEvolutionControl _playerEvolutionControl;
	Text t_evolution;
	[System.NonSerialized] public Image img_fill;
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
		_playerEvolutionControl = PlayerEvolutionControl.instance;
		_levelManager = LevelManager.instance;
		t_evolution = transform.GetChild(0).GetComponent<Text>();
		img_fill = transform.GetChild(1).GetChild(0).GetComponent<Image>();
		img_fill.fillAmount = _playerEvolutionControl.evolutionProcess;
	}
	public void ArrangeCanvasHeight()
	{
		RectTransform rTransform = transform.GetComponent<RectTransform>();
		Vector2 anchored = rTransform.anchoredPosition;
		switch (Mathf.Abs(_playerEvolutionControl.characterIndex))
		{
			case 0:
				anchored.y = 2.2f;
				break;
			case 1:
				anchored.y = 2.5f;
				break;
			case 2:
				anchored.y = 2.7f;
				break;
			case 3:
				anchored.y = 3.2f;
				break;
		}
		rTransform.anchoredPosition = anchored;
	}
	public void OneSidedUpdateColorAndName()//Edit for two sided
	{
		for (int i = 0; i < _playerEvolutionControl.collectables.Length; i++)
		{
			if (_playerEvolutionControl.evolutionProcess <= _levelManager.runnerSpecs.oneSidedEvolveLimits[i])
			{
				img_fill.color = _levelManager.runnerSpecs.oneSidedEvolveColors[i];
				t_evolution.text = _levelManager.runnerSpecs.oneSidedEvolutionNames[i];
				break;
			}
		}
	}
	public void DoubleSidedUpdateColorAndName()
	{
		for (int i = 0; i < _playerEvolutionControl.collectables.Length; i++)
		{
			//if (_playerEvolutionControl.evolutionProcess)
			//{

			//}
		}
	}
}
