using System.Collections;
using UnityEngine;

public class Tower_Ninja : MonoBehaviour
{
    //FIELDS
    //health
    public int health;
    //damage
    public int damage;
    //prefab (shooting item)
    public GameObject prefab_shootItem;
    //shoot interval
    public float interval;
    //cost
    public int cost;

    //METHODS
    //init (start the shooting interval)
    void Start()
    {
        //start the shooting interval IEnum
        StartCoroutine(ShootDelay());
    }
    //Interval for shooting
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(interval);
        ShootItem();
        StartCoroutine(ShootDelay());
    }
    //Shoot an item
    void ShootItem()
    {
        //Instantiate shoot item
        GameObject shotItem = Instantiate(prefab_shootItem,transform);
        //Set its values  
        shotItem.GetComponent<ShootItem>().Init(damage);
    }
    //Lose health
    public void LoseHealth()
    {
        health--;

        if (health <= 0)
            Die();
    }
    //Die
    public void Die()
    {
        Debug.Log("Tower is dead");
        Destroy(gameObject);
    }
}
