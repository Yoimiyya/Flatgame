using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    private AudioSource backmusic;


    // Start is called before the first frame update
    void Start()
    {
        backmusic = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!backmusic.isPlaying)
        {
            backmusic.Play();
        }
    }
}
