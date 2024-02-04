using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speed;
    private GameObject worm;
    private GameObject main_camera;
    public bool reached;
    

    // Start is called before the first frame update
    void Start()
    {
        reached = false;
        this.transform.position = new Vector3 (-51,10,0);
        worm = GameObject.Find("Worm");
        main_camera = GameObject.Find("Virtual Camera");
    
    }

    // Update is called once per frame
    void Update()
    {
        if (worm.transform.position.x <= -35)
        {
            if (this.transform.position.y > -4.4)
            {
                this.transform.position += new Vector3(speed * Time.deltaTime, -speed * Time.deltaTime, 0);
                worm.transform.position += new Vector3(-2 * Time.deltaTime, 0, 0);
            } else
            {
                reached = true;
                main_camera.GetComponent<CinemachineVirtualCamera>().Follow = gameObject.transform;
                main_camera.GetComponent<CinemachineVirtualCamera>().LookAt = gameObject.transform;
                
                if (Input.GetKey(KeyCode.D))
                {
                    this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                    
                }
            }

        }
    }
}
