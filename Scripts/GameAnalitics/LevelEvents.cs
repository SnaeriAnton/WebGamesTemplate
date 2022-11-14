using Agava.GameAnalitics;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelEvents : MonoBehaviour
{
    [SerializeField] private FinishGA _finished;
    [SerializeField] private MoneyHolderGA _money;

    private string _defaultDate = "00.00.00";
    private int _defaultIndex = 0;
    private int _setCountIndex = 1;
    private int _stepCountLevel = 1;
    private bool _instance = false;

    public const string RegistrationDate = nameof(RegistrationDate);
    public const string SessionCount = nameof(SessionCount);
    public const string SetSessionCount = nameof(SetSessionCount);


    public event Action Won;
    public event Action Lose;
    public event Action<int> ChangedCoins;
    public event Action<string> RegisteredDate;
    public event Action<int> SessionCounterChanged;

#if VK_GAMES
    private void OnEnable()
    {
        _finished.Victoryed += OnWin;
        _finished.Losed += OnLose;
        _money.Changed += OnParameteImproved;
    }

    private void OnDisable()
    {
        _finished.Victoryed -= OnWin;
        _finished.Losed -= OnLose;
        _money.Changed -= OnParameteImproved;
    }

    private void Start()
    {
        RegistrateDate();
        CountSession();
    }

    private void OnWin() => Won?.Invoke();

    private void OnLose() => Lose?.Invoke();

    private void OnParameteImproved(int coins) => ChangedCoins?.Invoke(coins);

    private void CountSession()
    {
        int count = PlayerPrefs.GetInt(SessionCount, _defaultIndex) + _stepCountLevel;
        int value = PlayerPrefs.GetInt(SetSessionCount, _defaultIndex);

        if (value != 0)
        {
            PlayerPrefs.SetInt(SessionCount, count);
            PlayerPrefs.SetInt(SetSessionCount, _setCountIndex);
        }

        SessionCounterChanged?.Invoke(count);
    }

    private void RegistrateDate()
    {
        string date = PlayerPrefs.GetString(RegistrationDate, _defaultDate);

        if (date == _defaultDate)
        {
            date = System.DateTime.UtcNow.ToString();
            PlayerPrefs.SetString(RegistrationDate, date);
        }

        RegisteredDate?.Invoke(date);
    }

    private void ResetSetCountValue()
    {
        int value = PlayerPrefs.GetInt(SetSessionCount, _defaultIndex);

        if (value == _setCountIndex)
            PlayerPrefs.SetInt(SetSessionCount, _defaultIndex);
    }

    private void OnDestroy() => ResetSetCountValue();
#endif
}
