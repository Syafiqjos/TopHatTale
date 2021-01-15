using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransport : MonoBehaviour
{
    public Transform transportTarget;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            RoomMaster.TransportRoom(transportTarget.position);
        }
    }
}
