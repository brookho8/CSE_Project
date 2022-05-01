using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public string direction;
    public float shootInterval;
    public float shootSpeed;
    public float projectileInstantiationDisplacement;

    private Transform playerPosition;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        playerPosition = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= shootInterval){
            Shoot();
            timer = 0;
        }
    }

    void Shoot(){

        Vector3 shootDir = new Vector3(0, 0, 0);

        if(direction == "u"){
            shootDir = new Vector3(0, 1, 0);
        }
        else if (direction == "d"){
            shootDir = new Vector3(0, -1, 0);
        }
        else if (direction == "l"){
            shootDir = new Vector3(-1, 0, 0);
        }
        else if (direction == "r"){
            shootDir = new Vector3(1, 0, 0);
        }
        else if (direction == "t"){
            shootDir = Vector3.Normalize(playerPosition.position - gameObject.transform.position);
        }

        GameObject projectileToShoot = Resources.Load("projectile") as GameObject;
        GameObject projectileShot = Instantiate(projectileToShoot, transform.position + shootDir * projectileInstantiationDisplacement, Quaternion.identity) as GameObject;
        
        projectileShot.GetComponent<ProjectileScript>().speed = shootSpeed;
        projectileShot.GetComponent<ProjectileScript>().direction = shootDir;
    }

}