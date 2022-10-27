using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Item/Create New Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string id;
    [SerializeField] private string itemName;
    [SerializeField] private int value;
    [SerializeField] private Sprite icon;

    public string Id { get => id; }
    public string ItemName { get => itemName; }
    public int Value { get => value; }
    public Sprite Icon { get => icon; }
}
