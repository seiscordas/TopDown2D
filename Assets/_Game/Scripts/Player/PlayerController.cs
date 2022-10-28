using kl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IDamageable))]
public class PlayerController : MonoBehaviour
{
    private CharacterControl characterControl;
    IDamageable damageable;

    private void Awake()
    {
        characterControl = this.GetComponent<CharacterControl>();
        characterControl.Dead = false;
    }

    void Start()
    {
        damageable = GetComponent<IDamageable>();
        damageable.DeathEvent += OnDeath;
    }

    private void OnDestroy()
    {
        if (damageable != null)
        {
            damageable.DeathEvent -= OnDeath;
        }
    }

    private void OnDeath()
    {
        characterControl.Dead = true;
    }


}
