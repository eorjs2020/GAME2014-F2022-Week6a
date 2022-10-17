using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Range(1, 4)]
    public int enemyNumber =3;

    private List<GameObject> enemyList;
    private GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        enemyPrefab = Resources.Load<GameObject>("Prefab/Enemy");
        BuildEnemyList();
    }


    public void BuildEnemyList()
    {
        enemyList = new List<GameObject>();
        for(int i = 0; i < enemyNumber; i++)
        {
            var enemy = Instantiate(enemyPrefab);
            enemyList.Add(enemy);
        }
        
    }
}
