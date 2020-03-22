using System;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CharacterSummary
{
    private const string HP_PREFIX = "HP: ";
    private const string MP_PREFIX = "MP: ";
    private const string LEVEL_PREFIX = "Level: ";

    public GameObject summaryGameObject;
    public Image characterImage;

    public Text nameText, healthPointsText, magicPointsText, levelText, experienceText;
    public Slider experienceSlider;

    public CharacterSummary()
    {
    }

    public void Show()
    {
        summaryGameObject.SetActive(true);
    }

    public void Hide()
    {
        summaryGameObject.SetActive(false);
    }

    public void UpdateSummaryWithStats(CharacterStats stats)
    {
        nameText.text =stats.charachterName;
        healthPointsText.text = HP_PREFIX + stats.currentHealthPoints + "/" + stats.maximumHealthPoints;
        magicPointsText.text = MP_PREFIX + stats.currentMagicPoints + "/" + stats.maximumMagicPoints;
        levelText.text = LEVEL_PREFIX + stats.currentPlayerLevel;
        experienceText.text = stats.currentExperiencePoints + "/" + stats.GetExperiencePointsToNextLevel();
        experienceSlider.maxValue = stats.GetExperiencePointsToNextLevel();
        experienceSlider.value = stats.currentExperiencePoints;

        characterImage.sprite = stats.characterSprite;
    }
}
