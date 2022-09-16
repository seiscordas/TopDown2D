using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kl
{
    public class EnemyAICrontroller : MonoBehaviour
    {
        void Start()
        {
            StartCoroutine(TempWalk());
        }

        void Update()
        {

        }

        IEnumerator TempWalk()
        {
            yield return new WaitForSeconds(1);
            VirtualInputManager.Instance.MoveX = true;
            VirtualInputManager.Instance.MoveY = true;
            VirtualInputManager.Instance.Jump = false;
            Debug.Log("teste");
        }
    }
}
