using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum AudioType {Music = 0, Effect = 1};
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;
    [SerializeField]
    List<Audio> m_lstAudio = new List<Audio> ();
    public AudioSource m_AudioSourceBGMusic, m_AudioSourceEffects;
    void Awake()
    {
        Instance = this;
    }
    public void Play(AudioType a_Type, string a_ID)
    {
        switch(a_Type)
        {
            case AudioType.Music:
                m_AudioSourceBGMusic.clip = GetAudioByID(a_ID);
                m_AudioSourceBGMusic.volume = 0.5f;
                m_AudioSourceBGMusic.loop = true;
                m_AudioSourceBGMusic.Play();
            break;
            case AudioType.Effect:
                m_AudioSourceEffects.clip = GetAudioByID(a_ID);
                m_AudioSourceEffects.volume = 1.0f;
                m_AudioSourceEffects.loop = false;
                m_AudioSourceEffects.Play();
            break;
        }
    }
    
    public void StopAllAudio()
    {
        m_AudioSourceBGMusic.Stop();
        m_AudioSourceEffects.Stop();
    }
    AudioClip GetAudioByID(string a_ID)
    {
        for (int l_index = 0; l_index < Instance.m_lstAudio.Count; l_index++) 
        {
            if (a_ID.Equals (m_lstAudio [l_index].m_AudioID))
                return m_lstAudio [l_index].m_Clip;
        }
        Debug.LogError ("Audio clip with ID : " + a_ID + " not found in list");
        return null;
    }
}
[Serializable]
public class Audio
{
    public string m_AudioID;
    public AudioClip m_Clip;
    
}
