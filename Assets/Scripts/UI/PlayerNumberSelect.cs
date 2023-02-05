using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNumberSelect : MonoBehaviour
{
    [SerializeField] private GameObject _playerCountPanel;
    [SerializeField] private GameObject _colorPickPanel;
    // Start is called before the first frame update
    public void OnSelectPlayerNumber()
    {
        _colorPickPanel.SetActive(true);
        _playerCountPanel.SetActive(false);
    }
}
