using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class AdsRewarded : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] Button showAdButton;
    [SerializeField] string androidAdUnitId = "Rewarded_Android";
    [SerializeField] string iOSAdUnitId = "Rewarded_IOS";
    string adUnitId = null;

    void Awake(){
    #if UNITY_IOS
        adUnitId = iOSAdUnitId;
    #elif UNITY_ANDROID
        adUnitId = androidAdUnitId;
    #endif
        showAdButton.onClick.AddListener(ShowAd);
        showAdButton.interactable = false;
    }

    //Load the ad
    public void LoadAd(){
        Debug.Log("Loading Ad: " + adUnitId);
        Advertisement.Load(adUnitId, this);
    }

    //The ad was loaded
    public void OnUnityAdsAdLoaded(string _adUnitId){
        Debug.Log("Ad Loaded: " + adUnitId);
        if(_adUnitId.Equals(adUnitId)){
            
            showAdButton.interactable = true;
        }
    }

    //Show the ad
    public void ShowAd() {
        showAdButton.interactable = false;
        Advertisement.Show(adUnitId, this);
    }

    //Give reward if ad is watched
    public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState){
        if(_adUnitId.Equals(adUnitId) && showCompletionState.Equals(UnityAdsCompletionState.COMPLETED)){
            Debug.Log("Unity Ads Rewarded Ad Completed");
            //Respawn the player;c
            FindObjectOfType<StartGame>().Respawn();
        }
        LoadAd();
    }

    //Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message) {
        Debug.Log($"Errpr loading Ad Unit {_adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message) {
        Debug.Log($"Error showing Ad Unit {_adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string _adUnitId) {}
    public void OnUnityAdsShowClick(string _adUnitId) {}

    void OnDestroy() {
        showAdButton.onClick.RemoveAllListeners();
    }
}
