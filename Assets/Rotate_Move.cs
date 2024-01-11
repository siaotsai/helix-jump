using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Move : MonoBehaviour
{
    public float rorateSpeed;
    private float moveX;

    void Update()
    {
        moveX = Input.GetAxis("Mouse X");

        if (Input.GetMouseButton(0))
        {
            transform.Rotate(0f, moveX * rorateSpeed * Time.deltaTime, 0f);
        }

    }

}
