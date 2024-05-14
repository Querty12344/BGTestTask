using Project.Scripts.UI.Elements;
using UnityEngine;

namespace Project.Scripts.UI.Windows
{
    public class HUDWindow : MonoBehaviour
    {
        [SerializeField] private StartGameButton _startGameButton;

        public void Remove()
        {
            Destroy(gameObject);
        }

        public StartGameButton StartButton()
        {
            return _startGameButton;
        }
    }
}