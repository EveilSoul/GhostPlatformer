using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SetActiveButton : MonoBehaviour
{
    public GameObject Goal;
    public float ReactDistance = .5f;
    public float DownDustance = .3f;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Goal.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < ReactDistance)
        {
            //transform.Translate(0, -DownDustance, 0);
            Goal.SetActive(true);
            gameObject.GetComponent<StateMachine>().enabled = true;
            Debug.Log(" setActiveButton button has pushed");
        }
    }
}
