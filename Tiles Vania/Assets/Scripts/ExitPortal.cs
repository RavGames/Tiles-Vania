using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortal : MonoBehaviour
{
    [SerializeField] float waitingTime = .3f;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var gameObject = otherCollider.gameObject.GetComponent<Player>();
        if(gameObject)
        {
            
            StartCoroutine(Portal());
        }
    }

    private IEnumerator Portal()
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSecondsRealtime(waitingTime);
        Time.timeScale = 1;
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
        
    }

    
}//CLASS
