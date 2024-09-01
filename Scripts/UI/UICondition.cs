using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition hp;
    public Condition sp;
    public Condition ep;
    public Condition wp;

    private void Start()
    {
        GameManager.Instance.Player.condition.conditions = this;
    }
}
