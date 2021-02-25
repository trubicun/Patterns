using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looking : MonoBehaviour
{
    [SerializeField] private float _sensetivity;

    [SerializeField] private Transform _playerBody;

    private float _rotation = 0f;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * _sensetivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * _sensetivity;

        _rotation -= mouseY;
        _rotation = Mathf.Clamp(_rotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_rotation, 0f, 0f);
        _playerBody.Rotate(Vector3.up * mouseX);
    }
}
