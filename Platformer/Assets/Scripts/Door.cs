using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Button[] Buttons;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CheckButtons()
    {
        if(Buttons.All(x => x.HasPushed))
        {
            Debug.Log("Door is open");
            // todo
        }
    }
}
