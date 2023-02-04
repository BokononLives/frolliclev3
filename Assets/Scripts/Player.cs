using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 15f;
    private Vector2 _inputVector;
    private Rigidbody playerRb;
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
        Vector3 moveVector3 = new Vector3(_inputVector.x, 0, _inputVector.y);
        playerRb.velocity = moveVector3 * _moveSpeed;
    }
}
