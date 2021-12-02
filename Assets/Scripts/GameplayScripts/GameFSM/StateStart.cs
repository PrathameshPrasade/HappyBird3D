using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateStart : GameState
{
   #region Singleton
    public static StateStart Instance = null;

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
