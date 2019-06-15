using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollowReaction : MonoBehaviour
{
    public float Radius;
    public float speed;

    private bool isFollow;
    private Transform target;

    private StateMachine stateMachine;
    private Vector3 startPos;
    private Quaternion startRot;

    void Start()
    {
        stateMachine = gameObject.GetComponent<StateMachine>();
        startPos = gameObject.transform.position;
        startRot = gameObject.transform.rotation;
        isFollow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFollow && Vector3.Distance(PlayerInfo.Instance.PlayerTransform.position, gameObject.transform.position) <= Radius)
        {
            stateMachine.enabled = false;
            isFollow = true;
            target = PlayerInfo.Instance.PlayerTransform;
        }
        if (isFollow)
        {
            FaceTarget();
            gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            PlayerInfo.Instance.PlayerCollider.enabled = false;
            isFollow = false;
        }
    }
}
