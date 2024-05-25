using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float maxHp;
    [SerializeField] private float currentHp;

    public void TakeDamage (float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            Debug.Log("Player is dead GAME OVER");
        }

    }
}
