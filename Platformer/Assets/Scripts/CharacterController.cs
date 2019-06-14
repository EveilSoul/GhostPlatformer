using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float Speed;
    public float FlyingSpeed;
    public float JumpForce;
    public float MaxJumpDistance;
    public float RotationSpeed;
    public float JumpHeight;

    public float DeathHeight;
    public Transform StartPoition;

    private Rigidbody rigidbody;
    private RaycastHit hit;
    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        currentSpeed = Speed;
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
            bool isJump = false;

            if (Physics.Raycast(gameObject.transform.position, Vector3.down, out hit) && hit.distance <= MaxJumpDistance)
            {
                currentSpeed = Speed;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isJump = true;
                    currentSpeed = FlyingSpeed;
                }

                if (hit.collider.GetComponent<MovingObject>() != null)
                    transform.position += hit.collider.GetComponent<MovingObject>().Offset;
            }
            //Debug.Log(currentSpeed);

            var deltaZ = -Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
            var deltaX = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
            var mouseX = Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime;

            gameObject.transform.Rotate(0, mouseX, 0);
            if (isJump && Input.GetKey(KeyCode.W))
            {
                rigidbody.AddForce(transform.right.x * JumpForce, JumpForce * JumpHeight, transform.right.z * JumpForce);
            }
            else if (isJump)
            {
                rigidbody.AddForce(0, JumpForce * JumpHeight, 0);
            }
            gameObject.transform.Translate(deltaX, 0, deltaZ);
        }
    }
}
