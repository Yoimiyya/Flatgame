using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class WormMove : MonoBehaviour
{
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public float speed;
    private int face_direction = 1;
    private Animator animator;
    private GameObject apple;
    private GameObject bird;
    public bool in_control;
    private AudioSource worm_move;
    private AudioSource worm_eat;

    // Start is called before the first frame update
    void Start()
    {
        in_control = true;
        this.transform.position = new Vector3(30, -6.22f, 0);
        animator = GetComponent<Animator>();
        apple = GameObject.Find("apple");
        bird = GameObject.Find("Bird");
        worm_move = this.gameObject.AddComponent<AudioSource>();
        worm_eat = this.gameObject.AddComponent<AudioSource>();
        worm_move.clip = audioClip1;
        worm_eat.clip = audioClip2;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x <= -4.5 && apple != null)
        {
            if (!worm_eat.isPlaying)
            {
                worm_eat.Play();
            }
            speed = 0.5f;
        } else
        {
            speed = 2.5f;
        }

        if (in_control)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (!worm_move.isPlaying)
                {
                    worm_move.Play();
                }
                animator.speed = 1f;
                this.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
                if (face_direction == -1)
                {
                    this.transform.Rotate(0, 180, 0);
                    face_direction = 1;
                }
           
            }
            else
            { 
                worm_move.Stop();
                animator.speed = 0f;
                animator.Play(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name, 0, 0);
            }
        }

        

        if (bird.GetComponent<Bird>().reached)
        {
            Destroy(gameObject);
        }
    }
}
