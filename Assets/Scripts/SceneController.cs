using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    private GameObject[] enemies;
    private Vector3 spawnPoint = new Vector3(0, 0, 5);

    [SerializeField] 
    private GameObject iguana;
    private GameObject[] iguanaCount;

    private Vector3 iguanaSpawnPoint = new Vector3(9, 0, 5);

    private int spawnIguana = 10;
    private int spawnCount = 3;

    private void Start()
    {
        enemies = new GameObject[spawnCount];
        iguanaCount = new GameObject[spawnIguana];
    }

    // Update is called once per frame
    void Update()
    {

            for (int i = 0; i < spawnCount; i++) {
                if (enemies[i] == null)
                {
                    enemies[i] = Instantiate(enemyPrefab) as GameObject;
                    enemies[i].transform.position = spawnPoint;
                    float angle = Random.Range(0, 360);
                    enemies[i].transform.Rotate(0, angle, 0);
                }
            }

        for (int i = 0; i < spawnIguana; i++)
        {
            if (iguanaCount[i] == null)
            {
                iguanaCount[i] = Instantiate(iguana) as GameObject;
                iguanaCount[i].transform.position = iguanaSpawnPoint;
                float angle = Random.Range(0, 360);
                iguanaCount[i].transform.Rotate(0, angle, 0);
            }
        }
    }
}
