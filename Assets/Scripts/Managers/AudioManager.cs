using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : BaseManager {

    public AudioManager(GameFacade facade) : base(facade)
    {

    }

    private const string path_prefix = "Sounds/";

    private GameObject objAudioSource;
    private AudioSource bgAudioSource;//背景音乐
    private AudioSource audioSource;//其他音乐

    public const string sound_Alert = "Alert";
    public const string sound_ArrowShoot = "ArrowShoot";
    public const string sound_Bg_fast = "Bg(fast)";
    public const string sound_Bg_moderate = "Bg(moderate)";
    public const string sound_ButtonClick = "ButtonClick";
    public const string sound_Miss = "Miss";
    public const string sound_ShootPerson = "ShootPerson";
    public const string sound_Timer = "Timer";

   private AudioClip LoadSound(string soundName)
    {
        return Resources.Load<AudioClip>(path_prefix + soundName);
    }

    public override void OnInit()
    {
        base.OnInit();
        objAudioSource = new GameObject("AudioSource(GameObject)");
        bgAudioSource = objAudioSource.AddComponent<AudioSource>();
        audioSource = objAudioSource.AddComponent<AudioSource>();
        bgAudioSource.volume = 0.3f;
        _PlaySound(bgAudioSource, LoadSound(sound_Bg_moderate), true);
    }


    /// <summary>
    /// 播放声音
    /// </summary>
    /// <param name="_audioSource">音源</param>
    /// <param name="_clip">音乐资源</param>
    /// <param name="_isLoop">是否循环，默认false</param>
    private void _PlaySound(AudioSource _audioSource, AudioClip _clip, bool _isLoop = false)
    {
        _audioSource.clip = _clip;
        _audioSource.loop = _isLoop;
        _audioSource.Play();
    }

    public void PlayBGSound(string soundName)
    {
        _PlaySound(bgAudioSource, LoadSound(soundName), true);
    }

    public void PlaySound(string soundName)
    {
        _PlaySound(audioSource, LoadSound(soundName));
    }




}
