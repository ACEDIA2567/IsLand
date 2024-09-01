using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIProduce : MonoBehaviour
{
    public GameObject ProduceObject;

    void Start()
    {
        // 제작 UI 비활성화
        ProduceObject.SetActive(false);
    }

    // 제작법 UI 비/활성화 처리
    public void OnProduce(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (ProduceObject.activeInHierarchy)
            {
                GameManager.Instance.Player.cursor.craftCursor = true;
                GameManager.Instance.Player.cursor.CursorCheck();
                ProduceObject.SetActive(false);
            }
            else
            {
                GameManager.Instance.Player.cursor.craftCursor = false;
                GameManager.Instance.Player.cursor.CursorCheck();
                ProduceObject.SetActive(true);
            }
        }
    }
}
