using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    #region ÇÊµå
    public int arrowAtk;
    public int moveSpeed;
    MonsterController mc;
    InGameManager igm;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        igm = InGameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (transform.position.y > 6) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            if (collision.gameObject.name == "BossSlime(Clone)")
            {
                igm.bossHpBar.gameObject.SetActive(true);
            }
            Debug.Log("DAMAGED");
            mc = collision.gameObject.GetComponent<MonsterController>();
            mc.TakeDamage(arrowAtk);
            Destroy(gameObject);
        }
    }

    void Move()
    {
        transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
    }
}
