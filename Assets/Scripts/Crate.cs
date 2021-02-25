using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Strategy;
using static Tweeny.Function;
using static Tweeny.Animation;

public class Crate : MonoBehaviour, ISelectable
{
    [SerializeField] private float _selectTime = 1f;
    [SerializeField] private Color _selectColor = Color.yellow;

    private Color _startColor;
    private void Start()
    {
        _startColor = GetComponent<Renderer>().material.color;
    }
    public void Select()
    {
        StopAllCoroutines();
        StartCoroutine(Rendering.ChangeColor(EaseOut, _selectTime, gameObject, _selectColor));
    }

    public void DeSelect()
    {
        StopAllCoroutines();
        StartCoroutine(Rendering.ChangeColor(EaseOut, _selectTime, gameObject, _startColor));
    }
}
