using UnityEngine;

public class Tower_Mask : MonoBehaviour
{
    //FIELDS
    //health
    public int health;
    //cost
    public int cost;

    //METHODS
    //Init
    void Start()
    {
        
    }
    //Lose Health
    public void LoseHealth()
    {
        health--;
        
        if(health<=0)
        {
            Die();
        }
    }
    //Die
    void Die()
    {
        Debug.Log("Tower is dead");
        Destroy(gameObject);
    }
}
