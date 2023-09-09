using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{

    Slider scoreSlider;

    float maxHealth;
    PlayerStatsText textUI;

    public float Score
    {
        get
        {
            return this.scoreSlider.value;
        }
        set
        {
            this.scoreSlider.value = value;
            UpdateScoreSlider(value);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // Get the Slider component of this gameObject
        scoreSlider = GetComponent<Slider>();
        textUI = scoreSlider.GetComponentInChildren(typeof(PlayerStatsText)) as PlayerStatsText;
        

    }

    public float MaxHealth{
        get{
            return this.maxHealth;
        }
        set{
            this.maxHealth = value;
            scoreSlider.maxValue = maxHealth;
            UpdateScoreSlider(value);
        }
    }

    // Function to update the score text UI
    public void UpdateScoreSlider(float newValue)
    {
        //slider value Updating
        scoreSlider.value = newValue;

        //text Updating
        textUI.Score = newValue;
    }

    // Function to add newValue to the score and update the UI
    public void AddScoreSlider(float newValue)
    {
        //slider value Updating
        scoreSlider.value += newValue;

        //text Updating
        textUI.Score += newValue;
    }

    //Decrease Slider by decrease value
    public void DecreaseSlider(float decrease)
    {
        //text Updating
        textUI.Score = scoreSlider.value - decrease;

        scoreSlider.value = scoreSlider.value - decrease;
    }
}
