using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPopup : BasePopup
{
    //public UIController uiController;
    [SerializeField] SettingPopup settingPopup;

    //public void Open()
    //{
    //    gameObject.SetActive(true);
    //}
    //public void Close()
    //{
    //    gameObject.SetActive(false);
    //}
    //public bool IsActive()
    //{
    //    return gameObject.activeSelf;
    //}
    public void OnSettingsButton()
    {
        Debug.Log("settings clicked");

        settingPopup.Open();

        Close();

        
    }
    public void OnExitGameButton()
    {
        Debug.Log("exit game");
        Application.Quit();
    }
    public void OnReturnToGameButton()
    {
        Debug.Log("return to game");

        //    uiController.SetGameActive(true);
        Close();
    }
}
