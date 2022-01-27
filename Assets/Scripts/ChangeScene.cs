using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] PlayerMovement pm;
    [SerializeField] float delay;
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ChangeLevel());
    }
    private IEnumerator ChangeLevel()
    {       
        if (!pm.canMove)
        {
            yield return new WaitForSeconds(delay);
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                yield break;
            }              
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
