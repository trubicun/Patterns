using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Factory;

public class ObjectFactory : Factory.Factory
{
    [SerializeField] private Product _product;
    [SerializeField] private Vector3 _spawnCoord;

    private void Start()
    {
        //Паттерн Observer
        GetComponent<Button>().OnPressed += WhenPressed;
    }

    public void WhenPressed()
    {
        Product product = CreateProduct();
        product.transform.position = _spawnCoord + Random.onUnitSphere * 2f;
        product.transform.localScale -= Random.insideUnitSphere * 0.5f;
    }

    public override Product CreateProduct()
    {
        return Instantiate(_product);
    }
}
