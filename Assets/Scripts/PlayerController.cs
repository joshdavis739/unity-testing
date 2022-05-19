using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    
    private Rigidbody2D _rb;

    private Vector2 position;

    // Start is called before the first frame update
    void Start() 
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue movementValue) 
    {
        Vector2 inputVector = movementValue.Get<Vector2>();
        
        var angle = Mathf.Atan2(inputVector.y, inputVector.x);

        inputVector.x *= speed;
        inputVector.y *= speed;

        _rb.velocity = inputVector;
        if (inputVector.x != 0 || inputVector.y != 0 ) {
            _rb.transform.rotation = Quaternion.Slerp(_rb.transform.rotation, Quaternion.Euler(0f, 0f, angle * 180 / Mathf.PI), 1);
            // _rb.transform.rotation = Quaternion.Slerp(_rb.transform.rotation, Quaternion.Euler(0f, 0f, angle), 0.5F);
            // StartCoroutine(Rotate(angle * 180 / Mathf.PI));
        }
    }

    IEnumerator Rotate(float targetAngle)
    {
        while (_rb.transform.rotation.y != targetAngle)
        {
            _rb.transform.rotation = Quaternion.Slerp(_rb.transform.rotation, Quaternion.Euler(0f, 0f, targetAngle), 1);
            // _rb.transform.rotation = Quaternion.Slerp(_rb.transform.rotation, Quaternion.Euler(0f, targetAngle, 0f), 3f * Time.deltaTime);
            yield return null;
        }
        _rb.transform.rotation = Quaternion.Euler(0f, 0f, targetAngle);
        yield return null;
    }     

    // private void FixedUpdate()
    // {
    //     Vector3 movement = new Vector3(_movementX, 0.0f, _movementY);

    //     _rb.MovePosition(movement * speed);
    // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _rb.angularVelocity = 0F;
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
