using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public bool moveX;
    public bool moveY;
    public bool moveZ;
    public float moveTime;
    public float moveSpeed;

    private Vector3 moveDirction = Vector3.zero;
    new private Rigidbody rigidbody;
    private PlayerController Controller;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        StartCoroutine(MoveChange());
        if (moveX)
        {
            moveDirction += Vector3.right;
        }
        if (moveY)
        {
            moveDirction += Vector3.up;
        }
        if (moveZ)
        {
            moveDirction += Vector3.forward;
        }
        moveDirction *= moveSpeed;
    }

    private void FixedUpdate()
    {
        if (Controller != null)
        {
            Controller.platformDir = rigidbody.velocity;
        }
    }

    IEnumerator MoveChange()
    {
        while (true)
        {
            moveDirction *= -1;
            rigidbody.velocity = moveDirction;
            yield return new WaitForSeconds(moveTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerController controller))
        {
            Controller = controller;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController controller))
        {
            Controller.platformDir = Vector3.zero;
            Controller = null;
        }
    }
}
