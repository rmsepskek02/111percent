using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLine : MonoBehaviour
{
    #region 필드
    public GameObject monster1;
    public GameObject monster2;
    public float moveSpeed;
    public int possibility;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    }

    void Spawn()
    {
        // 특정 오브젝트의 자식 오브젝트들을 순회하면서 오브젝트 소환
        foreach (Transform child in transform)
        {
            if (RandomSpawn() > possibility) { continue; }
            // 자식의 위치에서 랜덤으로 A 또는 B 오브젝트 소환
            GameObject spawnMonster = Random.Range(0, 2) == 0 ? monster1 : monster2;
            Instantiate(spawnMonster, child.position, Quaternion.identity);
        }
    }

    // 백분율 확률적으로 소환하는지 마는지
    int RandomSpawn()
    {
        int randomValue = Random.Range(1, 101);
        return randomValue;
    }
}
