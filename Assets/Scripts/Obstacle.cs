using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Obstacle : MonoBehaviour
{

    
    public float moveSpeed;

    void OnEnable()
    {
        Destroy(gameObject,5f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * moveSpeed;
    }
}
