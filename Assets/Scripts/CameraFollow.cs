using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // this class helps to follow the player smoothly

    public Transform target;
    public float smoothing;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // always comes last, we want to make sure the camera moves after the player moves
    void LateUpdate()
    {
        // move the camera if they are not in the same position towards the player's position
        if (transform.position != target.position)
        {
            Vector3 newPosition = new Vector3(target.position.x, transform.position.y, target.position.z+3.5f);

            // use lerp for a smoother movement
            transform.position = Vector3.Lerp(transform.position, newPosition, smoothing);
        }
    }
}
