using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformSystem : MonoBehaviour
{
    [SerializeField] private List<Transform> points = new();
    [SerializeField] private float movingSpeed = 0f;
    [SerializeField] private int wayPointIndex = 1;
    [SerializeField] private GameObject playerParent;

    [SerializeField] private bool move;//somente pra teste

    void Update()
    {
        MovePlatform();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerParent = collider.transform.parent.gameObject;
            collider.gameObject.transform.parent = gameObject.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.transform.parent = playerParent.transform;
        }
    }

    private void MovePlatform()
    {
        if (transform.position == points[0].position)
        {
            wayPointIndex = 1;
        }
        if (transform.position == points[1].position)
        {
            wayPointIndex = 0;
        }
        if (move)//if somente pra teste
        {
            transform.position = Vector3.MoveTowards(transform.position, points[wayPointIndex].position, Time.deltaTime * movingSpeed);
        }
    }
}
