using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BackgroundMusicController : MonoBehaviour {

    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameMusic;

    private AudioSource audioSource;

    void Awake () {
        audioSource = GetComponent<AudioSource>();

        Assert.IsNotNull(audioSource); // info w consoli w razie wartosci null dla obiektu
        Assert.IsNotNull(menuMusic);   // UnityEngine.Assertions , Assert ma tez pare innych ciekawych metod... 
        Assert.IsNotNull(gameMusic);
	}
	
	void Update () {
        var clipToPlay = GameManager.Instance.GameStarted ?
            gameMusic : menuMusic;
        PlayMusic(clipToPlay);
	}

    private void PlayMusic(AudioClip clipToPlay)
    {
        if (audioSource.clip != clipToPlay)
        {
            audioSource.clip = clipToPlay;
            audioSource.Play();
        }

    }
}
