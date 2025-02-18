using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public enum RodaLine
{
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1
}

public class Runner : MonoBehaviour
{
    [SerializeField] float positionX = 4.0f;

    [SerializeField] RodaLine roadLine;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rigidbody;

    void Start()
    {
        roadLine = RodaLine.MIDDLE;

        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (roadLine != RodaLine.LEFT)
            {
                roadLine--;

                animator.Play("Left Aviod");
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadLine != RodaLine.RIGHT)
            {
                roadLine++;

                animator.Play("RightAviod");
            }
        }
    }

    public void OnKeyUpdate()
    {
        
    }

    private void Move()
    {
        rigidbody.position = new Vector3(positionX * (int)roadLine, 0, 0);
    }
}
