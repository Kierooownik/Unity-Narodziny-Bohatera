using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryList<T> where T: class
{
    private T _item;
    public T item
    {
        get { return _item; }
    }
    
    public InventoryList()
    {
        //Debug.Log("Generyczna lista zosta³a zainicjowana...");
    }

    public void SetItem(T newItem)
    {
        _item = newItem;
        //Debug.Log("Nowy element zosta³ dodany...");
    }
}
