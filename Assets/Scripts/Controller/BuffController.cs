using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemBase item = collision.GetComponent<ItemBase>();
        if (item == null) return;
        item.Use();

        if(item.Type != TypeItem.PoiSon)
        {
            Destroy(item.gameObject);
        }
    }
}
