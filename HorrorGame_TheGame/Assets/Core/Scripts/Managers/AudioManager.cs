using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    [SerializeField] private float masterVolume = 100f;
    public float MasterVolume { get { return masterVolume; } set { masterVolume = value; } }

    [SerializeField] private float musicVolume = 100f;
    public float MusicVolume { get { return musicVolume; } set { musicVolume = value; } }

    [SerializeField] private float soundEffectsVolume = 100f;
    public float SoundEffectsVolume { get { return soundEffectsVolume; } set { soundEffectsVolume = value; } }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void SetVolume(string soundName, float soundValue)
    {
        float normalizedValue = Mathf.InverseLerp(0, 100, soundValue);
        float result = Mathf.Lerp(-80f, 0, normalizedValue);

        audioMixer.SetFloat(soundName, result);
    }
}
