using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool HasPushed;
    public float ReactDistance = 0.5f;

    private GameObject player;
    private Door door;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        door = GameObject.FindGameObjectWithTag("Door").GetComponent<Door>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < ReactDistance)
        {
            HasPushed = true;
            door.CheckButtons();
            Debug.Log("button has pushed");
        }
    }
}
