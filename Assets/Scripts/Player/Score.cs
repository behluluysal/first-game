using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public static int score;
    public static int score2;
    // Start is called before the first frame update
    //behlul

    // Update is called once per frame
    void Update()
    {
        if(player.position.z != 0 && player.position.z > 0 && player.position.z <= 211f)
        {
            if (GlobalControl.Instance.hardness == 0)
            {
                score2 = score + (int)player.position.z;
                scoreText.text = score2.ToString("0");
            }
            else
            {
                score2 = score + ((int)player.position.z)*2;
                scoreText.text = score2.ToString("0");
            }
        }
    }
}