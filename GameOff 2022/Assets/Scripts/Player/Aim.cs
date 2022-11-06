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
    }
}
