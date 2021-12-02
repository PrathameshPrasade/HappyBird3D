using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Framework;
public class GameState : State
{
    public List<GameObject> m_objectList = new List<GameObject>();
    public override void OnEnter()
    {
        foreach(GameObject go in m_objectList)
        {
            go.SetActive(true);
        }
    }
    public override void FsmUpdate(float a_deltaTime)
    {
        
    }
    public override void FsmFixedUpdate(float a_fixedDeltaTime)
    {

    }
    public override void OnExit()
    {
        foreach(GameObject go in m_objectList)
        {
            go.SetActive(false);
        }
    }
}
