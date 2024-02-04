using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private Animator animator;
    private GameObject worm;
    public float fall_speed;
    public Sprite end_sprite;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(-7.3f,3.5f,0);
        animator = GetComponent<Animator>();
        worm = GameObject.Find("Worm");
        animator.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = 0;
        if (worm.transform.position.x <= 0f && this.transform.position.y > worm.transform.position.y) 
        {
            this.transform.position += new Vector3(0, -fall_speed * Time.deltaTime, 0);

        } else if (worm.transform.position.x <= -4f && this.transform.position.y <= worm.transform.position.y)
        {
            animator.speed = 0.5f;
        }

        if (this.GetComponent<SpriteRenderer>().sprite == end_sprite)
        {
            Destroy(gameObject, 1f);
        }

    }

}
