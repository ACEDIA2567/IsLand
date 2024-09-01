using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public GameObject gameClearPanel;
    public GameObject gameOverPanel;

    private void Awake()
    {
        GameManager.Instance.uiManager = this;
    }

    // 게임 클리어 시 UI활성화
    public void GameClear()
    {
        gameClearPanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }

    // 게임 오버 시 UI활성화
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
    }
}
