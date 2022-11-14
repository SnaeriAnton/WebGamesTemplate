using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private LeaderBoardDisplay _leaderBoardDisplay;
    [SerializeField] private Button _closeButton;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
        _closeButton.onClick.AddListener(OnCloseClock);
        _leaderBoardDisplay.SetLeaderboardScore();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
        _closeButton.onClick.RemoveListener(OnCloseClock);
    }

    private void OnCloseClock()
    {
        Hide();
    }

    private void OnClick()
    {
        if (_leaderBoardDisplay.gameObject.activeSelf)
            Hide();
        else
            Show();
    }

    private void Show()
    {

#if VK_GAMES
        _leaderBoardDisplay.OpenVKLeaderboard();
#endif

#if YANDEX_GAMES
        Time.timeScale = 0;
        _leaderBoardDisplay.gameObject.SetActive(true);
        _leaderBoardDisplay.SetLeaderboardScore();
        _leaderBoardDisplay.OpenYandexLeaderboard();
#endif
    }

    private void Hide()
    {
        _leaderBoardDisplay.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
