using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region ÇÊµå
    public float maxSpeed = 5f;
    public int moveSpeed;
    Rigidbody2D rb;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
}
