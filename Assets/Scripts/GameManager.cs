using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public CharacterStats[] playerStats;

    public bool gameMenuOpen, dialogueActive, loadingBetweenAreas;

    [Header("Item management")]
    public Inventory playerInventory;
    public Item[] referenceItems;

    // Start is called before the first frame update
    void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        CheckPlayerMovement();
    }

    private void CheckPlayerMovement()
    {
        if (gameMenuOpen || dialogueActive || loadingBetweenAreas)
        {
            PlayerController.instance.canMove = false;
        } else
        {
            PlayerController.instance.canMove = true;
        }
    }

    public Item GetReferenceItemDetails(string itemName)
    {
        for(int i =0; i < referenceItems.Length; i++)
        {
            if (referenceItems[i].itemName.Equals(itemName))
            {
                return referenceItems[i];
            }
        }

        return null;
    }
}
