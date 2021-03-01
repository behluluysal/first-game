using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject volumeDown;
    public GameObject volumeUp;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        volumeDown = GameObject.Find("volumeDown");
        volumeUp = GameObject.Find("volumeUp");
        if(GlobalControl.Instance.musicEasy.volume == 0)
        {
            volumeUp.SetActive(true);
            volumeDown.SetActive(false);
        }
        else
        {
            volumeUp.SetActive(false);
            volumeDown.SetActive(true);
        }
            

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + Score.score2;
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }

    public void VolumeDown()
    {
        volumeDown.SetActive(false);
        volumeUp.SetActive(true);
        GlobalControl.Instance.musicEasy.volume = 0f;
        GlobalControl.Instance.musicHard.volume = 0f;
    }
    public void VolumeUp()
    {
        volumeDown.SetActive(true);
        volumeUp.SetActive(false);
        GlobalControl.Instance.musicEasy.volume = 0.4f;
        GlobalControl.Instance.musicHard.volume = 0.4f;
    }
    public void ReturnMenu()
    {
        GlobalControl.Instance.StopMusic();
        SceneManager.LoadScene(0);
    }

}
