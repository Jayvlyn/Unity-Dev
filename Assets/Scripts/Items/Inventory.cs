using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] Item[] items;
    public Item currentItem { get; private set; }

    void Start()
    {
        currentItem = items[0];
        currentItem.Equip();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(currentItem == items[0])
            {
                currentItem = items[1];
            }
            else
            {
                currentItem = items[0];
            }
            currentItem.Equip();
        }
    }

    public void Use()
    {
        currentItem?.Use();
    }

    public void OnStopUse()
    {
        currentItem?.StopUse();
    }
}
