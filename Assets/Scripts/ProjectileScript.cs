using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    public float speed;
    public Vector3 direction;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position = transform.position + direction * speed * Time.deltaTime;

        if (timer >= 10){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if(col.gameObject.tag == "Player") {
            Destroy(gameObject);
            col.gameObject.GetComponent<PlayerMover>().Reset();
        }
    }

}