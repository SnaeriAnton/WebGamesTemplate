 using System;
using Agava.VKGames;
using UnityEngine;
using Agava.YandexGames;

public class Ad : MonoBehaviour
{
    [SerializeField] private SDKInitializer _sdkInitializer;

    private bool _isInitialize = false;

    public event Action Rewarded;
    public event Action VideoOpened;
    public event Action VideoClosed;

    private void OnEnable() => _sdkInitializer.Initialized += OnInitialized;

    private void OnDisable() => _sdkInitializer.Initialized -= OnInitialized;

    private void Start() => Debug.Log("Ad show");

    public void InterestialAdShow(Action onCallbackVK = null, Action<bool> onCloseCallbackYandex = null)
    {
        if (!_isInitialize)
            return;

        Time.timeScale = 0;

#if YANDEX_GAMES
        InterstitialAd.Show(onCloseCallback: onCloseCallbackYandex);
#endif

#if VK_GAMES
        Interstitial.Show(onOpenCallback: onCallbackVK);
#endif
    }

    public void VideoAdShow(Action onCallback)
    {
        if (!_isInitialize)
            return;

#if UNITY_EDITOR
        OnRewardedCallback();
        OnVideoCloseCallback();
        return;
#endif

        Time.timeScale = 0;

#if YANDEX_GAMES
        Agava.YandexGames.VideoAd.Show(onCloseCallback: onCallback);
#endif

#if VK_GAMES
        Agava.VKGames.VideoAd.Show(onRewardedCallback: onCallback);
#endif
    }

    private void OnInitialized()
    {
        _isInitialize = true;
    }

    private void OnVideoOpenCallback()
    {
        VideoOpened?.Invoke();
    }

    private void OnVideoCloseCallback()
    {
        VideoClosed?.Invoke();
    }

    private void OnRewardedCallback()
    {
        Rewarded?.Invoke();
    }

    private void OnVideoErrorCallback(string message)
    {
        Debug.LogError(message);
    }
}
