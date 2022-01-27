using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkableGround : MonoBehaviour
{
    public bool canChangeColor = false;
    public Renderer render;

    private void Awake()
    {
        render = GetComponent<Renderer>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canChangeColor = true;
        }
    }
}
