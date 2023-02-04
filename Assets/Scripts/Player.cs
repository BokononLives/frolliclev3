using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private InputActionReference _move;
    [SerializeField] private InputActionReference _drop;
    [SerializeField] private InputActionReference _rotateLeft;
    [SerializeField] private InputActionReference _rotateRight;
    [SerializeField] private float _moveSpeed = 7f;
    private Vector2 _inputVector;
    private Rigidbody playerRb;

    private void OnEnable()
    {
        _drop.action.started += OnDropInput;
    }

    private void OnDisable()
    {
        _drop.action.started -= OnDropInput;
    }
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
        Debug.Log(_inputVector);
        _inputVector = context.ReadValue<Vector2>();
    }
    public void OnDropInput(InputAction.CallbackContext context)
    {
        Debug.Log("drop");
    }
    private void Move()
    {
        Vector3 moveVector3 = new Vector3(_inputVector.x, 0, _inputVector.y);
        playerRb.velocity = moveVector3 * _moveSpeed;
    }
}
