using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    public GameObject key;
    public GameObject[] keySpawnPoint;
    public bool isSpawnKey;

    public Sprite[] enemySprites;

    private void Start()
    {
        SpawnKey();
    }

    public void SpawnKey()
    {
        GameObject temp = Instantiate(key);
        temp.transform.position = keySpawnPoint[Random.Range(0, 4)].transform.position;
        isSpawnKey = true;
    }
}
