using System;
using System.Collections;
using Agava.YandexGames;
using Agava.VKGames;
using UnityEngine;

public class SDKInitializer : MonoBehaviour
{
    private const string RusLang = "ru";

    public event Action Initialized;
    public event Action<string> Translated;

    private IEnumerator Start()
    {
#if UNITY_EDITOR
        yield break;
#endif

#if YANDEX_GAMES
        yield return YandexGamesSdk.Initialize(OnYandexSDKInitialize);
       
        Translated?.Invoke(YandexGamesSdk.Environment.i18n.lang);
#endif

#if VK_GAMES
        yield return Agava.VKGames.VKGamesSdk.Initialize(OnVKSDKInitialize);
        Translated?.Invoke(RusLang);
#endif
    }

    private void OnYandexSDKInitialize()
    {
        Initialized?.Invoke();
    }

    private void OnVKSDKInitialize()
    {
        Initialized?.Invoke();
    }
}
