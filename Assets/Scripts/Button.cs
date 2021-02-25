using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Strategy;
using static Tweeny.Animation;
using static Tweeny.Function;

public class Button : MonoBehaviour, ISelectable, IInteractible
{
    [SerializeField] private float _selectTime = 0.25f;
    [SerializeField] private float _pushTime = 0.5f;
    [SerializeField] private Vector3 _pressedScale;
    private Vector3 _startScale;
    private Vector3 _selectScale;
    private Color _startColor;
    private bool _pressed;

    private delegate void Backed();

    public delegate void EventHandler();
    public event EventHandler OnPressed;
    private void Start()
    {
        _startScale = transform.localScale;
        _selectScale = _startScale + Vector3.one * 0.1f;
        _startColor = GetComponent<Renderer>().material.color;
    }

    public void DeSelect()
    {
        StopAllCoroutines();
        StartCoroutine(Transformation.Scale(EaseOut, _selectTime, gameObject, _startScale));
        StartCoroutine(Rendering.ChangeColor(EaseOut, _selectTime, gameObject, _startColor));

        //Возможно стоит вынести нажимание в отдельный скрипт
        _pressed = false;
    }

    public void Select()
    {
        StopAllCoroutines();
        StartCoroutine(Transformation.Scale(EaseOut, _selectTime, gameObject, _selectScale));
        StartCoroutine(Rendering.ChangeColor(EaseOut, _selectTime, gameObject, Color.red));
    }

    public void Interact()
    {
        if (!_pressed)
        {
            _pressed = true;
            StopAllCoroutines();
            StartCoroutine(Transformation.Scale(EaseOut, _pushTime, gameObject, _pressedScale));
            StartCoroutine(Rendering.ChangeColor(EaseOut, _pushTime, gameObject, _startColor));
            StartCoroutine(Wait(_pushTime, Back));

            OnPressed?.Invoke();
        }
    }

    private IEnumerator Wait(float seconds, Backed back)
    {
        yield return new WaitForSeconds(seconds);
        back();
    }

    private void Back()
    {
        StartCoroutine(Transformation.Scale(EaseOut, _pushTime, gameObject, _selectScale));
        StartCoroutine(Rendering.ChangeColor(EaseOut, _pushTime, gameObject, Color.red));
        _pressed = false;
    }
}
