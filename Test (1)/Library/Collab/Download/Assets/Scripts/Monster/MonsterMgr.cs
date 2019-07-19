using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMgr : MonoBehaviour
{
    [Header("Monster Spawn Ctrl")]
    public GameObject[] spawnPoints;   //스폰 포인트

    public GameObject monsterPrefabs;
    public int maxSpawnCount;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        monsterPrefabs = Resources.Load<GameObject>("Monster");    //몬스터 불러옴

        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnMonster()
    {
        
        int count = 0;
        while(true)
        {
            yield return new WaitForSeconds(spawnDelay);

            //딜레이가 지나면 생성
            Transform spawnPos = SetPosition();
            GameObject monster = Instantiate(monsterPrefabs, spawnPos.position, spawnPos.rotation);
            monster.GetComponent<MonsterCtrl>().SetSprite();
            count++;
            Debug.Log("Count : " + count);

            if (count >= maxSpawnCount)
            {
                Debug.Log("StopCoroutione");
                break;
            }
        }
    }

    public Transform SetPosition()
    {
        int spawnPos = 0;
        spawnPos = (int)Random.Range(0, spawnPoints.Length);
        return spawnPoints[spawnPos].GetComponent<Transform>();
    }
}
