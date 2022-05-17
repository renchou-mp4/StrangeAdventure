using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	private static SoundManager _instance;
	public static SoundManager Instance
    {
        get { return _instance; }
    }

	public string ResourceDir = "Audio";

	private AudioSource audioSource;

	void Awake()
    {
		_instance = this;
		audioSource = GetComponent<AudioSource>();
		audioSource.loop = true;
		audioSource.playOnAwake = false;
    }

	//设置是否静音
	public bool Mute
    {
        get { return audioSource.mute; }
        set { audioSource.mute = value; }
    }
	//设置背景音乐音量
	public float BGVolume
    {
        get { return audioSource.volume; }
        set { audioSource.volume = value; }
    }
	//播放指定BGM
	public void PlayBGM(string name)
    {
		string path = ResourceDir + "/" + name;

		AudioClip ac = Resources.Load<AudioClip>(path);
		audioSource.clip = ac;
		audioSource.Play();
    }
	//停止播放BGM
	public void StopBGM()
    {
		audioSource.clip = null;
		audioSource.Stop();
    }
	//播放指定音效
	public void PlayAudio(string name)
    {
		string path = ResourceDir + "/" + name;
		AudioClip ac = Resources.Load<AudioClip>(path);
		AudioSource.PlayClipAtPoint(ac, Vector2.zero);
    }
}
