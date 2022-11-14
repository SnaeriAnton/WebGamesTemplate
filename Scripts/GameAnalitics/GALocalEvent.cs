using UnityEngine;
using UnityEngine.SceneManagement;

namespace Agava.GameAnalitics
{
    [RequireComponent(typeof(GAInstance))]
    public class GALocalEvent : MonoBehaviour
    {
        [SerializeField] private LevelEvents _level;

        public const string Levelecounter = nameof(Levelecounter);

        private void Start()
        {
            OnLevelStart();
        }

        private void OnEnable()
        {
            _level.Won += OnLevelComplete;
            _level.Lose += OnLevelFail;
            _level.ChangedCoins += OnSoftSpent;
            _level.RegisteredDate += OnRegDay;
            _level.SessionCounterChanged += OnSessionCount;
        }

        private void OnDisable()
        {
            _level.Won -= OnLevelComplete;
            _level.Lose -= OnLevelFail;
            _level.ChangedCoins -= OnSoftSpent;
            _level.RegisteredDate -= OnRegDay;
            _level.SessionCounterChanged -= OnSessionCount;
        }

        private void OnLevelComplete()
        {
            GAInstance.Instance.OnLevelComplete(PlayerPrefs.GetInt(Levelecounter));
        }

        private void OnLevelStart()
        {
            GAInstance.Instance.OnLevelStart(SceneManager.GetActiveScene().buildIndex);
        }

        private void OnLevelFail()
        {
            GAInstance.Instance.OnLevelFail(SceneManager.GetActiveScene().buildIndex);
        }

        private void OnRegDay(string date)
        {
            GAInstance.Instance.OnRegDay(date);
        }

        private void OnSessionCount(int SessionCount)
        {
            GAInstance.Instance.OnSessionCount(SessionCount);
        }

        private void OnSoftSpent(int coins)
        {
            GAInstance.Instance.OnSoftSpent(coins);
        }
    }
}
