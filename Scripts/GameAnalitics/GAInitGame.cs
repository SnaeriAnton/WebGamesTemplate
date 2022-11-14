using UnityEngine;

namespace Agava.GameAnalitics
{
    public class GAInitGame : MonoBehaviour
    {
        private bool _instance;

        private void Start()
        {
#if VK_GAMES
            if (_instance == false)
            {
                GAInstance.Instance.GameInitialize();
                _instance = true;
            }
#endif
        }
    }
}

