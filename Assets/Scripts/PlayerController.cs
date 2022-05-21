using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    
    public Rigidbody2D rigidBody;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    private Vector2 position;

    private DateTime _lastTimeMoved;

    // Start is called before the first frame update
    void Start() 
    {
        rigidBody.freezeRotation = true;
        // _rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue movementValue) 
    {
        Vector2 inputVector = movementValue.Get<Vector2>();
        
        var angle = Mathf.Atan2(inputVector.y, inputVector.x);

        inputVector.x *= speed;
        inputVector.y *= speed;

        rigidBody.velocity = inputVector;

        if (inputVector.x != 0 || inputVector.y != 0) {
            // o lawd he running
            animator.SetBool("IsMoving", true);
            animator.SetBool("IsSleeping", false);
            SleepDelay();
        }
        else {
            // o lawd he waiting
            animator.SetBool("IsMoving", false);
        }

        if (inputVector.x > 0) {
            spriteRenderer.flipX = true;
            // _rb.transform.rotation = Quaternion.Slerp(_rb.transform.rotation, Quaternion.Euler(0f, -180, 0f), 1);
        }
        if (inputVector.x < 0) {
            spriteRenderer.flipX = false;
            // _rb.transform.rotation = Quaternion.Slerp(_rb.transform.rotation, Quaternion.Euler(0f, 180, 0f), 1);
        }
    }

    private async Task SleepDelay() {
        _lastTimeMoved = DateTime.Now;
        await Task.Delay(2000);
        if (_lastTimeMoved.AddMilliseconds(1800) <= DateTime.Now) {
            // o lawd he sleeping
            animator.SetBool("IsSleeping", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    //Do something
    }

    //Hitting a collider 2D
    private void OnCollisionStay2D(Collision2D collision)
    {
    //Do something
    }

    //Just stop hitting a collider 2D
    private void OnCollisionExit2D(Collision2D collision)
    {
    //Do something
    }

    //Just overlapped a collider 2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var gameObject = collision.gameObject.GetComponent<IInteractable>();
        gameObject.OnInteract();
    }

    //Overlapping a collider 2D
    private void OnTriggerStay2D(Collider2D collision)
    {
    //Do something
    }

    //Just stop overlapping a collider 2D
    private void OnTriggerExit2D(Collider2D collision)
    {
    //Do something
    }
}
