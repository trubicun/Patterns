using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Strategy;

public class Selector : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _halfScreen;
    private RaycastHit _hit;
    private ISelectable _selectable;

    public const float Distance = 3f;
    private void Start()
    {
        _camera = Camera.main;
        _halfScreen = new Vector3(Screen.width / 2, Screen.height / 2);
    }

    private void Update()
    {
        Debug.DrawRay(_camera.transform.position, _camera.ScreenPointToRay(_halfScreen).direction * 3);
        if (Physics.Raycast(_camera.ScreenPointToRay(_halfScreen), out _hit, Distance))
        {
            ISelectable selectable = _hit.transform.GetComponent<ISelectable>();
            if (selectable != null && selectable != _selectable)
            {
                if (_selectable != null) _selectable.DeSelect();
                _selectable = selectable;
                _selectable.Select();
            }
        } else
        {
            if (_selectable != null)
            {
                _selectable.DeSelect();
                _selectable = null;
            }
        }
    }
}
