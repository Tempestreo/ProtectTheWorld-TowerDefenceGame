using GoogleMobileAds.Api;
using UnityEngine;

public class AdmobManager : MonoBehaviour
{
    private BannerView bannerView;

    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        this.RequestBanner();
    }

    private void RequestBanner()
    {
        string adUnitId = "ca-app-pub-5126783762930243/6948581027";         //test id'si ger�ek reklam i�in de�i�tirilecek

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(request);
    }
    public void CloseBanner()
    {
        bannerView.Destroy();
    }
}