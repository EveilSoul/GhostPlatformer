using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float MaxUpAngle;
    public float MaxDownAngle;
    public float Sensivity;

    private float rotation;
    private Vector3 baseRotation;

    void Start()
    {
        baseRotation = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        rotation -= Input.GetAxis("Mouse Y") * Sensivity * Time.deltaTime;
        rotation = Mathf.Clamp(rotation, MaxDownAngle, MaxUpAngle);
        transform.localEulerAngles = new Vector3(baseRotation.x, baseRotation.y, baseRotation.z + rotation);
    }

}
