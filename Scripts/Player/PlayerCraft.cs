using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCraft : MonoBehaviour
{
    ItemData data;
    GameObject PreviwerObject;

    RaycastHit hitInfo;
    public LayerMask layerMask;
    public int slotIndex;
    bool creaftMode = false;
    new Camera camera;

    private void Start()
    {
        data = null;
        camera = Camera.main;
    }

    // 아이템 사용 후 빌딩 아이템 일시 아이템 정보를 확인
    public void GetData(ItemData data, int index)
    {
        // 크래프트 모드일 경우 데이터 받지 못하게 함
        if (this.data != null) return;
        PreviwerObject = Instantiate(data.ViewObject);
        slotIndex = index;
        this.data = data;
    }

    private void Update()
    {
        if (data != null)
        {
            ViewerItemUpdate();
        }
    }

    // 아이템 설치
    private void ViewerItemUpdate()
    {
        // 카메라 정면으로 Ray를 발사하여 설정한 Layer에 충돌한 지점을 찾는다.
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hitInfo, 10, layerMask))
        {
            // 충돌 지점이 존재한다면
            if (hitInfo.transform != null)
            {
                // 설치할 프리뷰 오브젝트의 위치를 충돌한 위치로 이동시킨다.
                PreviwerObject.transform.position = hitInfo.point;
                if (creaftMode && PreviwerObject.GetComponent<MeshRenderer>().material.color == Color.green)
                {
                    // 엔딩 조건인 SOS와 모닥불 여부를 위해 확인
                    if (data.itemName == "SOS돌")
                    {
                        GameManager.Instance.stoneSOS = true;
                        GameManager.Instance.EndingCheck();
                    }
                    else if (data.itemName == "모닥불")
                    {
                        GameManager.Instance.fireCheck = true;
                        GameManager.Instance.EndingCheck();
                    }

                    // 설치류 오브젝트를 설치한다.
                    Instantiate(data.dropPrefab, hitInfo.point, Quaternion.identity);
                    // 선택한 아이템을 Null처리
                    data = null;
                    Destroy(PreviwerObject);
                    // 인벤토리의 아이템 삭제
                    GameManager.Instance.Player.inventory.GetSlot(slotIndex).Clear();
                    slotIndex = -1;
                }
            }
        }
        // ESC 누르면 건축 취소
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            data = null;
            Destroy(PreviwerObject);
            slotIndex = -1;
        }
    }

    // 좌클릭으로 오브젝트 설치
    public void OnBuild(InputAction.CallbackContext context)
    {
        // 클릭 시 설치
        if(context.phase == InputActionPhase.Started)
        {
            creaftMode = true;
        }
        // 클릭 취소 시 미설치
        else if(context.phase == InputActionPhase.Canceled)
        {
            creaftMode = false;
        }
    }
}
