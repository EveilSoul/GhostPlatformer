using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool HasPushed;
    public float ReactDistance = 0.5f;

    private GameObject player;
    private Door door;
    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        player = PlayerInfo.Instance.Player;
        door = GameObject.FindGameObjectWithTag("Door").GetComponent<Door>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive && Vector3.Distance(gameObject.transform.position, player.transform.position) < ReactDistance)
        {
            HasPushed = true;
            door.CheckButtons();
            AudioSource.PlayClipAtPoint(PlayerInfo.Instance.DoorOpen, gameObject.transform.position);
            Debug.Log("button has pushed");
            isActive = true;
        }
    }
}
