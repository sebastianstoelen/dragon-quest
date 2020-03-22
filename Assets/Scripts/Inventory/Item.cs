using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Type")]
    public bool isItem;
    public bool isWeapon;
    public bool isArmor;

    [Header("Details")]
    public Sprite itemSprite;
    public string itemName;
    public string itemDescription;
    public int moneyValue;

    [Header("Item details")]
    public int amountToChange;
    public bool affectHP, affectMP, affectStrenght, affectDefence;

    [Header("Weapon/Armor details")]
    public int weaponPower;
    public int armorPower;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
