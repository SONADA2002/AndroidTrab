using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMove : MonoBehaviour
{

    [SerializeField]
    private Vector2 direction;

    [SerializeField]
    private float moveSpeed = 1f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * (moveSpeed * Time.deltaTime));
    }
}
