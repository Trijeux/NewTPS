using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private int numItem = 0;
    private readonly List<Item> _items = new List<Item>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddChildren();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var item in _items.ToList().Where(item => item.IsPick))
        {
            numItem++;
            Destroy(item.gameObject);
            _items.Remove(item);
        }
    }
    
    private void AddChildren()
    {
        _items.Clear();
    
        for (var i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
	    
            var script = child.GetComponent<Item>();
            if (script != null) 
            {
                _items.Add(script);
            }
        }
    }
}