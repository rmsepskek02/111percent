using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Actor : MonoBehaviour
{
    #region 필드
    protected InGameManager igm;
    protected Animator animator;
    //MonsterController mc;
    public int atk;

    private int hp = 1000;
    public int Hp
    {
        get => hp;
        protected set => hp = Mathf.Clamp(value, 0, hp);
    }
    #endregion
    protected virtual void Start()
    {
        igm = InGameManager.instance;
        animator = GetComponent<Animator>();
    }
    protected virtual void Update()
    {
        Die();
    }

    // Hp 설정
    public void SetHp(int health)
    {
        Hp = health;
    }

    protected virtual void Die()
    {
        if (Hp <= 0)
        {
            Debug.Log("DIE");
            igm.guideText.text = "F A I L";
            gameObject.SetActive(false);
        }
    }
}
