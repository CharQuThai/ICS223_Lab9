using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingPopup : BasePopup
{
    [SerializeField] private TextMeshProUGUI difficultyLabel;
    [SerializeField] private Slider difficultySlider;
    public UIController uiController;
    [SerializeField] private OptionsPopup optionsPopup;


    public void Start()
    {

    }

    public void OnOKButton()
    {
        Debug.Log("OK button clicked");

        if (uiController != null)
        {
            optionsPopup.Open();
            PlayerPrefs.SetInt("difficulty", (int)difficultySlider.value);
        }

        Close();
        Messenger<int>.Broadcast(GameEvent.DIFFICULTY_CHANGED, (int)difficultySlider.value);
    }

    public void OnCancelButton()
    {
        Debug.Log("Cancel button clicked");

        if (uiController != null)
        {
            optionsPopup.Open();
        }

        Close();
    }

    public void UpdateDifficulty(float difficulty)
    {
        difficultyLabel.text = "Difficulty: " +((int)difficulty).ToString();
    }

    public void OnDifficultyValueChanged(float difficulty)
    {
        UpdateDifficulty(difficulty);
    }

    override public void Open()
    {
        base.Open();
        //gameObject.SetActive(true);
        difficultySlider.value = PlayerPrefs.GetInt("difficulty", 1);
        UpdateDifficulty(difficultySlider.value);
    }




    
}
