using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return instance;
        }
    }

    private Player player;
    public  Player Player
    {
        get { return player; }
        set { player = value; }
    }

    // 게임 클리어 확인
    public bool fireCheck = false;
    public bool stoneSOS = false;
    public DayNightCycle dayNightCycle;
    public SpawnManger spawnManger;
    public UIManager uiManager;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    // 모닥불과 SOS설치시 엔딩 날짜 시작
    public void EndingCheck()
    {
        // 모닥불과 SOS돌을 모두 설치 했다면
        if(fireCheck && stoneSOS)
        {
            Debug.Log("엔딩 시작");
            dayNightCycle.EndingStart();
        }
    }
}
