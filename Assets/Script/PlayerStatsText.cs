using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsText : MonoBehaviour
{
    TextMeshProUGUI scoreTextUI;
    float score;

    public float Score   {
        get        {
            return this.score;
        }
        set        {
            this.score = value;
            UpdateScoreTextUI();
        }
    }
    // Start is called before the first frame update
    void Start()   {

        // Get the Text UI component of thi gameObject
        scoreTextUI = GetComponent<TextMeshProUGUI>();
    }

    // Function to update the score text UI
    void UpdateScoreTextUI()    {
        string scoreStr = string.Format("{0:0}", score);
        scoreTextUI.text = scoreStr;
    }
}
