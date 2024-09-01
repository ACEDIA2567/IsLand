using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Equipment : MonoBehaviour
{
    public Equip curEquip;
    public Transform equipParent;

    // 장비 장착
    public void EquipNew(ItemData data)
    {
        UnEquip();
        curEquip = Instantiate(data.dropPrefab, equipParent).GetComponent<Equip>();
    }

    // 장비 해제
    public void UnEquip()
    {
        if(curEquip != null)
        {
            Destroy(curEquip.gameObject);
            curEquip = null;
        }
    }

    // 장비 장착 후 좌클릭 시 행동
    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed && curEquip != null)
        {
            curEquip.OnAttackInput();
        }
    }
}
