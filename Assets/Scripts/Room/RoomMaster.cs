using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMaster : MonoBehaviour
{
    public static PlayerCamera playerCamera;
    public static GameObject player;

    private static Vector2 transportLocation;
    private static int transportState = 0;
    public float timerMax = 2;
    public float timer = 0;

    void Awake()
    {
        playerCamera = GameObject.Find("Main Camera").GetComponent<PlayerCamera>();
        player = GameObject.Find("Player");

        transportLocation = player.transform.position;
        transportState = 0;
    }

    void Start()
    {
        
    }

    void Update()
    {
        TransportingRoom();
    }

    public static void TransportRoom(Vector2 location)
    {
        playerCamera.FadeIn();
        transportLocation = location;
        transportState = 1;
    }

    private void TransportingRoom()
    {
        if (transportState == 1 && playerCamera.IsFadeIn)
        {
            transportState = 2;
            player.transform.position = transportLocation;
            playerCamera.transform.position = transportLocation;
            timer = timerMax;
        }
        else if (transportState == 2)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                transportState = 3;
                playerCamera.FadeOut();
            }
        }
    }
}
