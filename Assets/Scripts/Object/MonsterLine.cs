using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLine : MonoBehaviour
{
    #region 필드
    public Monster monster1;
    public Monster monster2;
    public Monster bossMonster;
    public int possibility;
    public Vector3 moveDir = Vector3.down;

    InGameManager igm;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        igm = InGameManager.instance;
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckYPosition();
    }

    void Move()
    {
        transform.position += moveDir * igm.moveSpeed * Time.deltaTime;
    }

    void Spawn()
    {
        if (igm.currentDistance == 100)
        {
            BossSpawn();
        }
        else
        {
            // 특정 오브젝트의 자식 오브젝트들을 순회하면서 오브젝트 소환
            foreach (Transform child in transform)
            {
                if (RandomSpawn() > possibility) { continue; }
                // 자식의 위치에서 랜덤으로 A 또는 B 오브젝트 소환
                Monster spawnMonster = Random.Range(0, 2) == 0 ? monster1 : monster2;
                Instantiate(spawnMonster.monsterPrefab, child);
            }
        }
    }

    void BossSpawn()
    {
        Monster spawnMonster = bossMonster;
        Instantiate(spawnMonster.monsterPrefab, this.gameObject.transform);
    }

    // 백분율 확률적으로 소환하는지 마는지
    int RandomSpawn()
    {
        int randomValue = Random.Range(1, 101);
        return randomValue;
    }

    void CheckYPosition()
    {
        if(transform.position.y < -6) { 
            Destroy(gameObject);
        }
    }
}
