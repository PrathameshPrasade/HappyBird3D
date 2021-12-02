using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;
public class GameFSM : FSM
{
    #region Singleton
    public static GameFSM Instance = null;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        } 
        else 
        {
            Instance = this;
        }	
    }
    #endregion
}

