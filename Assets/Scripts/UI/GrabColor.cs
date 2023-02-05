using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GrabColor : MonoBehaviour
{
    [SerializeField] private TMP_Text _colorSelectText;
    private Color Color;
    public static int PlayerIndex = 0;

    public void StoreColorIntoPlayerColor()
    {
        Color = GetComponent<Image>().color;
        if (PlayerIndex < GameManager.Instance.PlayerColor.Length)
        {
            GameManager.Instance.PlayerColor[PlayerIndex] = Color;
            PlayerIndex++;
        }
        if (PlayerIndex >= GameManager.Instance.PlayerColor.Length)
        {
            SceneManager.LoadScene("JakeScene");
            return;
        }
        int playerNumber = PlayerIndex + 1;
        _colorSelectText.text = "Player " + playerNumber + ", select the clients hair color.";
    }
}
