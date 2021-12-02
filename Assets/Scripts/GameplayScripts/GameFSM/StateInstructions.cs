using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateInstructions : GameState
{
    #region Singleton
    public static StateInstructions Instance = null;

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
