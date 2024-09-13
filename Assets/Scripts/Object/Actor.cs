using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Actor<T> : MonoBehaviour
{
    #region 필드
    public Slider hpBar;
    public TextMeshProUGUI hpText;
    protected InGameManager igm;
    protected Animator animator;
    protected MonsterController mc;
    public int atk;
    public float time = 0f;

    private int hp = 1000;
    public int Hp
    {
        get => hp;
        protected set => hp = Mathf.Clamp(value, 0, hp);
    }
    #endregion
    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {
        igm = InGameManager.instance;
        animator = GetComponent<Animator>();
    }
    protected virtual void Update()
    {
        transform.position = transform.parent.transform.position;
        if (Hp <= 0)
        {
            Die();
        }
    }

    // Hp 설정
    public void SetHp(int health)
    {
        Hp = health;
    }
    public void SetMaxHp(int health)
    {
        hpBar.maxValue = health;
        hpBar.value = health;
        hpText.text = health.ToString();
    }
    protected virtual void Die()
    {
        Debug.Log("DIE");
        gameObject.SetActive(false);
    }
    public void GetDamage(int damage)
    {
        int getDamagedHp = Hp - damage;
        Hp = getDamagedHp;
        hpBar.value = Hp;
        hpText.text = Hp.ToString();
    }
}
