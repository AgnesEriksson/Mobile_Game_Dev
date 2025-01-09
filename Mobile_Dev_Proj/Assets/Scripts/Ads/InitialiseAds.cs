using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InitialiseAds : MonoBehaviour ,IUnityAdsInitializationListener
{
    [SerializeField] private string andId;
    [SerializeField] private string iosId;
    [SerializeField] private bool testing;

    private string gameID;

    private void Awake()
    {
#if UNITY_IOS
            gameID = iosID;
#elif UNITY_ANDROID
            gameID = andId;
#elif UNITY_EDITOR
            gameID = andId;
#endif

        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(gameID, testing, this);
        }
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Ads initilaised");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogWarning("Ads Failed to initialise");
    }
}
