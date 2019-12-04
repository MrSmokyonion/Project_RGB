using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [Header("SFX")]
    public Sound[] m_default;
    public Sound[] m_weapon;
    public Sound[] m_skill;

    [Header("BGM")]
    public Sound[] m_bgm;
    private AudioSource m_bgmAudio;

    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        m_bgmAudio = gameObject.AddComponent<AudioSource>();

        for (int i = 0; i < 3; i++)
        {
            Sound[] arr = null;
            switch (i)
            {
                case 0: arr = m_default; break;
                case 1: arr = m_weapon; break;
                case 2: arr = m_skill; break;
            }
            foreach (Sound s in arr)
            {
                s.source = gameObject.AddComponent<AudioSource>();

                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            }
        }
    }

    private void Start()
    {
        Play("bgm_1");
    }

    #region Play
    public void Play(string name)
    {
        string[] tmp = name.Split('_');
        Sound[] arr = null;
        switch (tmp[0])
        {
            case "default": arr = m_default; break;
            case "sword":
            case "spear":
            case "bow": arr = m_weapon; break;
            case "skill": arr = m_skill; break;

            case "bgm": Play_BGM(name); return;

            default: Debug.LogWarning("SoundManager: " + name + " does not found!"); return;
        }

        Sound s = Array.Find(arr, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("SoundManager: " + name + " does not found!");
            return;
        }

        s.source.Play();
    }
    private void Play_BGM(string name)
    {
        Sound s = Array.Find(m_bgm, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("SoundManager: " + name + " does not found!");
            return;
        }

        if(m_bgmAudio != null)
        {
            m_bgmAudio.Stop();
            Destroy(m_bgmAudio);
        }
        s.source = m_bgmAudio = gameObject.AddComponent<AudioSource>();
        m_bgmAudio.clip = s.clip;

        m_bgmAudio.volume = s.volume;
        m_bgmAudio.pitch = s.pitch;
        m_bgmAudio.loop = s.loop;

        m_bgmAudio.Play();
    }
    #endregion

    #region Stop
    public void Stop(string name)
    {
        string[] tmp = name.Split('_');
        Sound[] arr = null;
        switch (tmp[0])
        {
            case "default": arr = m_default; break;
            case "sword":
            case "spear":
            case "bow": arr = m_weapon; break;
            case "skill": arr = m_skill; break;

            case "bgm": Stop_BGM(name); return;

            default: Debug.LogWarning("SoundManager: " + name + " does not found!"); return;
        }

        Sound s = Array.Find(arr, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("SoundManager: " + name + " does not found!");
            return;
        }

        s.source.Stop();
    }
    private void Stop_BGM(string name)
    {
        if (m_bgmAudio != null)
        {
            m_bgmAudio.Stop();
            Destroy(m_bgmAudio);
        }
    }
    #endregion

    #region SlowMotion
    public void SlowMotion_Descrease()
    {
        if (m_bgmAudio == null || m_bgmAudio.isPlaying == false)
        {
            Debug.LogWarning("SoundManager: BGM does not played!");
            return;
        }
        m_bgmAudio.pitch = 0.5f;
    }
    public void SlowMotion_Increase()
    {
        if (m_bgmAudio == null || m_bgmAudio.isPlaying == false)
        {
            Debug.LogWarning("SoundManager: BGM does not played!");
            return;
        }
        m_bgmAudio.pitch = 1f;
    }
    #endregion
}
