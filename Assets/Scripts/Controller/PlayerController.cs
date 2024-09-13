using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region 필드
    public int moveSpeed;
    public Animator animator;
    public int atk;
    float time = 0;
    MonsterController mc;
    InGameManager igm;
    [SerializeField] private Slider hpBar;
    [SerializeField] private TextMeshProUGUI hpText;

    private int hp;
    public int Hp
    {
        get => hp;
        private set => hp = Mathf.Clamp(value, 0, hp);
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        igm = InGameManager.instance;
        hp = 100;
        SetMaxHealth(hp);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Die();
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

            if(collision.gameObject.name == "BossSlime(Clone)")
            {
                igm.bossHpBar.gameObject.SetActive(true);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            animator.SetBool("isAttack", false);
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("STAY");
        Debug.Log("COL NAME = " + collision.gameObject.name);

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
    public void SetMaxHealth(int health)
    {
        hpBar.maxValue = health;
        hpBar.value = health;
        hpText.text = health.ToString();
    }

    // 플레이어가 대미지를 받으면 대미지 값을 전달 받아 HP에 반영합니다.
    public void GetDamage(int damage)
    {
        int getDamagedHp = Hp - damage;
        Hp = getDamagedHp;
        hpBar.value = Hp;
        hpText.text = Hp.ToString();
    }
    void Die()
    {
        if(hp <= 0)
        {
            Debug.Log("DIE");
            igm.guideText.text = "F A I L";
            Destroy(gameObject);
        }
    }
}
