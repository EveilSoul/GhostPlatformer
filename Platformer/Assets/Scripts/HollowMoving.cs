using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollowMoving : MonoBehaviour
{
    public float LenghtMove;
    public float WeightMove;

    private Vector3 startPoint;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = gameObject.transform.position;
        Debug.Log(startPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(gameObject.transform.position.z - startPoint.z) < LenghtMove)
        {
            gameObject.transform.Translate(Vector3.forward*Time.deltaTime);
            Debug.Log("forward");
        }
        else
        {
            if (Mathf.Abs(gameObject.transform.position.x - startPoint.x) < WeightMove)
            {
                gameObject.transform.Translate(Vector3.right * Time.deltaTime);
                Debug.Log("right");
            }
            else
            {
                if (Mathf.Abs(gameObject.transform.position.z - startPoint.z) >= LenghtMove)
                {
                    gameObject.transform.Translate(Vector3.back * Time.deltaTime);
                    Debug.Log("back");
                }
                else
                {
                    if (Mathf.Abs(gameObject.transform.position.x - startPoint.x) >= WeightMove)
                    {
                        gameObject.transform.Translate(Vector3.left * Time.deltaTime);
                        Debug.Log("left");
                    }
                }
            }
        }
    }
}
