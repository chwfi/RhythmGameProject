using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Percentage : MonoBehaviour
{
    private TextMeshProUGUI _percentageText;

    private void Awake() 
    {
        _percentageText = transform.GetComponent<TextMeshProUGUI>();
    }

    public float songDuration = 150f; // 노래 총 시간 (150초)
    private float elapsedTime = 0f; // 경과 시간

    void Update()
    {
        // 경과 시간 계산
        elapsedTime += Time.deltaTime;

        // 0에서 100까지의 비율 계산
        float progressPercentage = Mathf.Clamp((elapsedTime / songDuration) * 100f, 0f, 100f);

        // 텍스트 업데이트
        _percentageText.text = progressPercentage.ToString("F0"); 
    }
}
