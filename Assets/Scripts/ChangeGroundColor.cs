using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGroundColor : MonoBehaviour
{
    [SerializeField] private List<Transform> cubes;
    [SerializeField] private List<WalkableGround> walkableCubes;
    [SerializeField] private Material currentPlayer;
    [SerializeField] private PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        FindWalkableCubes();
    }

    private void Update()
    {
        ChangeColor(currentPlayer);
        IsAllCubesDone(currentPlayer);
    }
    private void FindWalkableCubes()
    {
        foreach (Transform item in transform)
        {
            var newItem = item.GetComponent<WalkableGround>();
            cubes.Add(item);
            walkableCubes.Add(newItem);
        }
    }
    private void IsAllCubesDone(Material player)
    {
        int count = 0;
        for (int i = 0; i < walkableCubes.Count; i++)
        {
            if (walkableCubes[i].canChangeColor)
            {
                count++;

                if (count == walkableCubes.Count)
                {
                    pm.canMove = false;
                    pm.rb.velocity = Vector3.zero;
                }
            }
        }
    }
    private void ChangeColor(Material player)
    {
        foreach(WalkableGround item in walkableCubes)
        {
            if (item.canChangeColor)
            {
                item.render.material.color = player.color;
            }
        }
    }
    
}
