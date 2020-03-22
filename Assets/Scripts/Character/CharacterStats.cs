using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public string charachterName;
    public int currentPlayerLevel = 1;
    public int currentExperiencePoints;
    public int[] experiencePointsNeededPerLevel;
    public int maxLevel = 100;
    public int baseExperiencePoints = 1000;

    public int currentHealthPoints;
    public int maximumHealthPoints = 100;

    public int currentMagicPoints;
    public int maximumMagicPoints = 30;
    public int[] magicPointsIncreasePerLevel;

    public int strength;
    public int defence;

    public string weaponName;
    public int weaponPower;

    public string armorName;
    public int armorPower;
    
    public Sprite characterSprite;

    // Start is called before the first frame update
    void Start()
    {
        experiencePointsNeededPerLevel = new int[maxLevel];
        experiencePointsNeededPerLevel[1] = baseExperiencePoints;
        for (int level = 2; level < experiencePointsNeededPerLevel.Length; level++)
        {
            experiencePointsNeededPerLevel[level] = Mathf.FloorToInt(experiencePointsNeededPerLevel[level - 1] * 1.05f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddExperience(500);
        }
    }

    public void AddExperience(int experienceToAdd)
    {
        currentExperiencePoints += experienceToAdd;

        if(currentPlayerLevel >= maxLevel)
        {
            currentExperiencePoints = 0;
        }
    }

    private void CheckLevelUp()
    {
        if(currentPlayerLevel < maxLevel)
        {
            if (currentExperiencePoints >= experiencePointsNeededPerLevel[currentPlayerLevel])
            {
                currentExperiencePoints -= experiencePointsNeededPerLevel[currentPlayerLevel];
                currentPlayerLevel++;
                UpdateCharacterStats();
            }
        }

    }

    private void UpdateCharacterStats()
    {
        AddStrengthOrDefense();
        IncreaseMaximumHealthPoints();
        IncreaseMaximumMagicPoints();
    }

    private void AddStrengthOrDefense()
    {
        if (currentPlayerLevel % 2 == 0)
        {
            strength++;
        } else
        {
            defence++;
        }
    }

    private void IncreaseMaximumHealthPoints()
    {
        maximumHealthPoints = Mathf.FloorToInt(maximumHealthPoints * 1.05f);
        currentHealthPoints = maximumHealthPoints;
    }

    private void IncreaseMaximumMagicPoints()
    {
        maximumMagicPoints = Mathf.FloorToInt(maximumMagicPoints * 1.05f);
        currentMagicPoints = maximumMagicPoints;
    }

    public int GetExperiencePointsToNextLevel()
    {
        return experiencePointsNeededPerLevel[currentPlayerLevel];
    }
}
