using UnityEngine;

namespace Project.Scripts.Architecture.Progress
{
    class PlayerProgress : IPlayerProgress
    {
        private const string SaveKey = "Save";

        public int GetActiveLevel()
        {
            if (PlayerPrefs.HasKey(SaveKey))
            {
                return PlayerPrefs.GetInt(SaveKey);
            }
            else
            {
                PlayerPrefs.SetInt(SaveKey, 1);
                PlayerPrefs.Save();
                return 1;
            }
        }

        public void MoveNextLevel()
        {
            PlayerPrefs.SetInt(SaveKey, GetActiveLevel() + 1);
            PlayerPrefs.Save();
        }
    }
}