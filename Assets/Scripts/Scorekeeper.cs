using System.Collections;
using System.Linq;
using Frollicle.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scorekeeper : MonoBehaviour
{
    public GameObject CountdownTimer;
    public TMP_Text TextPanel;
    public Button Button;

    void Start()
    {
        Timer.OnTimeUp += () => EndGame();
    }

    private void EndGame()
    {
        var hairFollicles = GameObject.FindGameObjectsWithTag(CustomTag.PlantedHair.ToString())
            .Select(x => x.GetComponent<PlantedHair>())
            .GroupBy(x => new { x.Color, x.PlayerIndex })
            .OrderByDescending(x => x.Count())
            .FirstOrDefault();
        
        if (hairFollicles != null)
        {
            var text = $"The winner is Player {hairFollicles.Key.PlayerIndex + 1}";
            StartCoroutine(ShowWinner(text));
        }
    }

    private IEnumerator ShowWinner(string text)
    {
        yield return new WaitForSeconds(2f);

        TextPanel.text = text;
        Button.enabled = true;
    }
}