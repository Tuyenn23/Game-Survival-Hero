using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Main Settings:")]
/*    [Range(0, 1)]   
    public float musicVolume = 0.3f;
    /// the sound fx volume
    [Range(0, 1)]
    public float sfxVolume = 1f;
*/
    public float bgVol;

    public SoundData SoundData;

    public AudioSource musicAus;
    public AudioSource sfxAus;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        
    }

    private void Start()
    {
        SettingMusic(PlayerDataManager.Instance.GetMusicBg());
        SettingFxSound(PlayerDataManager.Instance.GetMusic());
        PlayBGM();
    }
    /// <summary>
    /// Play Sound Effect
    /// </summary>
    /// <param name="clips">Array of sounds</param>
    /// <param name="aus">Audio Source</param>
/*    public void PlaySound(AudioClip[] clips, AudioSource aus = null)
    {
        if (!aus)
        {
            aus = sfxAus;
        }

        if (clips != null && clips.Length > 0 && aus)
        {
            var randomIdx = Random.Range(0, clips.Length);
            aus.PlayOneShot(clips[randomIdx], sfxVolume);
        }
    }*/

    /// <summary>
    /// Play Sound Effect
    /// </summary>
    /// <param name="clip">Sounds</param>
    /// <param name="aus">Audio Source</param>
/*    public void PlaySound(AudioClip clip, AudioSource aus = null)
    {
        if (!aus)
        {
            aus = sfxAus;
        }

        if (clip != null && aus)
        {
            aus.PlayOneShot(clip, sfxVolume);
        }
    }*/

    /// <summary>
    /// Play Music
    /// </summary>
    /// <param name="musics">Array of musics</param>
    /// <param name="loop">Can Loop</param>
/*    public void PlayMusic(AudioClip[] musics, bool loop = true)
    {
        if (musicAus && musics != null && musics.Length > 0)
        {
            var randomIdx = Random.Range(0, musics.Length);

            musicAus.clip = musics[randomIdx];
            musicAus.loop = loop;
            musicAus.volume = musicVolume;
            musicAus.Play();
        }
    }*/

    /// <summary>
    /// Play Music
    /// </summary>
    /// <param name="music">music</param>
    /// <param name="canLoop">Can Loop</param>
/*    public void PlayMusic(AudioClip music, bool canLoop)
    {
        if (musicAus && music != null)
        {
            musicAus.clip = music;
            musicAus.loop = canLoop;
            musicAus.volume = musicVolume;
            musicAus.Play();
        }
    }*/

    /// <summary>
    /// Set volume for audiosource
    /// </summary>
    /// <param name="vol">New Volume</param>
    public void SetMusicVolume(float vol)
    {
        if (musicAus) musicAus.volume = vol;
    }

    /// <summary>
    /// Stop play music or sound effect
    /// </summary>
    public void StopPlayMusic()
    {
        if (musicAus) musicAus.Stop();
    }

/*    public void PlayBackgroundMusic()
    {
        PlayMusic(SoundData.backgroundMusicsLobby, true);
    }*/


    // Music background
    public void SettingMusic(bool isOn)
    {
        bgVol = isOn ? 1 : 0;
        musicAus.volume = bgVol;
        musicAus.mute = !isOn;
        //ValueBGMusic = vol;
    }

    private void PlayBGM()
    {
        PlayBGM(SoundData.backgroundMusicsLobby);

    }

    public void PlayBGM(AudioClip audioClip)
    {
        musicAus.loop = true;
        musicAus.clip = audioClip;
        musicAus.volume = 0;
        musicAus.DOKill();
        musicAus.DOFade(bgVol, 1f);
        musicAus.Play();
    }

    // Fx
    public void SettingFxSound(bool isOn)
    {
        var vol = isOn ? 1 : 0;
        sfxAus.volume = vol;
        sfxAus.mute = !isOn;
        /*        fxSoundFootStep.mute = !isOn;*/
        /*        fxSoundFootStep.volume = vol;*/
    }

    public void PlayFxSound(AudioClip clip)
    {
        sfxAus.PlayOneShot(clip);
    }

    #region Cho nhieu Audiosources
    public void PlayFxSound(AudioClip clip, AudioSource audioSource)
    {
        audioSource.PlayOneShot(clip);
    }
    #endregion
}
