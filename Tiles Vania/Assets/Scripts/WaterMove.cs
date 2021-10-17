using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMove : MonoBehaviour
{
    [SerializeField] float speedUp = .2f;

    private void Update()
    {
        transform.Translate(Vector2.up * speedUp * Time.deltaTime);
    }
}//CLASS
