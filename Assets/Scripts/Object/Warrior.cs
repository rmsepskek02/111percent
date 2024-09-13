using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Warrior : Actor<Warrior>
{
    #region ÇÊµå
    public int warriorHp;
    public int warriorArmor;
    #endregion
    protected override void Start()
    {
        base.Start();
        SetHp(warriorHp);
        igm.warriorHp = warriorHp;
        SetMaxHp(Hp);
    }
    protected override void Update()
    {
        base.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            mc = collision.gameObject.GetComponent<MonsterController>();
            animator.SetBool("isAttack", true);

            if (collision.gameObject.name == "BossSlime(Clone)")
            {
                igm.bossHpBar.gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            animator.SetBool("isAttack", false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Stay");
        if (collision.gameObject.CompareTag("Monster"))
        {
            time += Time.deltaTime;
            if (time > 1f)
            {
                Debug.Log("DAMAGED");
                GetDamage(mc.Atk - warriorArmor);
                igm.warriorHp = Hp;
                time = 0;
            }
        }
    }
    protected override void Die()
    {
        if(igm.archerHp > 0)
            transform.parent.GetChild(1).gameObject.SetActive(true);
        base.Die();
    }

    public void OnAttackAnimEvent()
    {
        mc.TakeDamage(atk);
    }
}
