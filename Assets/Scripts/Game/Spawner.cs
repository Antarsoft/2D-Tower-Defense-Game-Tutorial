using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    //list of towers (prefabs) that will instantiate
    public List<GameObject> towersPrefabs;
    //Transform of the spawning towers (Root Object)
    public Transform spawnTowerRoot;
    //list of towers (UI)
    public List<Image> towersUI;
    //id of tower to spawn
    int spawnID=-1;
    //SpawnPoints Tilemap
    public Tilemap spawnTilemap;
    //Tile position
    private Vector3Int tilePos;
    
    void Update()
    {
        if(CanSpawn())
            DetectSpawnPoint();
    }

    bool CanSpawn()
    {
        if (spawnID == -1)
            return false;
        else
            return true;
    }

    void DetectSpawnPoint()
    {
        //Detect when mouse is clicked (first touch clicked)
        if(Input.GetMouseButtonDown(0))
        {
            //get the world space postion of the mouse
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //get the position of the cell in the tilemap
            var cellPosDefault = spawnTilemap.WorldToCell(mousePos);
            //get the center position of the cell
            var cellPosCentered = spawnTilemap.GetCellCenterWorld(cellPosDefault);
            //check if we can spawn in that cell (collider)
            if(spawnTilemap.GetColliderType(cellPosDefault)== Tile.ColliderType.Sprite)
            {
                int towerCost = TowerCost(spawnID);
                //Check if currency is enough to spawn
                if(GameManager.instance.currency.EnoughCurrency(towerCost))
                {
                    //Use the amount of cost from the currency available
                    GameManager.instance.currency.Use(towerCost);
                    //Spawn the tower
                    SpawnTower(cellPosCentered, cellPosDefault);
                    //Disable the collider
                    spawnTilemap.SetColliderType(cellPosDefault, Tile.ColliderType.None);
                }
                else
                {
                    Debug.Log("Not Enough Currency");
                }                               
            }                                  
        }
    }

    public int TowerCost(int id)
    {
        switch(id)
        {
            case 0: return towersPrefabs[id].GetComponent<Tower_Pink>().cost;
            case 1: return towersPrefabs[id].GetComponent<Tower_Mask>().cost;
            case 2: return towersPrefabs[id].GetComponent<Tower_Ninja>().cost;  
            default:return -1;
        }
    }

    void SpawnTower(Vector3 position, Vector3Int cellPosition)
    {
        GameObject tower = Instantiate(towersPrefabs[spawnID],spawnTowerRoot);
        tower.transform.position = position;
        tower.GetComponent<Tower>().Init(cellPosition);

        DeselectTowers();
    }

    public void RevertCellState(Vector3Int pos)
    {
        spawnTilemap.SetColliderType(pos, Tile.ColliderType.Sprite);
    }

    public void SelectTower(int id)
    {
        DeselectTowers();
        //Set the spawnID
        spawnID = id;
        //Highlight the tower
        towersUI[spawnID].color = Color.white;        
    }

    public void DeselectTowers()
    {
        spawnID = -1;
        foreach(var t in towersUI)
        {
            t.color = new Color(0.5f, 0.5f, 0.5f);
        }
    }    


    
}
