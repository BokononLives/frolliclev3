using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManagerV2 : MonoBehaviour
{
    private PlayerInputManager _playerInputManager;
    private GameObject _playerPrefab;
    [SerializeField] private Material _hairMaterial;
    public GameObject BonusSquarePicker;
    public static int _playerIndex = 0;

    public event Action<PlayerInput> OnPlayerJoined;
    private void Awake()
    {
        _playerInputManager = GetComponent<PlayerInputManager>();
        _playerPrefab = _playerInputManager.playerPrefab;
        _playerPrefab.GetComponent<PieceGenerator>().BonusSquarePicker = BonusSquarePicker;
        Color chosenColor = GameManager.Instance.PlayerColor[_playerIndex];
        _hairMaterial.color = chosenColor;
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
        _playerIndex++;
        Material playerJoinedHairMaterial = new Material(_hairMaterial);
        if (_playerIndex >= GameManager.Instance.PlayerColor.Length) return;
        Color chosenColor = GameManager.Instance.PlayerColor[_playerIndex];
        playerJoinedHairMaterial.color = chosenColor;
        _playerPrefab.GetComponentInChildren<PieceGenerator>().PieceMaterial = playerJoinedHairMaterial;
    }

}
