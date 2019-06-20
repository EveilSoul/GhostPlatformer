using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo Instance;
    public GameObject Player;
    public Transform PlayerTransform;
    public CapsuleCollider PlayerCollider;

    public AudioClip ButtonDown;
    public AudioClip DoorOpen;

    void Awake()
    {
        Instance = this;
        PlayerCollider = Player.GetComponent<CapsuleCollider>();
        PlayerTransform = Player.GetComponent<Transform>();
    }
}
