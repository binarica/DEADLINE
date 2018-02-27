using UnityEngine;
using System.Collections;

public interface IPickupable
{
    void Pickup(GameObject player);
    void Drop(GameObject player);
}
