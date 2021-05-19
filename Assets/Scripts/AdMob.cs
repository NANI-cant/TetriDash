using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMob : MonoBehaviour
{
    private InterstitialAd interstitialAd;
    private RewardBasedVideoAd videoAd;
    private string interstitialAdID,videoAdID;

    private void Awake(){
        MobileAds.Initialize(initStatus=>{});
        interstitialAdID = "ca-app-pub-3940256099942544/1033173712";
        videoAdID = "ca-app-pub-3940256099942544/5224354917";
        videoAd = RewardBasedVideoAd.Instance;
        RequestInterstitialAd();
        RequestVideoAd();
    }

    private AdRequest AdRequestBuild(){
        return new AdRequest.Builder().Build();
    }

    private void RequestInterstitialAd(){
        interstitialAd = new InterstitialAd(interstitialAdID);
        AdRequest request = AdRequestBuild();
        interstitialAd.LoadAd(request);

        interstitialAd.OnAdLoaded += this.HandleOnAdLoaded;
        interstitialAd.OnAdOpening += this.HandleOnAdOpening;
        interstitialAd.OnAdClosed += this.HandleOnAdClosed;
    }

    public void ShowInterstitialAd(){
        if(interstitialAd.IsLoaded()){
            interstitialAd.Show();
        }
    }

    private void OnDestroy(){
        DestroyInterstitialAd();
        
        interstitialAd.OnAdLoaded -= this.HandleOnAdLoaded;
        interstitialAd.OnAdOpening -= this.HandleOnAdOpening;
        interstitialAd.OnAdClosed -= this.HandleOnAdClosed;

        videoAd.OnAdLoaded -= this.HandleRewardedAdLoaded;
        videoAd.OnAdFailedToLoad -= this.HandleRewardedAdFailedToLoad;
        videoAd.OnAdRewarded -= this.HandleUserEarnedReward;
        videoAd.OnAdClosed -= this.HandleRewardedAdClosed;
    }

    private void HandleOnAdClosed(object sender, EventArgs e){
        interstitialAd.OnAdLoaded -= this.HandleOnAdLoaded;
        interstitialAd.OnAdOpening -= this.HandleOnAdOpening;
        interstitialAd.OnAdClosed -= this.HandleOnAdClosed;

        RequestInterstitialAd();
    }

    private void HandleOnAdOpening(object sender, EventArgs e){
        
    }

    private void HandleOnAdLoaded(object sender, EventArgs e){
        
    }

    private void DestroyInterstitialAd(){
        interstitialAd.Destroy();
    }

    public void RequestVideoAd(){
        AdRequest request  = AdRequestBuild();
        videoAd.LoadAd(request, videoAdID);
        videoAd.OnAdLoaded += this.HandleRewardedAdLoaded;
        videoAd.OnAdFailedToLoad += this.HandleRewardedAdFailedToLoad;
        videoAd.OnAdRewarded += this.HandleUserEarnedReward;
        videoAd.OnAdClosed += this.HandleRewardedAdClosed;
    }

    private void HandleRewardedAdLoaded(object sender, EventArgs e){
        ShowVideoAd();
    }

    private void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs e){
    }

    private void HandleUserEarnedReward(object sender, Reward e){
        
    }

    private void HandleRewardedAdClosed(object sender, EventArgs e)
    {
        videoAd.OnAdLoaded -= this.HandleRewardedAdLoaded;
        videoAd.OnAdFailedToLoad -= this.HandleRewardedAdFailedToLoad;
        videoAd.OnAdRewarded -= this.HandleUserEarnedReward;
        videoAd.OnAdClosed -= this.HandleRewardedAdClosed;

    }

    public void ShowVideoAd(){
        if(videoAd.IsLoaded()){
            videoAd.Show();
        }
    }
}
