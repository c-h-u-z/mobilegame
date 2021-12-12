using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody))]
public class CactusController : MonoBehaviour
{

    Rigidbody r;
    public PlayerInput playerInput;

    public float sinkSpeed, jumpPower;

    public Game game;

    void OnEnable()
    {
        r = GetComponent<Rigidbody>();
        playerInput.actions.FindAction("Fire").performed += Jump;
    }
    void OnDisable()
    {
        playerInput.actions.FindAction("Fire").performed -= Jump;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        r.velocity += Vector3.down * Time.deltaTime * sinkSpeed;
        transform.LookAt(transform.position+Vector3.right + (r.velocity/6f));
    }

    public void Jump(InputAction.CallbackContext context) 
    {
        r.velocity = Vector3.up * jumpPower;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        game.GameOver();
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("PointGap")) {
            Game.score++;
        }
    }
}
