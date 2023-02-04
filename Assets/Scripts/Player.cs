using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 7f;
    private Vector2 _inputVector;
    private Rigidbody playerRb;

    // Start is called before the first frame update
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
    private void Move()
    {
        Debug.Log(_inputVector);
        playerRb.velocity = _inputVector * _moveSpeed;
    }
}
