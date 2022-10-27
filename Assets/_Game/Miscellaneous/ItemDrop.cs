using DialogueSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kl
{
    [Serializable]
    public class ItemDrop : MonoBehaviour
    {
        public static ItemDrop Instance { get; private set; }

        [SerializeField] private GameObject item;
        [SerializeField] private Transform local;

        private void Awake()
        {
            Instance = this;
        }

        public void Drop()
        {
            Instantiate(item, local);
        }
    }
}
