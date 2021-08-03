using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Scripting;
using GoogleMobileAds.Api;

[Preserve]
public class AdMob : MonoBehaviour
{
    [SerializeField] UIActivator _ui;
    [SerializeField] private string interstitialAdIdAndroid = "ca-app-pub-3940256099942544/1033173712";
    [SerializeField] private string rewardedAdIdAndroid = "ca-app-pub-3940256099942544/5224354917";
    private InterstitialAd interstitialAd;
    private RewardedAd rewardedAd;

    private void Awake(){
        MobileAds.Initialize(initStatus=>{});
        RequestInterstitial();
        RequestRewarded();
    }

    private void RequestRewarded(){
        #if UNITY_ANDROID
            string adUnitId = rewardedAdIdAndroid;
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
            string adUnitId = "unexpected_platform";
        #endif
        rewardedAd = new RewardedAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request);
        rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
    }

    public void TryToShowRewardedAd(){
        if(rewardedAd.IsLoaded()){
            rewardedAd.Show();
        }else{
            Debug.Log("Rewarded Ad dont load yeat");
        }
    }

    public void HandleUserEarnedReward(object sender, Reward args){
        Debug.Log("reward! = " + args.Amount.ToString());
        _ui.ContinueGame();
    }

    private void RequestInterstitial(){
        #if UNITY_ANDROID
            string adUnitId = interstitialAdIdAndroid;
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/4411468910";
        #else
            string adUnitId = "unexpected_platform";
        #endif
        interstitialAd = new InterstitialAd(adUnitId);
        interstitialAd.OnAdClosed += HandleOnAdClosed;
        AdRequest request = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(request);
    }

    public void TryToShowInterstitialAd(){
        if (interstitialAd.IsLoaded()) {
            interstitialAd.Show();
        }else{
            Debug.Log("Interstitial ad dont load yeat");
        }
    }

    public void HandleOnAdClosed(object sender, EventArgs args){
        interstitialAd.Destroy();
    }

    private void OnDisable(){
        rewardedAd.OnUserEarnedReward-=HandleUserEarnedReward;
    }
}
