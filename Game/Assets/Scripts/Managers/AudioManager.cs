using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioSource effectAudioSource;
    [SerializeField] AudioSource sceneryAudioSource;

    public void Listen(AudioClip audioClip)
    {
        effectAudioSource.PlayOneShot(audioClip);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        sceneryAudioSource.clip = ResourcesManager.Instance.Load<AudioClip>(scene.name);

        sceneryAudioSource.loop = true;

        sceneryAudioSource.Play();
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
}
