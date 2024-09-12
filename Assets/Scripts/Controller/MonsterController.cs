using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    #region ÇÊµå
    float lineSpeed = 0;
    InGameManager igm;
    private Animator animator;
    public float hp;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        igm = InGameManager.instance;
        lineSpeed = igm.moveSpeed;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            animator.SetBool("isDie", true);
        }
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
    public void TakeDamage(int damage)
    {
        hp -= damage;
    }
    public void DestroyObj()
    {
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        igm.moveSpeed = lineSpeed;
    }
}
