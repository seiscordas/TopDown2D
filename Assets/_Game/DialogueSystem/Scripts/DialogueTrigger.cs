using kl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject visualCue;
        [SerializeField] private TextAsset inkJSON;

        private bool playerInRange;

        private void Awake()
        {
            playerInRange = false;
            visualCue.SetActive(false);
            DialogueManager.OnFinishDialogue += DisableCollider;
        }

        private void Update()
        {
            if (playerInRange)
            {
                visualCue.SetActive(true);
            }
            else { visualCue.SetActive(false); }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                InputManger.OnInteractPressed += LoadInkJSON;
                playerInRange = true;
            }
        }

        private void LoadInkJSON()
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                InputManger.OnInteractPressed -= LoadInkJSON;
                playerInRange = false;
            }
        }

        private void DisableCollider()
        {
            GetComponent<Collider>().enabled = false;
        }
    }
}
