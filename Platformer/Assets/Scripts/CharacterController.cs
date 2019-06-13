using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public float MaxJumpDistance;
    public float RotationSpeed;

    public float DeathHeight;
    public Transform StartPoition;

    private Rigidbody rigidbody;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y <= DeathHeight)
        {
            gameObject.transform.position = StartPoition.position;
            rigidbody.velocity = Vector3.zero;
        }
        else
        {
            var deltaZ = -Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
            var deltaX = Input.GetAxis("Vertical") * Speed * Time.deltaTime;
            var mouseX = Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime;
            bool isJump = false;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Physics.Raycast(gameObject.transform.position, Vector3.down, out hit))
                {
                    Debug.Log("hit " + hit.collider);
                    if (hit.distance <= MaxJumpDistance)
                        isJump = true;
                }
            }

            gameObject.transform.Rotate(0, mouseX, 0);
            rigidbody.AddForce(0, isJump ? JumpForce : 0, 0);
            gameObject.transform.Translate(deltaX, 0, deltaZ);
        }
    }
}
