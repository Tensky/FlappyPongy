using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float speed = 1f;
    public float boundY = 3f;
    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var veloc = rigidBody.velocity;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            veloc.y = speed;
        }else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
            veloc.y = -speed;
        }else {
            veloc.y = 0;
        }
        rigidBody.velocity = veloc;

        var position = transform.position;
        if(position.y >= boundY){
            position.y = boundY;
        }else if(position.y <= -boundY){
            position.y = -boundY;
        }

        transform.position = position;
    }
}
