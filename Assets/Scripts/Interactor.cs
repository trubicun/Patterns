using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Strategy;

public class Interactor : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _halfScreen;
    private RaycastHit _hit;

    public const float Distance = 3f;
    private void Start()
    {
        _camera = Camera.main;
        _halfScreen = new Vector3(Screen.width / 2, Screen.height / 2);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_camera.ScreenPointToRay(_halfScreen), out _hit, Distance))
            {
                IInteractible interactible = _hit.transform.GetComponent<IInteractible>();
                if (interactible != null) interactible.Interact();
            }
        }
    }
}
