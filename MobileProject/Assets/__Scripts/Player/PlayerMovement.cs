using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float maxSpeed = 5f;
    public float rotSpeed = 180f;

    float shipBoundaryRadius = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ROTATE the ship.

        // Grab our rotation quaternion
        Quaternion rot = transform.rotation;

        // Grab the Z euler angle
        float z = rot.eulerAngles.z;

        // Change the Z angle based on input
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

        // Recreate the quaternion
        rot = Quaternion.Euler(0, 0, z);

        // Feed the quaternion into our rotation
        transform.rotation = rot;

        // MOVE the ship.
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);

        pos += rot * velocity;

        // RESTRICT the player to the camera's boundaries!

        // Vertical boundaries
        // orthographic is the projection type of the camera
        // and the size is 5
        //if the y position is more then the orthographicSize then set the boundary - top of the game
        if (pos.y + shipBoundaryRadius > Camera.main.orthographicSize){
            pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
        }
        //if the y position is more then the orthographicSize then set the boundary - bottom of the game
        if (pos.y - shipBoundaryRadius < -Camera.main.orthographicSize){
            pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
        }

        // Now calculate the orthographic width based on the screen ratio
        //Get the the edges for the horizontal bounds
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float orthographicWidth = Camera.main.orthographicSize * screenRatio;

        // Horizontal boundaries
        //same as y position but * screenratio
        if (pos.x + shipBoundaryRadius > orthographicWidth){
            pos.x = orthographicWidth - shipBoundaryRadius;
        }

        if (pos.x - shipBoundaryRadius < -orthographicWidth){
            pos.x = -orthographicWidth + shipBoundaryRadius;
        }

        // Finally, update our position!!
        transform.position = pos;


    }
}
