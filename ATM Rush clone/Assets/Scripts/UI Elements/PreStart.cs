using UnityEngine;
using UnityEngine.UI;

public class PreStart : MonoBehaviour
{
	#region Variables

	GameObject upgradeOne;
    GameObject upgradeTwo;
    GameObject upgradeThree;
    Text upgradeOneUpgradeLevelText;
    Text upgradeTwoUpgradeLevelText;
    Text upgradeThreeUpgradeLevelText;
    Text upgradeOneCostText;
    Text upgradeTwoCostText;
    Text upgradeThreeCostText;
    Image upgradeOneImage;
    Image upgradeTwoImage;
    Image upgradeThreeImage;
    int upgradeOneBaseCost = 150;
    int upgradeTwoBaseCost = 200;
    int upgradeThreeBaseCost = 250;
    int upgradeOneIncrease = 25;
    int upgradeTwoIncrease = 50;
    int upgradeThreeIncrease = 75;

	#endregion
	void Start()
    {
		LevelManager.gameState = GameState.BeforeStart;
		FieldsArranger();
        UpgradeSetter();

        upgradeOneImage.sprite = Resources.Load<Sprite>("UpgradeHolder");
        upgradeTwoImage.sprite = Resources.Load<Sprite>("UpgradeHolder");
        upgradeThreeImage.sprite = Resources.Load<Sprite>("UpgradeHolder");
    }
    public void GameStarter()
    {
        LevelManager.gameState = GameState.Normal;
        UpperPanel.instance.transform.GetChild(0).gameObject.SetActive(true);
        UpperPanel.instance.transform.GetChild(1).gameObject.SetActive(false);
        ElephantEvents.instance.LevelStartedEvent(GameManager.Level);
        
        
        gameObject.SetActive(false);
    }
    void FieldsArranger()
	{
        upgradeOne = transform.GetChild(1).gameObject;
        upgradeTwo = transform.GetChild(2).gameObject;
        upgradeThree = transform.GetChild(3).gameObject;
        upgradeOneUpgradeLevelText = upgradeOne.transform.GetChild(1).GetComponent<Text>();
        upgradeTwoUpgradeLevelText = upgradeTwo.transform.GetChild(1).GetComponent<Text>();
        upgradeThreeUpgradeLevelText = upgradeThree.transform.GetChild(1).GetComponent<Text>();
        upgradeOneCostText = upgradeOne.transform.GetChild(3).GetComponent<Text>();
        upgradeTwoCostText = upgradeTwo.transform.GetChild(3).GetComponent<Text>();
        upgradeThreeCostText = upgradeThree.transform.GetChild(3).GetComponent<Text>();
        upgradeOneImage = upgradeOne.transform.GetChild(5).GetComponent<Image>();
        upgradeTwoImage = upgradeTwo.transform.GetChild(5).GetComponent<Image>();
        upgradeThreeImage = upgradeThree.transform.GetChild(5).GetComponent<Image>();
    }
    void UpgradeSetter()
	{
        upgradeOneUpgradeLevelText.text = GameManager.UpgradeOneLevel + string.Empty;
        upgradeTwoUpgradeLevelText.text = GameManager.UpgradeTwoLevel + string.Empty;
        upgradeThreeUpgradeLevelText.text = GameManager.UpgradeThreeLevel + string.Empty;

        upgradeOneCostText.text = upgradeOneBaseCost + (upgradeOneIncrease * (GameManager.UpgradeOneLevel - 1)) + string.Empty;
        upgradeTwoCostText.text = upgradeTwoBaseCost + (upgradeTwoIncrease * (GameManager.UpgradeTwoLevel - 1)) + string.Empty;
        upgradeThreeCostText.text = upgradeThreeBaseCost + (upgradeThreeIncrease * (GameManager.UpgradeThreeLevel - 1)) + string.Empty;
    }
    public void UpdateUpgradeLevel(int upgradeNumber)
	{
		switch (upgradeNumber)
		{
            case 1:
                int cost = upgradeOneBaseCost + (upgradeOneIncrease * (GameManager.UpgradeOneLevel - 1));
                Debug.Log("Upgrade Nr." + upgradeNumber + " cost :: " + cost);
                if (GameManager.Coin >=cost)
				{
                    GameManager.UpgradeOneLevel++;
                    UpperPanel.instance.UpdateCoin(-cost);
                    UpgradeSetter();
				}
                break;
            case 2:
                int cost2 = upgradeTwoBaseCost + (upgradeTwoIncrease * (GameManager.UpgradeTwoLevel - 1));
                Debug.Log("Upgrade Nr." + upgradeNumber + " cost :: " + cost2);
                if (GameManager.Coin >= cost2)
                {
                    GameManager.UpgradeTwoLevel++;
                    UpperPanel.instance.UpdateCoin(-cost2);
                    UpgradeSetter();
                }
                break;
            case 3:
                int cost3 = upgradeThreeBaseCost + (upgradeThreeIncrease * (GameManager.UpgradeThreeLevel - 1));
                Debug.Log("Upgrade Nr." + upgradeNumber + " cost :: " + cost3);
                if (GameManager.Coin >= cost3)
                {
                    GameManager.UpgradeThreeLevel++;
                    UpperPanel.instance.UpdateCoin(-cost3);
                    UpgradeSetter();
                }
                break;
        }
    }
}
