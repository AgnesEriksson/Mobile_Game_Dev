using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        StartCoroutine(DisplayBannerDelay());

    }

    public void GameOver()
    {
        AdsManager.Instance.banner.HideBanner();
        ScoreManager.Instance.CheckHighScore();
        SceneSwitcher.Instance.LoadSceneByName("EndScene");
        AdsManager.Instance.interstital.ShowInterstital();
    }

    private IEnumerator DisplayBannerDelay()
    {
        yield return new WaitForSeconds(1f);
        AdsManager.Instance.banner.ShowBanner();
    }
}
