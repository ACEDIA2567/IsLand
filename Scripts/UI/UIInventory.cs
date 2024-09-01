using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInventory : MonoBehaviour
{
    public Transform inventoryTransform;
    public GameObject inventoryObject;
    private Slot[] slots;

    private void Start()
    {
        GameManager.Instance.Player.AddItem += Add;
        slots = new Slot[inventoryTransform.childCount];
        for(int i = 0; i < slots.Length; i++)
        {
            slots[i] = inventoryTransform.GetChild(i).GetComponent<Slot>();
            slots[i].Clear();
            slots[i].index = i;
        }
        inventoryObject.SetActive(false);
        GameManager.Instance.Player.inventory = this;
    }

    // Index의 값을 매개변수를 받아서 슬롯의 정보를 받아옴
    public Slot GetSlot(int index)
    {
        return slots[index];
    }

    // 인벤토리에 아이템 추가
    void Add()
    {
        ItemData itemData = GameManager.Instance.Player.currentData;

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].data == itemData &&
                slots[i].slotQuantity < slots[i].data.maxCount)
            {
                slots[i].slotQuantity++;
                GameManager.Instance.Player.currentData = null;
                UpdateUI();
                return;
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].data == null)
            {
                slots[i].data = itemData;
                slots[i].slotQuantity = 1;
                slots[i].delayTime = itemData.delayTime;
                GameManager.Instance.Player.currentData = null;
                UpdateUI();
                return;
            }
        }
    }

    // Slot의 각 정보들 정보 갱신
    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].data != null)
            {
                slots[i].Set();
            }
            else
            {
                slots[i].Clear();
            }
        }
    }

    // 아이템 있는지 확인
    public bool CheckItem(string name, int value)
    {
        int addValue = value;
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].data == null)
            {
                continue;
            }

            // 아이템이 있다면
            if (slots[i].data.itemName == name)
            {
                addValue -= slots[i].slotQuantity;
                if (addValue <= 0)
                {
                    return true;
                }
            }
        }
        return false;
    }

    // 아이템 삭제
    public void RemoveItem(string name, int value)
    {
        int Add = value;
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].data == null)
            {
                continue;
            }

            // 아이템과 같은 이름 검색
            if (slots[i].data.itemName == name)
            {
                Add -= slots[i].slotQuantity;
                if (Add >= 0)
                {
                    slots[i].Clear();
                }
                else
                {
                    slots[i].slotQuantity = -Add;
                }

                if (Add <= 0)
                {
                    break;
                }
            }
        }
        
    }

    // 인벤토리 UI 키고 닫기
    public void OnInventory(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (inventoryObject.activeInHierarchy)
            {
                GameManager.Instance.Player.cursor.invenCursor = true;
                GameManager.Instance.Player.cursor.CursorCheck();
                inventoryObject.SetActive(false);
                GameManager.Instance.Player.cursor.gameObject.SetActive(false);
            }
            else
            {
                GameManager.Instance.Player.cursor.invenCursor = false;
                GameManager.Instance.Player.cursor.CursorCheck();
                inventoryObject.SetActive(true);
            }
        }
    }
}
