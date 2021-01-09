using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake() { instance = this; }

    public Spawner spawner;
    public HealthSystem health;
    public CurrencySystem currency;

    void Start()
    {
        GetComponent<HealthSystem>().Init();
        GetComponent<CurrencySystem>().Init();
    }    

}
