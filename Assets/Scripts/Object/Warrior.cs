using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Warrior : Actor
{
    #region ÇÊµå
    public Slider hpBar;
    public TextMeshProUGUI hpText;
    public int warriorHp;
    MonsterController mc;
    private float time = 0f;
    #endregion
    protected override void Start()
    {
        base.Start();
        SetHp(warriorHp);
        SetMaxHp(Hp);
    }
    protected override void Update()
    {
        base.Update();
        transform.position = transform.parent.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
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
        if (collision.gameObject.CompareTag("Monster"))
        {
            time += Time.deltaTime;
            if (time > 1f)
            {
                Debug.Log("DAMAGED");
                GetDamage(10);
                time = 0;
            }
        }
    }

    public void OnAttackAnimEvent()
    {
        mc.TakeDamage(atk);
    }
    public void SetMaxHp(int health)
    {
        hpBar.maxValue = health;
        hpBar.value = health;
        hpText.text = health.ToString();
    }
    public void GetDamage(int damage)
    {
        int getDamagedHp = Hp - damage;
        Hp = getDamagedHp;
        hpBar.value = Hp;
        hpText.text = Hp.ToString();
    }
}
