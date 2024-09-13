using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance;
    public TextMeshProUGUI distance;
    public TextMeshProUGUI guideText;
    public Slider distanceSlider;
    public float moveSpeed = 1f;
    public float currentDistance = 0f;
    public Slider bossHpBar;
    public TextMeshProUGUI bossHpText;
    public int warriorHp;
    public int archerHp;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
        distance.text = $"{Mathf.RoundToInt(currentDistance)}m";
        if(warriorHp <= 0 && archerHp <= 0)
        {
            guideText.text = "F A I L";
        }
    }

    void CheckDistance()
    {
        if (moveSpeed == 0) return;

        currentDistance += Time.deltaTime;
        distanceSlider.value = currentDistance;
        currentDistance = Mathf.Clamp(currentDistance, 0, 100);

        if (distanceSlider.gameObject.activeSelf == false) return;
        if(distanceSlider.value >= 100)
        {
            distance.gameObject.SetActive(false);
            distanceSlider.gameObject.SetActive(false);
        }
    }
}
