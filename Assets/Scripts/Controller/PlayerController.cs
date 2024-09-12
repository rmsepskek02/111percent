using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region 필드
    public int moveSpeed;
    public Animator animator;
    public int atk;
    MonsterController mc;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        float x = transform.position.x;
        float xPos = Mathf.Clamp(x, -1.8f, 1.8f);
        transform.position = new Vector2(xPos, -2.5f);
    }

    //TODO 따로 하위오브젝트 만들어서 전투 관련으로 Collosion 수정
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            mc = collision.gameObject.GetComponent<MonsterController>();
            animator.SetBool("isAttack", true);
            
            //StartCoroutine(testDestroy(collision.gameObject));
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            animator.SetBool("isAttack", false);
        }
    }

    public void OnAttackAnimEvent()
    {
        Debug.Log("mc = " + mc);
        mc.TakeDamage(atk);
        Debug.Log("ATTACK");
    }

    IEnumerator testDestroy(GameObject go)
    {
        yield return new WaitForSeconds(3f);
        Destroy(go);
    }
}
