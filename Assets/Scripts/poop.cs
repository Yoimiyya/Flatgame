using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poop : MonoBehaviour
{
    private GameObject bird;
    public float speed;
    private GameObject main_camera;
    private GameObject plant;

    public AudioClip audioClip1;
    public AudioClip audioClip2;

    private AudioSource pop_up;
    private AudioSource smash;

    private bool hasPlayed1 = false;
    private bool hasPlayed2 = false;
    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.Find("Bird");
        main_camera = GameObject.Find("Virtual Camera");
        plant = GameObject.Find("plant");

        pop_up = this.gameObject.AddComponent<AudioSource>();
        smash = this.gameObject.AddComponent<AudioSource>();

        pop_up.clip = audioClip1;
        smash.clip = audioClip2;
    }

    // Update is called once per frame
    void Update()
    {
        if (bird.GetComponent<Bird>().in_control)
        {
            this.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0);
            this.transform.position = new Vector3(bird.transform.position.x-1.05f, bird.transform.position.y-0.95f, bird.transform.position.z);
        } else
        {
            this.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1);
            if (this.transform.position.y > bird.transform.position.y - 2.45)
            {
                speed = 0.5f;
                if (Input.GetKey(KeyCode.S))
                {
                    this.transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
                }
            } else
            {
                
                if (!hasPlayed1)
                {
                    pop_up.Play();
                    hasPlayed1 = true;
                }
                speed = 6;
                this.transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
                if (this.transform.position.y > 0)
                {
                    main_camera.GetComponent<CinemachineVirtualCamera>().Follow = gameObject.transform;
                    main_camera.GetComponent<CinemachineVirtualCamera>().LookAt = gameObject.transform;
                }
                if (this.transform.position.y <= 0)
                {
                    plant.GetComponent<plant>().in_control = true;
                }
                if (this.transform.position.y <= -6.22f)
                {
                    if (!hasPlayed2)
                    {
                        smash.Play();
                        hasPlayed2 = true;
                    }
                    Destroy(gameObject);
                    
                }
            }
            
        }
    }
}
