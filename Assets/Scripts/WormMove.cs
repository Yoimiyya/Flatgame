using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class WormMove : MonoBehaviour
{

    public float speed;
    private int face_direction = 1;
    private Animator animator;
    private GameObject apple;
    private GameObject bird;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(13, -6.22f, 0);
        animator = GetComponent<Animator>();
        apple = GameObject.Find("apple");
        bird = GameObject.Find("Bird");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x <= -4.5 && apple != null)
        {
            speed = 0.5f;
        } else
        {
            speed = 2;
        }

        if (Input.GetKey(KeyCode.A))
        {
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
            animator.speed = 0f;
            animator.Play(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name, 0, 0);
        }

        if (bird.GetComponent<Bird>().reached)
        {
            Destroy(gameObject);
        }
    }
}
