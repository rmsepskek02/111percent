using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region 필드
    public int moveSpeed;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CallAfterDelay());
    }
    IEnumerator CallAfterDelay()
    {
        // 0.1초 지연 후 실행
        yield return new WaitForSeconds(0.1f);
        transform.GetChild(0).gameObject.SetActive(false);
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

    public void OnClickWarrior()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
    }
    public void OnClickArcher()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
    }
}
