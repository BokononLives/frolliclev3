using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManagerV1 : MonoBehaviour
{
    [SerializeField] private Material _hairMaterial;
    private PlayerInputManager _playerInputManager;
    private GameObject _playerPrefab;
    public event Action<PlayerInput> OnPlayerJoined;
    public static int _playerIndex = 0;
    private void Awake()
    {
        _playerInputManager = GetComponent<PlayerInputManager>();
        _playerPrefab = _playerInputManager.playerPrefab;
        Color chosenColor = GameManager.Instance.PlayerColor[_playerIndex];
        _hairMaterial.color = chosenColor;
        _playerPrefab.GetComponentInChildren<Renderer>().sharedMaterial = _hairMaterial;
    }
    private void OnEnable()
    {
        OnPlayerJoined += ChangePlayerColor;
    }
    private void OnDisable()
    {
        OnPlayerJoined -= ChangePlayerColor;
    }
    public void ChangePlayerColor(PlayerInput obj)
    {
        _playerIndex++;
        Debug.Log("player Index" + _playerIndex);
        Material playerJoinedHairMaterial = new Material(_hairMaterial);
        Color chosenColor = GameManager.Instance.PlayerColor[_playerIndex];
        Debug.Log("color = " + chosenColor);
        playerJoinedHairMaterial.color = chosenColor;
        _playerPrefab.GetComponentInChildren<Renderer>().sharedMaterial = playerJoinedHairMaterial;
    }
}
