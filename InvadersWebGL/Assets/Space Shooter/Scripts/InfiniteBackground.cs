using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteBackground : MonoBehaviour
{


    [SerializeField]
    private float moveAmount = 2.72f;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        if (transform.position.y < -moveAmount)
        {
            transform.Translate(Vector2.up * moveAmount * 2);
        }
    }
}
