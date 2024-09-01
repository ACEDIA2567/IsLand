using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICursor : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemType;
    public TextMeshProUGUI itemDec;

    public bool invenCursor = true;
    public bool craftCursor = true;

    public GameObject itemDrag;

    ItemData data;

    void Start()
    {
        GameManager.Instance.Player.cursor = this;
        gameObject.SetActive(false);
    }

    // 커서 모드 확인
    public void CursorCheck()
    {
        if (invenCursor && craftCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    
    // 아이템 정보 UI
    public void UIUpdate(ItemData data)
    {
        if (this.data != data || this.data == null)
        {
            this.data = data;
            gameObject.SetActive(true);
            itemName.text = data.itemName;
            itemType.text = data.type.ToString();
            itemDec.text = data.description;
        }
        else
        {
            this.data = null;
            gameObject.SetActive(false);
        }
    }
}
