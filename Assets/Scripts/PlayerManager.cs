using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Material _hairMaterial;
    private PlayerInputManager _playerInputManager;
    private GameObject _playerPrefab;
    public event Action<PlayerInput> OnPlayerJoined;
    private Color _playerHairColor;
    private Dictionary<int, Color> _playerColorDictionary = new Dictionary<int, Color> { };
    private void Awake()
    {
        _playerInputManager = GetComponent<PlayerInputManager>();
        _playerPrefab = _playerInputManager.playerPrefab;
        Color randomColor = new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
        _hairMaterial.color = randomColor;
        _playerPrefab.GetComponentInChildren<Renderer>().sharedMaterial = _hairMaterial;
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
        _playerHairColor = randomColor;
        playerJoinedHairMaterial.color = randomColor;
        _playerPrefab.GetComponentInChildren<Renderer>().sharedMaterial = playerJoinedHairMaterial;
    }
}
