using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Item/Create New Item")]
public class Item : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private string itemName;
    [SerializeField] private int value;
    [SerializeField] private Sprite icon;
}
