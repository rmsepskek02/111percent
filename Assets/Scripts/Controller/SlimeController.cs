using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonsterController
{
    int slimeAtk = 15;
    protected override void Start()
    {
        base.Start();
        SetAtk(slimeAtk);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
