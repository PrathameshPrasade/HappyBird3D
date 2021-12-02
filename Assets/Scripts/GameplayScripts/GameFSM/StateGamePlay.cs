using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGamePlay : GameState
{
    #region Singleton
    public static StateGamePlay Instance = null;

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
        AudioManager.Instance.Play(AudioType.Music,"music");
    }
}
