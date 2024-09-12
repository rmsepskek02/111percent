using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    float lineSpeed = 0;
    InGameManager igm;
    // Start is called before the first frame update
    void Start()
    {
        igm = InGameManager.instance;
        lineSpeed = igm.moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
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

    private void OnDestroy()
    {
        igm.moveSpeed = lineSpeed;
    }
}
