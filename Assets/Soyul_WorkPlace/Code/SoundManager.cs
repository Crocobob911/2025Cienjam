using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //[SerializeField] private AudioClip bgmClip;
    //private AudioSource bgmPlayer;

    public static SoundManager instance;
    [SerializeField] private AudioClip[] sfxClips;
    private AudioSource[] sfxPlayers;

    private void Awake()
    {
        //bgmPlayer = gameObject.AddComponent<AudioSource>();
        //bgmPlayer.clip = bgmClip;

        instance = this;

        sfxPlayers = new AudioSource[sfxClips.Length];
        for (int i = 0; i < sfxClips.Length; i++)
        {
            sfxPlayers[i] = gameObject.AddComponent<AudioSource>();
            sfxPlayers[i].clip = sfxClips[i];
        }
    }

    //private void Start()
    //{
    //    PlayBGM();
    //}

    //private void PlayBGM()
    //{
    //    bgmPlayer.loop = true;
    //    bgmPlayer.Play();
    //}

    public void PlaySFX(int index)
    {
        sfxPlayers[index].volume = PlayerPrefs.GetFloat("SoundVolume", 0.2f);
        sfxPlayers[index].Play();
    }
}