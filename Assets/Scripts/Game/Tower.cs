using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int health;
    public int cost;

    protected virtual void Start()
    {
        Debug.Log("BASE TOWER");
    }

    //Lose Health
    public virtual void LoseHealth(int amount)
    {
        //health = health - amount
        health-= amount;

        if (health <= 0)
        {
            Die();
        }
    }
    //Die
    protected virtual void Die()
    {
        Debug.Log("Tower is dead");
        Destroy(gameObject);
    }
}
