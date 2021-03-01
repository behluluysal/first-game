using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody obstacle;
    public float sidePower = 15f;
    bool FlagLeft = false;
    void FixedUpdate()
    {
        if (obstacle.position.x >= 2.5f)
        {
            FlagLeft = true;
            obstacle.velocity *= 0;
        } 
        else if (obstacle.position.x <=-2.5f)
        {
            FlagLeft = false;
            obstacle.velocity *= 0;
        }
            
        if(FlagLeft)
            obstacle.AddForce(-sidePower * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        else
            obstacle.AddForce(sidePower * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
}
