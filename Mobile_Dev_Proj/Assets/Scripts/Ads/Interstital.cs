using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Interstital : MonoBehaviour , IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] private string andAdUnitId;
    [SerializeField] private string iosAdUnitId;

    private string adUnitId;

    private void Awake()
    {
#if UNITY_IOS
            adUnitId = iosAdUnitId;
#elif UNITY_ANDROID
        adUnitId = andAdUnitId;
#endif
    }

    public void LoadInterstital()
    {
        Advertisement.Load(adUnitId, this);
    }

    public void ShowInterstital()
    {
        Advertisement.Show(adUnitId, this);
        LoadInterstital();
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Interstital Loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
    }

    public void OnUnityAdsShowStart(string placementId)
    {
    }

    public void OnUnityAdsShowClick(string placementId)
    {
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Interstitial completed");
        //SceneSwitcher.Instance.LoadSceneByName("EndScene");
    }
}
