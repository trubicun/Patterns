using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private CharacterController _character;

    private void Start()
    {
        _character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 vertical = transform.forward * Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        Vector3 horizontal = transform.right * Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        Vector3 move = vertical + horizontal;

        if (move.magnitude > 0) _character.SimpleMove(move);
    }
}
