using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonsterController
{
    int bossAtk = 25;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        SetMaxHealth();
        SetAtk(bossAtk);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void DestroyObj()
    {
        igm.guideText.text = "C L E A R";
        igm.bossHpBar.value = hp;
        igm.bossHpBar.gameObject.SetActive(false);
        base.DestroyObj();

    }
    public void SetMaxHealth()
    {
        igm.bossHpBar.maxValue = hp;
        igm.bossHpBar.value = hp;
        igm.bossHpText.text = hp.ToString();
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        hp = Mathf.Clamp(hp, 0, 1000);
        igm.bossHpBar.value = hp;
        igm.bossHpText.text = hp.ToString();
    }
}
