using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Health,AttackPower,MoveSpeed
    public int health,attackPower;
    public float moveSpeed;

    void Update()
    {
        Move();
    }

    //Moving forward
    void Move()
    {
        transform.Translate(-transform.right*moveSpeed*Time.deltaTime);
    }

    //Lose health
    public void LoseHealth()
    {
        //Decrease health value
        health--;
        //Blink Red animation
        StartCoroutine(BlinkRed());
        //Check if health is zero => destroy enemy
        if(health<=0)
            Destroy(gameObject);
    }

    IEnumerator BlinkRed()
    {
        //Change the spriterendere color to red
        GetComponent<SpriteRenderer>().color=Color.red;
        //Wait for really small amount of time 
        yield return new WaitForSeconds(0.2f);
        //Revert to default color
        GetComponent<SpriteRenderer>().color=Color.white;
    }
}
