using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;
    public PlayerCraft creaft;
    public Equipment euipment;

    public ItemData currentData;
    public int dataQuantity = 0;
    public float dataDelayTime = 0;
    public Action AddItem;

    public UICursor cursor;
    public UIInventory inventory;

    private void Awake()
    {
        GameManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
        creaft = GetComponent<PlayerCraft>();
        euipment = GetComponent<Equipment>();
    }

    public void CursorSet()
    {
        if(Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    // 아이템 사용 시 쿨타임 코루틴 여기서 실행
    public void StartCo(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }

    // 사용 중인 코루틴 중지
    public void EndCo(IEnumerator coroutine)
    {
        StopCoroutine(coroutine);
    }

    // 플레이어의 아이템 정보 삭제
    public void ItemClear()
    {
        currentData = null;
        dataQuantity = 0;
        dataDelayTime = 0;
    }
}
