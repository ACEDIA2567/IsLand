using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[Serializable]
public class ResourceData
{
    public string ResourceName;
    public int value;
}

public class Produce : MonoBehaviour
{
    // 제작 시 얻을 아이템 데이터
    public ItemData data;
    public List<ResourceData> resourceData;
    
    // 인벤토리 정보
    UIInventory inventory;

    // 제작 가능한지 확인
    public void CheckProduce()
    {
        inventory = GameManager.Instance.Player.inventory;
        bool Check = true;

        for (int i = 0; i < resourceData.Count; i++)
        {
            // 가지고 있지 않다면
            if (!inventory.CheckItem(resourceData[i].ResourceName, resourceData[i].value))
            {
                // 제작 불가능
                Check = false;
            }
        }

        // 아이템의 존재가 없으면 실행 취소
        if (!Check) return;

        // 제작에 필요한 아이템을 소모
        for (int i = 0; i < resourceData.Count; i++)
        {
            // 아이템 소모하고 아이템 획득
            inventory.RemoveItem(resourceData[i].ResourceName, resourceData[i].value);
        }

        // 아이템 획득
        ProduceItem();
    }



    // 제작 성공 시 인벤토리에 아이템 넣기
    public void ProduceItem()
    {
        // 아이템을 플레이어의 인벤토리에 추가
        GameManager.Instance.Player.currentData = data;
        GameManager.Instance.Player.AddItem?.Invoke();
    }
}
