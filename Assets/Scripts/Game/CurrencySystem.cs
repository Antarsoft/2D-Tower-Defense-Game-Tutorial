using UnityEngine;
using UnityEngine.UI;

public class CurrencySystem : MonoBehaviour
{
    //FIELDS
    //currency txt UI
    public Text txt_Currency;
    //default currency value
    public int defaultCurrency;
    //current currency value
    public int currency;


    //METHODS
    //Init (set the default values)
    public void Init()
    {
        currency = defaultCurrency;
        UpdateUI();
    }
    //Gain currency (input of value)
    public void Gain(int val)
    {
        currency += val;
        UpdateUI();
    }
    //Use currency (input of value)
    public bool Use(int val)
    {
        if (EnoughCurrency(val))
        {
            currency -= val;
            UpdateUI();
            return true;
        }
        else
        {
            return false;
        }
    }
    //Check availability of currency
    public bool EnoughCurrency(int val)
    {
        //Check if the val is equal or more than currency
        if (val <= currency)
            return true;
        else
            return false;
    }
    //Update txt ui
    void UpdateUI()
    {
        txt_Currency.text = currency.ToString();
    }

    public void USE_TEST()
    {
        Debug.Log(Use(3));
    }

}
