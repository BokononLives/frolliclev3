using Frollicle.Core;
using UnityEngine;

public class CubeCollider : MonoBehaviour
{
    public bool Blocked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == CustomTag.PlantedHair.ToString())
        {
            Blocked = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == CustomTag.PlantedHair.ToString())
        {
            Blocked = false;
        }
    }
}
