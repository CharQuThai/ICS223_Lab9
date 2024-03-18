using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasePopup : MonoBehaviour
{

    virtual public void Open()
    {
        //gameObject.SetActive(true);
        if (!IsActive())
        {
            this.gameObject.SetActive(true);
            Messenger.Broadcast(GameEvent.POPUP_OPENED);
        }
        else
        {
            Debug.Log(this + ".Open() – trying to open a popup that is active!");
        }
    }
    virtual public void Close()
    {
        //gameObject.SetActive(false);
        if (IsActive())
        {
            this.gameObject.SetActive(false);
            Messenger.Broadcast(GameEvent.POPUP_CLOSED);
        }
        else
        {
            Debug.Log(this + ".Close() – trying to close a popup that is not active!");
        }
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
