using System.Collections;
using UnityEngine;

public class Tower_Ninja : Tower
{
    //FIELDS
    //damage
    public int damage;
    //prefab (shooting item)
    public GameObject prefab_shootItem;
    //shoot interval
    public float interval;


    //METHODS
    //init (start the shooting interval)
    protected override void Start()
    {
        Debug.Log("NINJA");
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
}
