using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 15f;
    private Vector2 _inputVector;
    private Rigidbody playerRb;
    [SerializeField] private float _maxXBound = 10f;
    [SerializeField] private float _minXBound = -10f;
    [SerializeField] private float _maxZBound = 6f;
    [SerializeField] private float _minZBound = -10f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        _inputVector = context.ReadValue<Vector2>();
    }
    public void OnDropInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("drop");
        }
    }
    public void OnRotateLeftInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("rotateLeft");
        }
    }
    public void OnRotateRightInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("rotateRight");
        }
    }
    private void Move()
    {
        if (transform.position.x <= _maxXBound &&
            transform.position.x >= _minXBound &&
            transform.position.z <= _maxZBound &&
            transform.position.z >= _minZBound)
        {
            Vector3 moveVector3 = new Vector3(_inputVector.x, 0, _inputVector.y);
            playerRb.velocity = moveVector3 * _moveSpeed;
        }
        if (transform.position.x > _maxXBound)
        {
            transform.position = new Vector3(_maxXBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x < _minXBound)
        {
            transform.position = new Vector3(_minXBound, transform.position.y, transform.position.z);
        }
        if (transform.position.z > _maxZBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _maxZBound);
        }
        if (transform.position.z < _minZBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _minZBound);
        }
    }
}
