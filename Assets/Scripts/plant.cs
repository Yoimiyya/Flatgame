using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class plant : MonoBehaviour
{
    public bool in_control;
    public Sprite start_sprite;
    private Animator animator;
    private GameObject main_camera;
    public Sprite end_sprite;
    private Sprite currentSprite;
    private Sprite previousSprite;
    private bool hasPlayed;

    private AudioSource leaf_eat;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(30, -6.22f, 0);
        in_control = false;
        animator = GetComponent<Animator>();
        animator.speed = 0f;
        main_camera = GameObject.Find("Virtual Camera");
        previousSprite = start_sprite;
        leaf_eat = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        currentSprite = this.GetComponent<SpriteRenderer>().sprite;
        
        this.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0);
        if (in_control)
        {
   
            this.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1);
            main_camera.GetComponent<CinemachineVirtualCamera>().Follow = gameObject.transform;
            main_camera.GetComponent<CinemachineVirtualCamera>().LookAt = gameObject.transform;
            main_camera.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = 0.88f;
            animator.speed = 0.02f;
            if (previousSprite != currentSprite)
            {
                hasPlayed = false;
                previousSprite = currentSprite;
                if (!hasPlayed)
                {
                    leaf_eat.Play();
                    hasPlayed = true;
                }
            }
            if (this.GetComponent<SpriteRenderer>().sprite == end_sprite)
            {
                animator.speed = 0;
                Invoke("AndReset", 3f);
                Destroy(gameObject, 3f);
            }
        }
    }
    void AndReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
