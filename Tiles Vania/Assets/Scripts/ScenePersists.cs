using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenePersists : MonoBehaviour
{
    int startingSceneIndex;

    private void Awake()
    {
        int currentGameObject = FindObjectsOfType<ScenePersists>().Length;
        if(currentGameObject > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Scene Start = " + startingSceneIndex);
    }

    private void Update()
    {
        int currrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Scene current = " + currrentSceneIndex);
        if (currrentSceneIndex != startingSceneIndex)
        {
            Destroy(gameObject);
        }
    }

}//CLASS
