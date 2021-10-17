using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CoinPickUp : MonoBehaviour
{

    [SerializeField] float pointsPerCoin = 50f;
    [SerializeField] AudioClip audioClip;

    

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
        FindObjectOfType<GameSession>().AddScore(pointsPerCoin);
        Destroy(gameObject);

    }








}//CLASS
