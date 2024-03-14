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

    [SerializeField] private UIController ui;
    private int score = 0;

    [SerializeField] private PlayerCharacter playerCharacter;

    private void Start()
    {
        ui.UpdateScore(score);
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
                    WanderingAI ai = enemies[i].GetComponent<WanderingAI>();
                    if (ai != null)
                    {
                        int currentDifficulty = GetDifficulty();
                        ai.SetDifficulty(currentDifficulty);
                    }
                    else
                    {
                        Debug.Log("WanderingAI component not found on enemy prefab.");
                    }
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

    private void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
        Messenger<int>.AddListener(GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
        
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
        Messenger<int>.RemoveListener(GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
    }

    private void OnEnemyDead()
    {
        score++;
        ui.UpdateScore(score);
    }

    private void OnDifficultyChanged(int newDifficulty) 
    {
        Debug.Log("Scene.OnDifficultyChanged(" + newDifficulty + ")");
        for (int i = 0; i < enemies.Length; i++)
        {
            WanderingAI ai = enemies[i].GetComponent<WanderingAI>();
            ai.SetDifficulty(newDifficulty);
        }
    }
    public int GetDifficulty()
    {
        return PlayerPrefs.GetInt("difficulty", 1);
    }

}
