using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{
    public static InGameManager instance;
    public TextMeshProUGUI distance;
    public Slider distanceSlider;
    public float moveSpeed = 1f;
    public float currentDistance = 0f;
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
    }

    void CheckDistance()
    {
        if (moveSpeed == 0) return;

        currentDistance += Time.deltaTime;
        distanceSlider.value = currentDistance;
        currentDistance = Mathf.Clamp(currentDistance, 0, 10);

        if (distanceSlider.gameObject.activeSelf == false) return;
        if(distanceSlider.value >= 10)
        {
            distance.gameObject.SetActive(false);
            distanceSlider.gameObject.SetActive(false);
        }
    }
}
