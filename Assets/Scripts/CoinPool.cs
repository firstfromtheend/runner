using System;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool<T> where T : MonoBehaviour
{
    public T prefab { get; }
    public bool autoExpand { get; set; }
    public Transform container { get; set; }

    private List<T> pool;

    public CoinPool(T prefab, int count)
    {
        this.prefab = prefab;
        this.container = null;

        this.CreatePool(count);
    }

    public CoinPool(T preafab, int count, Transform container)
    {
        this.prefab = preafab;
        this.container = container;

        this.CreatePool(count);
    }

    private void CreatePool(int count)
    {
        pool = new List<T>();

        for (int i = 0; i < count; i++)
        {
            this.CreateObject();
        }

    }

    private T CreateObject(bool activeByDefault = false)
    {
        var CreatedObject = UnityEngine.Object.Instantiate(this.prefab, this.container);
        CreatedObject.gameObject.SetActive(activeByDefault);
        this.pool.Add(CreatedObject);
        return CreatedObject;
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var item in pool)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                element = item;
                item.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (this.HasFreeElement(out var element)) return element;

        if (this.autoExpand) return this.CreateObject(true);

        throw new Exception("nope");
    }
}