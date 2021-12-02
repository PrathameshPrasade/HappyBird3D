using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    float m_UnScalledTimer = 0.0f;
    float m_Delay = 1.0f;
    bool isGoToGameOverStateCalled = false;
    void OnCollisionEnter(Collision collision)
    {
        Time.timeScale = 0.0f;
        AudioManager.Instance.StopAllAudio();
        AudioManager.Instance.Play(AudioType.Effect,"fail");
        Invoke("GotoGameOverState",1.0f);
    }
    
    void Update()
    {
        if(Time.timeScale==0.0f && !isGoToGameOverStateCalled)
        {
            m_UnScalledTimer += Time.unscaledDeltaTime;
            if(m_UnScalledTimer > m_Delay)
            {
                GoToGameOverState();
            }
        }
    }

    void GoToGameOverState()
    {
        isGoToGameOverStateCalled = true;
        GameFSM.Instance.TransitionTo(StateGameOver.Instance);
    }
}