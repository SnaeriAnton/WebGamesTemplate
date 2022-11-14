using GameAnalyticsSDK;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Agava.GameAnalitics
{
    public class GAInstance : MonoBehaviour
    {
        public static GAInstance Instance;

        private int _gameCount = 1;
        private void Awake()
        {
            Instance = this;

            GameAnalytics.Initialize();
        }

        private void Start()
        {
            OnEnterInMainMenu();
        }

        public void GameInitialize()
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, $"game_start, count - {_gameCount}");

            Debug.Log("GameInitialize   ----- " + gameObject.name);
        }

        public void OnSessionCount(int level)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, $"Session_Count, SessionCount - {level}");

            Debug.Log("OnSessionCount   ----- " + gameObject.name); 
        }

        public void OnRegDay(string regDay)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, $"Reg_Day, Reg_Day - {regDay}");

            Debug.Log("OnRegDay   ----- " + gameObject.name);  
        }

        public void OnLevelStart(int level)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, $"level_start, level - {level}");

            Debug.Log("OnLevelStart   ----- " + gameObject.name); 
        }

        public void OnLevelComplete(int level)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, $"level_complete, level - {level}, time_spent - {(int)Time.timeSinceLevelLoad}");

            Debug.Log("OnLevelComplete   ----- " + gameObject.name);
        }

        public void OnLevelFail(int level)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, $"level_fail, level - {level}");

            Debug.Log("OnLevelFail   ----- " + gameObject.name);
        }

        private void OnEnterInMainMenu()
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
                GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, "Enter_In_Main_Menu");

            Debug.Log("OnEnterInMainMenu   ----- " + gameObject.name); 
        }

        public void OnSoftSpent(int coins)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Fail, $"Soft_Spent, Purchases - {coins}");

            Debug.Log("OnSoftSpent   ----- " + gameObject.name);
        }
    }
}
