using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool isOver = false;
    [SerializeField] private Text text;
    private Vector3 loc, loc2;

    void Start()
    {
        Score.score = GlobalControl.Instance.score;
        Collusion.flag = false;
        movement.isGrounded = true;

        text.text = GlobalControl.Instance.level.ToString();

        if (GlobalControl.Instance.level <= 6 && GlobalControl.Instance.currentSong == 1)
            FindObjectOfType<GlobalControl>().PlayMusic();
        else
            FindObjectOfType<GlobalControl>().PlayMusicH();


        GlobalControl.Instance.easyWaypoints = new GameObject[7];
        GlobalControl.Instance.hardWaypoints = new GameObject[7];
        GlobalControl.Instance.easyWaypoints = GameObject.FindGameObjectsWithTag("wayPoint");
        GlobalControl.Instance.hardWaypoints = GameObject.FindGameObjectsWithTag("wayPointHard");
        int[] randHardness = new int[GlobalControl.Instance.level];
        
        for(int i = 0; i<randHardness.Length;i++)
        {
            randHardness[i] = Random.Range(0, 10);
        }
        for(int i = 0; i<10;i++)
        {
            bool flag = true; // true ise easy, false ise hard obje ekle
            for (int j = 0; j < randHardness.Length; j++)
            {
                if(i == randHardness[j])
                {
                    flag = false;
                    break;
                }
            }
            int rand = Random.Range(0, 7);
            loc = GlobalControl.Instance.easyWaypoints[i].transform.position;
            loc2 = GlobalControl.Instance.hardWaypoints[i].transform.position;

            if (flag)
            {
                Instantiate(GlobalControl.Instance.compsEasy[rand], loc, Quaternion.identity);
            }
            else
                Instantiate(GlobalControl.Instance.compsHard[rand], loc, Quaternion.identity);
            Instantiate(GlobalControl.Instance.compsHard[rand], loc2, Quaternion.identity);
        }
    }
    public void EndGame()
    {
        if(!isOver)
        {
            isOver = true;
            Invoke("Restart",2f);
        }
        
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        GlobalControl.Instance.level++;
        SaveLevel.SavePlayer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}