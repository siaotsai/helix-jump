using UnityEngine;

public class Rotate_Move : MonoBehaviour
{
    public float rorateSpeed;
    private float _moveX;

    private void Update()
    {
        _moveX = Input.GetAxis("Mouse X");

        if (Input.GetMouseButton(0))
        {
            transform.Rotate(0f, _moveX * rorateSpeed * Time.deltaTime, 0f);
        }

    }

}
