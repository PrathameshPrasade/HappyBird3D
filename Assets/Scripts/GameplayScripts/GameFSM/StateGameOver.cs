using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGameOver : GameState
{
    #region Singleton
    public static StateGameOver Instance = null;

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
    public override void OnEnter()
    {
        base.OnEnter();
        UIManager.Instance.UpdateScoreOnGameOver();
    }
}
