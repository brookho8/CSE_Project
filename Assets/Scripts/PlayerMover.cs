using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    public float speed;
    public Vector3 startPosition;

    private float horizontal;
    private float vertical;
    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical !=0){
            anim.enabled = true;
        }
        else{
            anim.enabled = false;
        }
    }

    void FixedUpdate(){
        rb.velocity = Vector3.Normalize(new Vector3(horizontal, vertical, 0)) * speed;
    }

    public void Reset(){
        transform.position = startPosition;
    }

    public void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Goal"){
            Debug.Log("Win");
        }
    }
    
}