using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] int maxHealth = 10;
    int health;

    public static HealthSystem Instance;

    private void Awake() {
        if(Instance == null)
        {
            Instance = this;
        }
        else{
            Destroy(this);
        }

        health = maxHealth;
    }

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

        UIManager.Instance.ShowLoseScreen();
    }


    public float HealthPercentage()
    {
        return ((float)health)/ ((float)maxHealth);
    }
}
