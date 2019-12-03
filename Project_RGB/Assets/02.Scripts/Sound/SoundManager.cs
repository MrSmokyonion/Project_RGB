using UnityEngine.Audio;
using System;
using UnityEngine;

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

            case "bgm": arr = m_bgm; break;

            default: Debug.LogWarning("SoundManager: " + name + " does not found!"); return;
        }

        Sound s = Array.Find(arr, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("SoundManager: " + name + " does not found!");
            return;
        }

        if (tmp[0] != "bgm")
            s.source.Play();
        else
        {
            m_bgmAudio.Stop();
            m_bgmAudio.clip = s.clip;
            m_bgmAudio.Play();
        }
    }
}
