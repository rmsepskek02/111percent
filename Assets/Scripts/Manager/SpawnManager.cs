using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region ÇÊµå
    public GameObject monsterLine;
    public float spawnDelay;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelaySpawn(spawnDelay));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DelaySpawn(float delayTime)
    {
        while (true)
        {
            Instantiate(monsterLine, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(delayTime);
        }
    }
}
