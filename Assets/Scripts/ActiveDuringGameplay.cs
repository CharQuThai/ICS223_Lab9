using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDuringGameplay : MonoBehaviour
{
    void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_ACTIVE, OnGameActive);
        Messenger.AddListener(GameEvent.GAME_INACTIVE, OnGameInactive);
    }
    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.GAME_ACTIVE, OnGameActive);
        Messenger.RemoveListener(GameEvent.GAME_INACTIVE, OnGameInactive);
    }

    void OnGameActive()
    {
        this.enabled = true; // Enable shooting
        Debug.Log(this + ".OnGameActive is true");
    }

    void OnGameInactive()
    {
        this.enabled = false; // Disable shooting
        Debug.Log(this + ".OnGameActive is false");
    }
}
