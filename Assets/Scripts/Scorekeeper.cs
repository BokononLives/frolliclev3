using System.Linq;
using Frollicle.Core;
using UnityEngine;

public class Scorekeeper : MonoBehaviour
{
    public GameObject CountdownTimer;

    void Start()
    {
        Timer.OnTimeUp += () => EndGame();
    }

    private void EndGame()
    {
        foreach (var cube in GameObject.FindGameObjectsWithTag(CustomTag.PlayerCube.ToString()))
        {
            //TODO: disable input
            cube.GetComponent<Rigidbody>().isKinematic = false;

            var hairFollicles = GameObject.FindGameObjectsWithTag(CustomTag.PlantedHair.ToString())
                .Select(x => x.GetComponent<PlantedHair>())
                .GroupBy(x => new { x.Color, x.PlayerIndex })
                .OrderByDescending(x => x.Count())
                .FirstOrDefault();
            
            if (hairFollicles != null)
            {
                Debug.Log($"The winner is Player {hairFollicles.Key.PlayerIndex + 1}");
            }
        }
    }
}