using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;
    public GameObject[] easyWaypoints;
    public GameObject[] hardWaypoints;
    public GameObject[] compsEasy;
    public GameObject[] compsHard;
    public int score;
    public int level;
    public int hardness;
    public AudioSource musicEasy;
    public AudioSource musicHard;
    public int currentSong=1;
    void Awake()
    {
        if (Instance == null)
        {
            
            DontDestroyOnLoad(gameObject);
            Instance = this;
            musicEasy = GameObject.FindGameObjectWithTag("musicEasy").GetComponent<AudioSource>();
            musicHard = GameObject.FindGameObjectWithTag("musicHard").GetComponent<AudioSource>();
            compsEasy = Resources.LoadAll<GameObject>("Obstacles/easyObstacles");
            compsHard = Resources.LoadAll<GameObject>("Obstacles/hardObstacles");
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic()
    {
        if (musicEasy.isPlaying) return;
            musicHard.Stop();
            musicEasy.Play();
    }
    public void PlayMusicH()
    {
        if (musicHard.isPlaying) return;
        musicEasy.Stop();
        musicHard.Play();
    }

    public void StopMusic()
    {
        musicEasy.Stop();
        musicHard.Stop();
    }
    public void LoadLevel()
    {
        PlayerData tmp = SaveLevel.LoadPlayer();
        level = tmp.level;
        score = tmp.score;
        
    }

}
