using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    private CharacterStats[] gameCharacterStats;

    [Header("General")]
    public GameObject menuGameObject;
    public GameObject[] windows;

    [Header("Character Summary Window")]
    public CharacterSummary[] characterSummaries;

    [Header("Status Window")]
    public GameObject[] characterStatusButtons;
    public Text statusName, statusHP, statusMP, statusStrenght, statusDefence, statusWeapon, statusWeaponPower, statusArmor, statusArmorPower, statusExp;
    public Image statusImage;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        if (menuGameObject.activeInHierarchy)
        {
            CloseMenu();
        }
        else
        {
            OpenMenu();
        }
    }

    private void OpenMenu()
    {
        menuGameObject.SetActive(true);
        LoadCharacterStatsFromGame();
        ShowCharacterSummaries();
        GameManager.instance.gameMenuOpen = true;
    }

    public void CloseMenu()
    {
        for (int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
        }
        menuGameObject.SetActive(false);
        GameManager.instance.gameMenuOpen = false;
    }

    private void LoadCharacterStatsFromGame()
    {
        gameCharacterStats = GameManager.instance.playerStats;
       
    }

    private void ShowCharacterSummaries()
    {
        for (int i = 0; i < gameCharacterStats.Length; i++)
        {
            if (gameCharacterStats[i].gameObject.activeInHierarchy)
            {
                characterSummaries[i].Show();
                characterSummaries[i].UpdateSummaryWithStats(gameCharacterStats[i]);
            }
            else
            {
                characterSummaries[i].Hide();
            }
        }
    }

    public void ToggleWindow(int windowId)
    {
        LoadCharacterStatsFromGame();
        ShowWindow(windowId);
        ShowWindowContent(windowId);
    }

    private void ShowWindow(int windowId)
    {
        for (int i = 0; i < windows.Length; i++)
        {
            if (i == windowId)
            {
                windows[i].SetActive(!windows[i].activeInHierarchy);
            }
            else
            {
                windows[i].SetActive(false);
            }
        }
    }

    private void ShowWindowContent(int windowId)
    {
        if (windowId == 1)
        {
            ShowStatusWindowContent();
        }
    }

    private void ShowStatusWindowContent()
    {
        ShowCharacterStats(0);

        for (int i =0; i < characterStatusButtons.Length; i ++)
        {
            characterStatusButtons[i].SetActive(gameCharacterStats[i].gameObject.activeInHierarchy);
            characterStatusButtons[i].GetComponentInChildren<Text>().text = gameCharacterStats[i].charachterName;
        }
    }

    public void ShowCharacterStats(int player)
    {
        CharacterStats currentPlayerStats = gameCharacterStats[player];

        statusName.text = currentPlayerStats.charachterName;
        statusHP.text = currentPlayerStats.currentHealthPoints.ToString() + "/" + currentPlayerStats.maximumHealthPoints;
        statusMP.text = currentPlayerStats.currentMagicPoints.ToString() + "/" + currentPlayerStats.maximumMagicPoints;
        statusStrenght.text = currentPlayerStats.strength.ToString();
        statusDefence.text = currentPlayerStats.defence.ToString();
        statusWeapon.text = GetNameOrDefault(currentPlayerStats.weaponName);
        statusWeaponPower.text = currentPlayerStats.weaponPower.ToString();
        statusArmor.text = GetNameOrDefault(currentPlayerStats.armorName);
        statusArmorPower.text = currentPlayerStats.armorPower.ToString();
        statusExp.text = (currentPlayerStats.GetExperiencePointsToNextLevel() - currentPlayerStats.currentExperiencePoints).ToString();

        statusImage.sprite = currentPlayerStats.characterSprite;
    }

    private string GetNameOrDefault(string itemName)
    {
        if ("".Equals(itemName))
        {
            return "None";
        } else
        {
            return itemName;
        }
    }
}
