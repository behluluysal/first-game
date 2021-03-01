using UnityEngine;

public class Collusion : MonoBehaviour
{
    public static bool flag = false;
    public Rigidbody player;
    public movement pm;
    public Score score;
    public GameObject[] list;
    public Rigidbody bcrb;
    public GameObject plane;
    public GameObject finishedPanel;
    public GameObject scoreText;
    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.collider.tag == "Obstacle")
        {
            pm.enabled = false;
            score.enabled = false;
            player.velocity *= 998f / 1000f;
            FindObjectOfType<GameManager>().EndGame();
        }
        if (collision.collider.tag == "detonator" && flag)
        {
            plane = GameObject.FindGameObjectWithTag("detonator");
            Destroy(plane);
            flag = false;
        }
        if (collision.collider.tag == "Breakable")
        {
            list = GameObject.FindGameObjectsWithTag("Breakable");
            foreach (var item in list)
            {

                bcrb = item.GetComponent<Rigidbody>();
                bcrb.isKinematic = false;
                bcrb.useGravity = true;
                if (item.transform.name == "Breakable (1)")
                {
                    float radius = 5.0f;
                    Vector3 explosionPosition = item.transform.position;
                    Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
                    foreach (Collider hit in colliders)
                    {
                        Rigidbody rbbomb = hit.GetComponent<Rigidbody>();
                        if (rbbomb != null)
                            rbbomb.AddExplosionForce(0.1f, explosionPosition, radius, 1.0f, ForceMode.Impulse);
                    }
                }
                Destroy(item, 2.5f);
            }
        }
        if (collision.collider.tag == "Ground")
        {
            movement.isGrounded = true;
            GlobalControl.Instance.hardness = 0;
            if(GlobalControl.Instance.level <=6)
                FindObjectOfType<GlobalControl>().PlayMusic();
            GlobalControl.Instance.currentSong = 1;
        }

        if (collision.collider.tag == "GroundHard")
        {
            movement.isGrounded = true;
            GlobalControl.Instance.hardness = 1;
            FindObjectOfType<GlobalControl>().PlayMusicH();
            GlobalControl.Instance.currentSong = 2;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishLine") && pm.enabled == true)
        {
            GlobalControl.Instance.score = Score.score2;
            Debug.Log(Score.score2);
            if (GlobalControl.Instance.level == 10)
            {
                finishedPanel.SetActive(true);
                scoreText.SetActive(false);
            }
            else
                FindObjectOfType<GameManager>().NextLevel();
        }
    }
}