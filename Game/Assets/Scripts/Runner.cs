using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RodaLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1
}

public class Runner : MonoBehaviour
{
    [SerializeField] RodaLine roadLine;

    void Start()
    {
        roadLine = RodaLine.MIDDLE;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(roadLine != RodaLine.LEFT)
            {
                roadLine--;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadLine != RodaLine.RIGHT)
            {
                roadLine++;
            }
        }
    }
}
