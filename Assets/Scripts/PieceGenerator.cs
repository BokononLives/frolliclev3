using Frollicle.Core;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PieceGenerator : MonoBehaviour
{
    [SerializeField] private int _ammo = 0;
    public GameObject PlayerCube;
    public GameObject PlantedHair;
    [SerializeField] private float _moveSpeed = 15f;
    private Vector2 _inputVector;
    private Rigidbody playerRb;
    private Piece CurrentPiece;
    private Piece[] RandomPieces = new Piece[] { Piece.I, Piece.O, Piece.T, Piece.S, Piece.Z, Piece.J, Piece.L };
    public Material PieceMaterial;
    private Dictionary<Piece, List<Vector3>> SquarePositions = new Dictionary<Piece, List<Vector3>>
    {
        { Piece.I, new List<Vector3> { new Vector3(0.5f, -0.5f, -0.1f), new Vector3(0.5f, 1.5f, -0.1f), new Vector3(0.5f, 2.5f, -0.1f) } },
        { Piece.O, new List<Vector3> { new Vector3(0.5f, 1.5f, -0.1f), new Vector3(1.5f, 0.5f, -0.1f), new Vector3(1.5f, 1.5f, -0.1f) } },
        { Piece.T, new List<Vector3> { new Vector3(0.5f, 1.5f, -0.1f), new Vector3(-0.5f, 0.5f, -0.1f), new Vector3(1.5f, 0.5f, -0.1f) } },
        { Piece.S, new List<Vector3> { new Vector3(0.5f, 1.5f, -0.1f), new Vector3(-0.5f, 0.5f, -0.1f), new Vector3(1.5f, 1.5f, -0.1f) } },
        { Piece.Z, new List<Vector3> { new Vector3(0.5f, 1.5f, -0.1f), new Vector3(1.5f, 0.5f, -0.1f), new Vector3(-0.5f, 1.5f, -0.1f) } },
        { Piece.J, new List<Vector3> { new Vector3(-0.5f, 0.5f, -0.1f), new Vector3(1.5f, 0.5f, -0.1f), new Vector3(-0.5f, 1.5f, -0.1f) } },
        { Piece.L, new List<Vector3> { new Vector3(-0.5f, 0.5f, -0.1f), new Vector3(1.5f, 0.5f, -0.1f), new Vector3(1.5f, 1.5f, -0.1f) } }
    };
    private Vector3 _correction = new Vector3(-0.5f, -0.5f, 0);

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.R)) //TODO: do this when the game's over
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.tag == CustomTag.PlayerCube.ToString())
                {
                    child.GetComponent<Rigidbody>().isKinematic = false;
                }
            }
        }
    }
    
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        _inputVector = context.ReadValue<Vector2>();
    }

    public void OnDropInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (IsBlocked())
            {
                Debug.Log("Blocked!"); //TODO: feedback of some kind
                return;
            }

            if (IsBonusEligible())
            {
                _ammo += 5;
            }

            var nextPiece = RandomPieces[Random.Range(0, RandomPieces.Length)];

            foreach (Transform child in transform)
            {
                if (child.gameObject.tag == CustomTag.PlayerCube.ToString())
                {
                    var hair = Instantiate(PlantedHair, child.transform.position, Quaternion.identity);
                    hair.GetComponent<MeshRenderer>().material.color = Color.red;
                    Destroy(child.gameObject);
                }
            }

            foreach (var squarePosition in SquarePositions[nextPiece])
            {
                var square = Instantiate(PlayerCube, transform.position + squarePosition + _correction, Quaternion.identity);
                square.transform.parent = gameObject.transform;
                square.GetComponent<MeshRenderer>().material = PieceMaterial;
            }

            var coreSquare = Instantiate(PlayerCube, transform.position + new Vector3(0.5f, 0.5f, -0.1f) + _correction, Quaternion.identity);
            coreSquare.transform.parent = gameObject.transform;
            coreSquare.GetComponent<MeshRenderer>().material = PieceMaterial;

            if (_ammo > 0)
            {
                var color = coreSquare.GetComponent<MeshRenderer>().material.color;
                color.r = Mathf.Min(1f, color.r + 0.25f);
                color.g = Mathf.Min(1f, color.g + 0.25f);
                color.b = Mathf.Min(1f, color.b + 0.25f);
                coreSquare.GetComponent<MeshRenderer>().material.color = color;
            }
        }
    }

    public void OnRotateLeftInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            transform.Rotate(new Vector3(0, 0, 90f));
        }
    }
    
    public void OnRotateRightInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            transform.Rotate(new Vector3(0, 0, -90f));
        }
    }

    public void OnSpecialInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (_ammo > 0)
            {
                _ammo--;
                var hair = Instantiate(PlantedHair, transform.position + new Vector3(0.5f, 0.5f, -0.1f) + _correction, Quaternion.identity);
                hair.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }

            if (_ammo <= 0)
            {
                foreach (Transform child in transform)
                {
                    if (child.gameObject.tag == CustomTag.PlayerCube.ToString())
                    {
                        child.GetComponent<MeshRenderer>().material = PieceMaterial;
                    }
                }
            }
        }
    }

    private void Move()
    {
        Vector3 moveVector3 = new Vector3(_inputVector.x, _inputVector.y, 0);
        playerRb.velocity = moveVector3 * _moveSpeed;
    }

    private bool IsBlocked()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == CustomTag.PlayerCube.ToString())
            {
                if (child.GetComponent<CubeCollider>().Blocked)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool IsBonusEligible()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == CustomTag.PlayerCube.ToString())
            {
                if (child.GetComponent<CubeCollider>().BonusEligible)
                {
                    return true;
                }
            }
        }

        return false;
    }
}