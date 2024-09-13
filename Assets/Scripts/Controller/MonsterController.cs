using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    #region ÇÊµå
    float lineSpeed = 0;
    public InGameManager igm;
    private Animator animator;
    public int hp;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            igm.moveSpeed = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
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
