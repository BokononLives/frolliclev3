using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManagerV2 : MonoBehaviour
{
    private PlayerInputManager _playerInputManager;
    private GameObject _playerPrefab;
    [SerializeField] private Material _hairMaterial;

    public event Action<PlayerInput> OnPlayerJoined;
    private void Awake()
    {
        _playerInputManager = GetComponent<PlayerInputManager>();
        _playerPrefab = _playerInputManager.playerPrefab;
        Color randomColor = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
        _hairMaterial.color = randomColor;
        _playerPrefab.GetComponentInChildren<PieceGenerator>().PieceMaterial = _hairMaterial;
    }
    private void OnEnable()
    {
        OnPlayerJoined += CreateRandomHairColor;
    }

    private void OnDisable()
    {
        OnPlayerJoined -= CreateRandomHairColor;
    }

    public void CreateRandomHairColor(PlayerInput obj)
    {
        Material playerJoinedHairMaterial = new Material(_hairMaterial);
        Color randomColor = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
        playerJoinedHairMaterial.color = randomColor;
        _playerPrefab.GetComponentInChildren<PieceGenerator>().PieceMaterial = playerJoinedHairMaterial;
    }

}
