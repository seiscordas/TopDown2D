using kl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IInereractable
{
    [SerializeField] private Item Item;

    private void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
        InputManager.OnInteractPressed -= Interact;
    }

    public void Interact()
    {
        Pickup();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        InputManager.OnInteractPressed += Interact;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InputManager.OnInteractPressed -= Interact;
    }
}
