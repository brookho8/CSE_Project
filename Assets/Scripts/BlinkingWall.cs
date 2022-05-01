using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingWall : MonoBehaviour
{

    public float blinkTime;

    private float timer;
    private bool enabled;

    private BoxCollider2D collider;
    private SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        enabled = true;
        collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= blinkTime){
            enabled = !enabled;
            collider.enabled = enabled;
            if (enabled){
                renderer.color = new Vector4(1, 1, 1, 1);
            }
            else{
                renderer.color = new Vector4(.1f, .1f, .1f, .1f);
            }
            timer = 0;
        }
    }

}