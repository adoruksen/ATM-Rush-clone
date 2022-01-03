using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
	#region Variables
	GameObject p_settings;
	GameObject b_vib;
	GameObject b_sound;
	Text versionText;

	#endregion
	private void Start()
	{
		FieldsArranger();
		SetStartButtons();
	}
	void FieldsArranger()
	{
		p_settings = transform.GetChild(0).gameObject;
		b_vib = p_settings.transform.GetChild(0).GetChild(1).GetChild(2).gameObject;
		b_sound = p_settings.transform.GetChild(0).GetChild(2).GetChild(2).gameObject;
		versionText = transform.GetChild(0).GetChild(0).GetChild(3).GetComponent<Text>();

		versionText.text = "v" + Application.version;
	}
	public void SettingsButtonHandleEvent()
	{
		p_settings.SetActive(true);
	}
	public void ExitButtonHandleEvent()
	{
		p_settings.SetActive(false);
	}
	void SetStartButtons()
	{
		if (GameManager.Vibration == 1)
		{
			b_vib.GetComponent<Image>().sprite = Resources.Load<Sprite>("Other/On_Sprite");
		}
		else
		{
			b_vib.GetComponent<Image>().sprite = Resources.Load<Sprite>("Other/Off_Sprite");
		}
		if (GameManager.Sound == 1)
		{
			b_sound.GetComponent<Image>().sprite = Resources.Load<Sprite>("Other/On_Sprite");
		}
		else
		{
			b_sound.GetComponent<Image>().sprite = Resources.Load<Sprite>("Other/Off_Sprite");
		}
	}
	public void VibrationButtonHandleEvent()
	{
		if (GameManager.Vibration == 1)
		{
			GameManager.Vibration = 0;
			b_vib.GetComponent<Image>().sprite = Resources.Load<Sprite>("Other/Off_Sprite");
		}
		else
		{
			GameManager.Vibration = 1;
			b_vib.GetComponent<Image>().sprite = Resources.Load<Sprite>("Other/On_Sprite");
		}
	}
	public void SoundButtonHandleEvent()
	{
		if (GameManager.Sound == 1)
		{
			GameManager.Sound = 0;
			b_sound.GetComponent<Image>().sprite = Resources.Load<Sprite>("Other/Off_Sprite");
		}
		else
		{
			GameManager.Sound = 1;
			b_sound.GetComponent<Image>().sprite = Resources.Load<Sprite>("Other/On_Sprite");
		}
	}
}