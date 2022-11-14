using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menue : MonoBehaviour
{
    [SerializeField] private List<GameObject> _buttons;
    [SerializeField] private GameObject _buttonsInviteFriend;
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    [SerializeField] private Color _closedColor;
    [SerializeField] private Color _openedColor;

    private bool _ishide = true;

    public event Action<bool> HidedMenue;

    public bool IsHide => _ishide;

    private void OnEnable() => _button.onClick.AddListener(OnHide);

    private void OnDisable() => _button.onClick.RemoveListener(OnHide);

    private void Start() => Hide();

    private void OnHide()
    {
        _ishide = _ishide == true ? false : true;
        Hide();
        HidedMenue?.Invoke(_ishide);
    }

    private void Hide()
    {
        foreach (var button in _buttons)
        {
            //button.SetActive(!_ishide);
            if (button.TryGetComponent(out LeaderBoardButton _) == true)
            {
#if VK_GAMES
                button.SetActive(false);
#endif

#if VK_GAMES_MOBILE
                button.SetActive(!_ishide);
#endif

#if YANDEX_GAMES
                button.SetActive(!_ishide);
#endif
            }
            else if (button.TryGetComponent(out InviteFriendsButton _) == true)
            {
#if VK_GAMES
                button.SetActive(!_ishide);
#endif
            }
            else
                button.SetActive(!_ishide);

        }



        _image.color = _ishide == false ? _closedColor : _openedColor;
    }

}
