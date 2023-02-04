using Frollicle.Core;
using System.Collections.Generic;
using UnityEngine;

public class PieceGenerator : MonoBehaviour
{
    //private int _rotation; //TODO
    public GameObject PlayerCube;
    private Piece CurrentPiece;
    private Piece[] RandomPieces = new Piece[] { Piece.I, Piece.O, Piece.T, Piece.S, Piece.Z, Piece.J, Piece.L };
    private Dictionary<Piece, List<Vector3>> SquarePositions = new Dictionary<Piece, List<Vector3>>
    {
        { Piece.I, new List<Vector3> { new Vector3(0.5f, -0.5f, -0.1f), new Vector3(0.5f, 0.5f, -0.1f), new Vector3(0.5f, 1.5f, -0.1f), new Vector3(0.5f, 2.5f, -0.1f) } },
        { Piece.O, new List<Vector3> { new Vector3(0.5f, 0.5f, -0.1f), new Vector3(0.5f, 1.5f, -0.1f), new Vector3(1.5f, 0.5f, -0.1f), new Vector3(1.5f, 1.5f, -0.1f) } },
        { Piece.T, new List<Vector3> { new Vector3(0.5f, 0.5f, -0.1f), new Vector3(0.5f, 1.5f, -0.1f), new Vector3(-0.5f, 0.5f, -0.1f), new Vector3(1.5f, 0.5f, -0.1f) } },
        { Piece.S, new List<Vector3> { new Vector3(0.5f, 0.5f, -0.1f), new Vector3(0.5f, 1.5f, -0.1f), new Vector3(-0.5f, 0.5f, -0.1f), new Vector3(1.5f, 1.5f, -0.1f) } },
        { Piece.Z, new List<Vector3> { new Vector3(0.5f, 0.5f, -0.1f), new Vector3(0.5f, 1.5f, -0.1f), new Vector3(1.5f, 0.5f, -0.1f), new Vector3(-0.5f, 1.5f, -0.1f) } },
        { Piece.J, new List<Vector3> { new Vector3(0.5f, 0.5f, -0.1f), new Vector3(-0.5f, 0.5f, -0.1f), new Vector3(1.5f, 0.5f, -0.1f), new Vector3(-0.5f, 1.5f, -0.1f) } },
        { Piece.L, new List<Vector3> { new Vector3(0.5f, 0.5f, -0.1f), new Vector3(-0.5f, 0.5f, -0.1f), new Vector3(1.5f, 0.5f, -0.1f), new Vector3(1.5f, 1.5f, -0.1f) } }
    };

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsBlocked())
            {
                Debug.Log("Blocked!");
                return;
            }

            var nextPiece = RandomPieces[Random.Range(0, RandomPieces.Length)];

            //switch (_rotation) {} //TODO

            foreach (Transform child in transform)
            {
                if (child.gameObject.tag == "PlayerCube")
                {
                    Destroy(child.gameObject);
                }
            }

            foreach (var squarePosition in SquarePositions[nextPiece])
            {
                var square = Instantiate(PlayerCube, squarePosition, Quaternion.identity);
                square.transform.parent = gameObject.transform;
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) //TODO: do this when the game's over
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.tag == "PlayerCube")
                {
                    child.GetComponent<Rigidbody>().isKinematic = false;
                }
            }
        }
    }

    private bool IsBlocked()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "PlayerCube")
            {
                if (child.GetComponent<CubeCollider>().Blocked)
                {
                    return true;
                }
            }
        }

        return false;
    }
}