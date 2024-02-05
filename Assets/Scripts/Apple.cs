using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    private Animator animator;
    private GameObject worm;
    public float fall_speed;
    public Sprite end_sprite;
    private AudioSource apple_fall;
    private AudioSource fall;
    private bool hasPlayed_1 = false;
    private bool hasPlayed_2 = false;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(-7.3f,3.5f,0);
        animator = GetComponent<Animator>();
        worm = GameObject.Find("Worm");
        animator.speed = 0;
        apple_fall = this.gameObject.GetComponent<AudioSource>();

        apple_fall = this.gameObject.AddComponent<AudioSource>();
        fall = this.gameObject.AddComponent<AudioSource>();
        apple_fall.clip = audioClip1;
        fall.clip = audioClip2;
    }

    // Update is called once per frame
    void Update()
    {
        animator.speed = 0;
        if (worm.transform.position.x <= 0f && this.transform.position.y > worm.transform.position.y) 
        {
            if (!hasPlayed_1)
            {
                fall.Play();
                hasPlayed_1 = true;
            }
            this.transform.position += new Vector3(0, -fall_speed * Time.deltaTime, 0);

        } else if (worm.transform.position.x <= -4f && this.transform.position.y <= worm.transform.position.y)
        {
            animator.speed = 0.5f;
        }
        if (this.transform.position.y <= worm.transform.position.y && !hasPlayed_2)
        {
            apple_fall.volume = 2;
            apple_fall.Play();
            hasPlayed_2 = true;
        }

        if (this.GetComponent<SpriteRenderer>().sprite == end_sprite)
        {
            Destroy(gameObject, 1f);
        }

    }

}
