using UnityEngine;

public class CubeCollider : MonoBehaviour
{
    public bool Blocked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlantedHair")
        {
            Blocked = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlantedHair")
        {
            Blocked = false;
        }
    }
}
