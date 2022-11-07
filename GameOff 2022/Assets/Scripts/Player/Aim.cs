using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Vector2 mousePos;
    public Camera cam;

    void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Aiming();   
    }

    void Aiming()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.up = (mousePos - new Vector2(transform.position.x, transform.position.y));

        FlipGun();
    }

    void FlipGun()
    {
        if(transform.rotation.z <= 0)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
}
