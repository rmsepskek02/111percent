using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLine : MonoBehaviour
{
    #region �ʵ�
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
        // Ư�� ������Ʈ�� �ڽ� ������Ʈ���� ��ȸ�ϸ鼭 ������Ʈ ��ȯ
        foreach (Transform child in transform)
        {
            if (RandomSpawn() > possibility) { continue; }
            // �ڽ��� ��ġ���� �������� A �Ǵ� B ������Ʈ ��ȯ
            GameObject spawnMonster = Random.Range(0, 2) == 0 ? monster1 : monster2;
            Instantiate(spawnMonster, child.position, Quaternion.identity);
        }
    }

    // ����� Ȯ�������� ��ȯ�ϴ��� ������
    int RandomSpawn()
    {
        int randomValue = Random.Range(1, 101);
        return randomValue;
    }
}
