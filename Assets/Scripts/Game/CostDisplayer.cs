using UnityEngine;

public class CostDisplayer : MonoBehaviour
{
    //FIELDS
    //tower ID
    public int towerID;
    //cost value
    public int towerCost;

    //METHODS
    //Init (Fetch the value from the spawner towers list>
    void Start()
    {
        towerCost = GameManager.instance.spawner.TowerCost(towerID);
        GetComponent<UnityEngine.UI.Text>().text = towerCost.ToString();
    }
}
