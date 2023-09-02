using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] int health = 10;

    public void GetDamage()
    {
        health--;
        
        if(health <= 0)
        {
            Die();
        }

        //Debug.Log(health);
    }

    void Die()
    {
        Debug.Log("öldün");
    }
}
