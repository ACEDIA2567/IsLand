using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo : MonoBehaviour, IItemInfo
{
    public ItemData data;

    // 아이템 획득
    public void ItemAdd()
    {
        GameManager.Instance.Player.currentData = data;
        GameManager.Instance.Player.AddItem?.Invoke();
        Destroy(gameObject);
    }

    // 아이템 텍스트 정보 반환
    public string ItemText()
    {
        string text = data.itemName + "\n" + data.description;
        return text;
    }
}
