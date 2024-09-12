using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region ÇÊµå
    InGameManager igm;
    public GameObject monsterLine;
    public float spawnDelay;
    float time = 0;
    bool isBoss = false;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        igm = InGameManager.instance;
        //StartCoroutine(DelaySpawn(spawnDelay));
    }

    // Update is called once per frame
    void Update()
    {
        SpawnMonterLine();
    }

    IEnumerator DelaySpawn(float delayTime)
    {
        while (true)
        {
            if (igm.moveSpeed == 0) yield return null;
            Instantiate(monsterLine, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(delayTime);
        }
    }

    void SpawnMonterLine()
    {
        if (igm.moveSpeed == 0) return;
        if (isBoss == true) return;

        if (igm.currentDistance == 10)
        {
            Instantiate(monsterLine, transform.position, Quaternion.identity);
            isBoss = true;
        }

        if (igm.currentDistance >= 5) return;

        time += Time.deltaTime;
        if (time > 2f)
        {
            Instantiate(monsterLine, transform.position, Quaternion.identity);
            time = 0;
        }
    }
}
