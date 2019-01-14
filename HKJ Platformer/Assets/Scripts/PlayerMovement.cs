using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 0.1f;
    [SerializeField] Vector3 pathLeft;
    [SerializeField] Vector3 pathMid;
    [SerializeField] Vector3 pathRight;
    Vector3 targetPos;

    private void Start()
    {
        targetPos = transform.position;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
            targetPos = (targetPos == pathMid) ? pathLeft : pathMid;
        if(Input.GetKeyDown(KeyCode.D))
            targetPos = (targetPos == pathMid) ? pathRight : pathMid;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position,targetPos, speed);
    }
}
