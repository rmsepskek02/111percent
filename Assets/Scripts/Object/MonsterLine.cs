using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLine : MonoBehaviour
{
    #region �ʵ�
    public Monster monster1;
    public Monster monster2;
    public float moveSpeed;
    public int possibility;
    public Vector3 moveDir = Vector3.down;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
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
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    void Spawn()
    {
        // Ư�� ������Ʈ�� �ڽ� ������Ʈ���� ��ȸ�ϸ鼭 ������Ʈ ��ȯ
        foreach (Transform child in transform)
        {
            if (RandomSpawn() > possibility) { continue; }
            // �ڽ��� ��ġ���� �������� A �Ǵ� B ������Ʈ ��ȯ
            Monster spawnMonster = Random.Range(0, 2) == 0 ? monster1 : monster2;
            Instantiate(spawnMonster.monsterPrefab, child);
        }
    }

    // ����� Ȯ�������� ��ȯ�ϴ��� ������
    int RandomSpawn()
    {
        int randomValue = Random.Range(1, 101);
        return randomValue;
    }

    void CheckYPosition()
    {
        if(transform.position.y < -6) { Destroy(gameObject); }
    }
}
