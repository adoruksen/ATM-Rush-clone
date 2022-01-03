using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    #region Fields
    static int soundLevel;
    static int vibration;
    static int level;
    static int upgradeOneLevel;
    static int upgradeTwoLevel;
    static int upgradeThreeLevel;
    static int coin;
    #endregion
    public static int Level
    {
        get
        {
            if (!PlayerPrefs.HasKey("level"))
            {
                return 1;
            }
            return PlayerPrefs.GetInt("level");
        }
        set
        {
            level = value;
            PlayerPrefs.SetInt("level", level);
        }
    }
    public static int Vibration
    {
        get
        {
            if (!PlayerPrefs.HasKey("vibration"))
            {
                return 1;
            }
            return PlayerPrefs.GetInt("vibration");
        }
        set
        {
            vibration = value;
            PlayerPrefs.SetInt("vibration", vibration);
        }
    }
    public static int Sound
    {
        get
        {
            return PlayerPrefs.GetInt("soundLevel");
        }
        set
        {
            soundLevel = value;
            PlayerPrefs.SetInt("soundLevel", soundLevel);
        }
    }
    public static int UpgradeOneLevel
	{
		get
		{
            return PlayerPrefs.GetInt("upgradeOneLevel");
		}
		set
		{
            upgradeOneLevel = value;
            PlayerPrefs.SetInt("upgradeOneLevel",upgradeOneLevel);
		}
	}
    public static int UpgradeTwoLevel
    {
        get
        {
            return PlayerPrefs.GetInt("upgradeTwoLevel");
        }
        set
        {
            upgradeTwoLevel = value;
            PlayerPrefs.SetInt("upgradeTwoLevel", upgradeTwoLevel);
        }
    }
    public static int UpgradeThreeLevel
    {
        get
        {
            return PlayerPrefs.GetInt("upgradeThreeLevel");
        }
        set
        {
            upgradeThreeLevel = value;
            PlayerPrefs.SetInt("upgradeThreeLevel", upgradeThreeLevel);
        }
    }
    public static int Coin
    {
        get
        {
            return PlayerPrefs.GetInt("coin");
        }
        set
        {
            coin = value;
            PlayerPrefs.SetInt("coin", coin);
        }
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", 1);
        }
        if (!PlayerPrefs.HasKey("vibration"))
        {
            PlayerPrefs.SetInt("vibration", 1);
        }
        if (!PlayerPrefs.HasKey("soundLevel"))
        {
            PlayerPrefs.SetInt("soundLevel", 1);
        }
		if (!PlayerPrefs.HasKey("upgradeOneLevel"))
		{
            PlayerPrefs.SetInt("upgradeOneLevel",1);
		}
        if (!PlayerPrefs.HasKey("upgradeTwoLevel"))
        {
            PlayerPrefs.SetInt("upgradeTwoLevel", 1);
        }
        if (!PlayerPrefs.HasKey("upgradeThreeLevel"))
        {
            PlayerPrefs.SetInt("upgradeThreeLevel", 1);
        }
        if (!PlayerPrefs.HasKey("coin"))
        {
            PlayerPrefs.SetInt("coin", 0);
        }
    }
}
