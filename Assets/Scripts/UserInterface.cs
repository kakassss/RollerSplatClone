using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInterface : MonoBehaviour
{
    [SerializeField] PlayerMovement pm;
    [SerializeField] GameObject winUI;

    private void Start()
    {
        winUI.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        Win();   
    }
    private void Win()
    {
        if (!pm.canMove)
        {
            winUI.gameObject.SetActive(true);
        }
        else
        {
            winUI.gameObject.SetActive(false);
        }
    }
}
