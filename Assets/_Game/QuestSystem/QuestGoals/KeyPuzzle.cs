using System;
using UnityEngine;

namespace QuestSystem.QuestGoals
{
    [Serializable]
    public class KeyPuzzle : MonoBehaviour
    {
        [SerializeField] private bool check;
        [SerializeField] private int key;

        public bool Check { get => check; set => check = value; }
        public int Key { get => key; set => key = value; }

        public KeyPuzzle(bool chk, int k)
        {
            check = chk;
            key = k;
        }
    }
}