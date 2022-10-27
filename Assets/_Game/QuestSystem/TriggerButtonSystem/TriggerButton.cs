using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TriggerButtonSystem
{
    public class TriggerButton : MonoBehaviour
    {
        public static event Action<TriggerButton> OnButtonReached = delegate { };
        [SerializeField] public int buttonKey;

        [SerializeField] private GameObject btnKeyImage;
        [SerializeField] private AudioClip audioClip;
        public GameObject BtnKeyImage { get => btnKeyImage; set => btnKeyImage = value; }
        public AudioClip AudioClip { get => audioClip; set => audioClip = value; }

        protected void OnTriggerEnter2D(Collider2D collider)
        {
            if (!collider.CompareTag("Player"))
                return;
            CheckSequence();
        }

        protected virtual void CheckSequence()
        {
            OnButtonReached?.Invoke(this);            
        }
    }
}
