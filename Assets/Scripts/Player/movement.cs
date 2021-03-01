using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public float sidePower = 1f;
    private bool start=false;
    public static bool isGrounded = true;

    private Touch _theTouch;
    private Vector2 _touchStartPos, _touchEndPos;


    private void Update()
    {
        if (transform.position.y <= -10f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }    
    }

    void FixedUpdate()
    {
        if(start)
        {
            transform.position += transform.forward * Time.deltaTime*8;
        }
        Move();
    }

    //rb.AddForce(-sidePower * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        /*if (rb.velocity.x >= -40f)
        {
            //rb.AddForce(-sidePower * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            transform.Translate(-1 * Time.deltaTime* 100, 0, 0);
        }*/


    private void Move()
    {
        if (Input.touchCount > 0)
        {
            _theTouch = Input.GetTouch(0);
            if (_theTouch.phase == TouchPhase.Stationary)
            {
                _touchStartPos = _theTouch.position;
                if (_theTouch.position.x < Screen.width / 3 )
                {
                    if (rb.velocity.x >= -40f)
                    {
                        rb.AddForce(-sidePower * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                    }
                }

                if (_theTouch.position.x >= Screen.width / 3 && _theTouch.position.x <= (Screen.width / 3)*2)
                {
                    start = true;
                }

                if (_theTouch.position.x > (Screen.width / 3)*2)
                {
                    if (rb.velocity.x <= 40f)
                    {
                        rb.AddForce(sidePower * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                    }

                }
            }
            else if (_theTouch.phase == TouchPhase.Moved || _theTouch.phase == TouchPhase.Ended)
            {
                _touchEndPos = _theTouch.position;
                float x = _touchEndPos.x - _touchStartPos.x;
                float y = _touchEndPos.y - _touchStartPos.y;

                if (Mathf.Abs(y) > Mathf.Abs(x)) //SLIDE JUMP
                {
                    if (isGrounded && y>100f)

                        if (isGrounded)
                        {
                            rb.AddForce(Vector3.up * 3000);
                            if (transform.position.z <= 2)
                                Collusion.flag = true;
                            isGrounded = false;
                        }
                }
            }
        }
    }
}