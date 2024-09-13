using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    #region 필드
    float lineSpeed = 0;
    public InGameManager igm;
    public GameObject damageText;
    private Animator animator;
    public int hp;
    private int atk;
    public int Atk
    {
        get => atk;
        protected set => atk = value;
    }
    #endregion
    // Start is called before the first frame update
    protected virtual void Start()
    {
        igm = InGameManager.instance;
        lineSpeed = igm.moveSpeed;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        SetDieAnim();
    }
    public void SetAtk(int Attack)
    {
        Atk = Attack;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            igm.moveSpeed = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            igm.moveSpeed = lineSpeed;
        }
    }
    public void SetDieAnim()
    {
        if (hp <= 0)
        {
            animator.SetBool("isDie", true);
        }
    }
    public virtual void TakeDamage(int damage)
    {
        if (hp <= 0) return;
        GameObject _damageText = Instantiate(damageText); // 생성할 텍스트 오브젝트
        _damageText.transform.position = transform.position + new Vector3(0, 0.5f, 0); // 표시될 위치
        _damageText.transform.GetChild(0).GetComponent<DamageText>().damage = damage; // 데미지 전달
        hp -= damage;
        
    }
    protected virtual void DestroyObj()
    {
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        igm.moveSpeed = lineSpeed;
    }
}
