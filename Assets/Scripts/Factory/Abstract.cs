using UnityEngine;


namespace Factory 
{
    public abstract class Product : MonoBehaviour
    {
        //Do something
    }

    public abstract class Factory : MonoBehaviour    
    {
        public abstract Product CreateProduct();
    }
}