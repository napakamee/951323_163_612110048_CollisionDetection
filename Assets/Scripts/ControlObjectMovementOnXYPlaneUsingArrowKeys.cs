using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObjectMovementOnXYPlaneUsingArrowKeys : MonoBehaviour
{
    // Start is called before the first frame update
    public float _movementStep;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Getkey
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-_movementStep, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(_movementStep, 0, 0);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0, 0, _movementStep);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(0, 0, -_movementStep);
        }
    }
}
