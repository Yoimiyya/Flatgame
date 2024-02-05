using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    public float speed;
    private GameObject worm;
    private GameObject main_camera;
    public bool reached;
    public bool in_control;
    private GameObject poop;
    private AudioSource wing;
    private AudioSource sound;
    private AudioSource eat;
    public Sprite start_sprite;
    private bool hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        in_control = true;
        reached = false;
        this.transform.position = new Vector3 (-51,10,0);
        worm = GameObject.Find("Worm");
        main_camera = GameObject.Find("Virtual Camera");
        poop = GameObject.Find("poop");
        
        wing = this.gameObject.AddComponent<AudioSource>();
        sound = this.gameObject.AddComponent<AudioSource>();
        eat = this.gameObject.AddComponent<AudioSource>();
        wing.clip = audioClip1;
        sound.clip = audioClip2;
        eat.clip = audioClip3;
    }

    // Update is called once per frame
    void Update()
    {
        if (reached != true && worm.transform.position.x <= -28)
        {
            if (this.transform.position.y > -4.4)
            {
                if (!hasPlayed)
                {
                    sound.volume = 0.3f;
                    sound.Play();
                    hasPlayed = true;
                }
                worm.GetComponent<WormMove>().in_control = false;
                worm.GetComponent<Animator>().speed = 1f;
                this.transform.position += new Vector3(speed * Time.deltaTime, -speed * Time.deltaTime, 0);
                worm.transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
                
            } else
            {
                reached = true;
                main_camera.GetComponent<CinemachineVirtualCamera>().Follow = gameObject.transform;
                main_camera.GetComponent<CinemachineVirtualCamera>().LookAt = gameObject.transform;
            }

        }

        if (reached && in_control)
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (this.transform.position.x <= -20)
                {
                    this.transform.position += new Vector3(speed * Time.deltaTime, speed * Time.deltaTime, 0);
                } else
                {
                    this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                }
                
                if (this.transform.position.x >= 31)
                {
                    in_control = false;
                }

            }
            if (this.transform.position.y >= 0)
            {
                main_camera.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = 0.5f;
            }
        }
       
        if (!in_control)
        {
            if (poop != null && poop.transform.position.y >= this.transform.position.y - 2.45f)
            {
                this.transform.position += new Vector3(0, 0, 0);
            } else
            {
                this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
            
        } 

        if (this.GetComponent<SpriteRenderer>().sprite == start_sprite && hasPlayed && in_control)
        {
            if (!wing.isPlaying)
            {
                wing.Play();
            }
            
        }
    }
}
