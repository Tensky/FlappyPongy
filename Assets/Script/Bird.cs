using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float jumpHeight = 200f;
    private Rigidbody2D rigidBody;
    private bool isDead = false;
    public float boundY = 3f;

    private Animator mAnimator;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Old script
        // if(!isDead && Input.GetMouseButtonDown(0)){
        //     rigidBody.velocity = Vector2.zero;
        //     rigidBody.AddForce(new Vector2(0, jumpHeight));
        //     mAnimator.SetTrigger("Flap");
        // } 

        //Script for bound
        var position = transform.position;
        if(position.y >= boundY){
            position.y = boundY;
        }else if(position.y <= -boundY){
            position.y = -boundY;
        }

        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //New colider script
        if(collision.collider.CompareTag("Platform") && !isDead){
            rigidBody.velocity = Vector2.zero;
            rigidBody.AddForce(new Vector2(0, jumpHeight));
            mAnimator.SetTrigger("Flap");
            return;
        }
        //Die collider script
        rigidBody.velocity = Vector2.zero;
        isDead = true;
        mAnimator.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }
    
}
