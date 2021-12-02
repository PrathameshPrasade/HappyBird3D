using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    public GameObject m_Obstracle;
    void OnTriggerExit(Collider other)
    {
        UIManager.Instance.AddScore();
        AudioManager.Instance.Play(AudioType.Effect,"success");
        ObstracleController.Instance.PlaceNextObstracle();
        Invoke("DeactivateObstracle",2.0f);
    }

    void DeactivateObstracle()
    {
        m_Obstracle.SetActive(false);
    }
}
