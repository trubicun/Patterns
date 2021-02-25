using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Strategy;
using static Tweeny.Animation;
using static Tweeny.Function;

public class Sphere : MonoBehaviour, ISelectable
{
    [SerializeField] private float _selectTime = 0.25f;
    [SerializeField] private Color _selectColor = Color.blue;
    [SerializeField] private Vector3 _selectScale = new Vector3(2,2,2);

    private Vector3 _startScale;
    private Color _startColor;
    private void Start()
    {
        _startScale = transform.localScale;
        _startColor = GetComponent<Renderer>().material.color;

        StartCoroutine(Transformation.Move(SpikeEaseInOut, 2f, gameObject, transform.position + transform.up, true));
    }

    public void Select()
    {
        StopAllCoroutines();
        StartCoroutine(Rendering.ChangeColor(EaseOut, _selectTime, gameObject, _selectColor));
        StartCoroutine(Transformation.Scale(EaseOut, _selectTime, gameObject, _selectScale));
    }

    public void DeSelect()
    {
        StopAllCoroutines();
        StartCoroutine(Rendering.ChangeColor(EaseOut, _selectTime, gameObject, _startColor));
        StartCoroutine(Transformation.Scale(EaseOut, _selectTime, gameObject, _startScale));
        StartCoroutine(Transformation.Move(SpikeEaseInOut, 2f, gameObject, transform.position + transform.up, true));
    }
}
