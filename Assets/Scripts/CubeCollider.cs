using Frollicle.Core;
using UnityEngine;

public class CubeCollider : MonoBehaviour
{
    public bool Blocked = false;
    public bool BonusEligible = false;

    private void OnTriggerEnter(Collider other)
    {
        var tag = other.gameObject.tag;
        if (tag == CustomTag.PlantedHair.ToString())
        {
            Blocked = true;
        }
        else if (tag == CustomTag.BonusSquare.ToString())
        {
            BonusEligible = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var tag = other.gameObject.tag;
        if (tag == CustomTag.PlantedHair.ToString())
        {
            Blocked = true;
        }
        else if (tag == CustomTag.BonusSquare.ToString())
        {
            BonusEligible = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var tag = other.gameObject.tag;
        if (tag == CustomTag.PlantedHair.ToString())
        {
            Blocked = false;
        }
        else if (tag == CustomTag.BonusSquare.ToString())
        {
            BonusEligible = false;
        }
    }
}
