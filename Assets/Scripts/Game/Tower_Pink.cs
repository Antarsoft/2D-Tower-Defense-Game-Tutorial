using System.Collections;
using UnityEngine;

public class Tower_Pink : Tower
{
    //FIELDS
    //Income value
    public int incomeValue;
    //Interval for income
    public float interval;
    //Coin image object
    public GameObject obj_coin;


    //METHODS
    //Init
    protected override void Start()
    {
        Debug.Log("PINK");
        StartCoroutine(Interval());
    }
    //Interval IEnumerator
    IEnumerator Interval()
    {
        yield return new WaitForSeconds(interval);
        //Trigger the income increase
        IncreaseIncome();

        StartCoroutine(Interval());
    }
    //Trigger Income Increase
    public void IncreaseIncome()
    {
        GameManager.instance.currency.Gain(incomeValue);
        StartCoroutine(CoinIndication());
    }  
    //Show coin indication over the tower for short time (0.5 second)
    IEnumerator CoinIndication()
    {
        obj_coin.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        obj_coin.SetActive(false);
    }
}
