using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Items/Create a new item")]
public class itemSO : ScriptableObject
{
    public GameObject itemMesh;

    public string itemName;

    public int itemValue;

    public int itemDamage;


    public enum itemTypes{type_glove, type_boots, type_armorSet, type_helmet}
    public itemTypes curType;
}
