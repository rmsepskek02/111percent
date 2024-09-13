using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Actor<Archer>
{
    #region 필드
    public int archerHp;
    public int archerArmor;
    public float atkArrange = 5f;
    public GameObject arrow;
    #endregion
    protected override void Start()
    {
        base.Start();
        SetHp(archerHp);
        igm.archerHp = archerHp;
        SetMaxHp(Hp);
    }
    protected override void Update()
    {
        base.Update();
        ShootArrow();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            mc = collision.gameObject.GetComponent<MonsterController>();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            time += Time.deltaTime;
            if (time > 1f)
            {
                Debug.Log("DAMAGED");
                GetDamage(mc.Atk - archerArmor);
                igm.archerHp = Hp;
                time = 0;
            }
        }
    }
    protected override void Die()
    {
        if (igm.warriorHp > 0)
            transform.parent.GetChild(0).gameObject.SetActive(true);
        base.Die();
    }

    void ShootArrow()
    {
        Vector2 rayDirection = Vector2.up;

        int layerMask = ~(1 << LayerMask.NameToLayer("Arrow") | 1 << LayerMask.NameToLayer("PlayerController"));
        // Ray를 현재 위치에서 위쪽으로 쏘기
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, atkArrange, layerMask);
        // Raycast 결과가 있을 경우
        if (hit.collider != null)
        {
            // 맞은 오브젝트가 "Monster" 태그를 가진 경우
            if (hit.collider.CompareTag("Monster"))
            {
                animator.SetBool("isAttack", true);
            }
            else
            {
                animator.SetBool("isAttack", false);
            }
        }
        else
        {
            animator.SetBool("isAttack", false);
        }
    }

    void CreateArrow()
    {
        Vector3 arrowPos = transform.position + new Vector3(0, 1.0f, 0);
        Instantiate(arrow, arrowPos, Quaternion.identity);
        arrow.GetComponent<Arrow>().arrowAtk = atk;
    }
}

