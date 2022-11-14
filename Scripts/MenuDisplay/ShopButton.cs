using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanelObject;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _closeButton;

    private void OnEnable()
    {
        _shopButton.onClick.AddListener(OnOpened);
        _closeButton.onClick.AddListener(OnClosed);
    }

    private void OnDisable()
    {
        _shopButton.onClick.RemoveListener(OnOpened);
        _closeButton.onClick.RemoveListener(OnClosed);
    }

    private void OnOpened() => _shopPanelObject.SetActive(true);
    private void OnClosed() => _shopPanelObject.SetActive(false);
}
