using UnityEngine;

namespace TechnoApp.Levels
{
    public class LevelProgressController : MonoBehaviour
    {
        [SerializeField] private LevelsView[] levels;
        private int currentLevel;

        private void Awake()
        {
            levels = GetComponentsInChildren<LevelsView>();
            currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);

            foreach (LevelsView lvl in levels)
            {
                lvl.Init(this);
            }

            UpdateLevels();
        }

        private void UpdateLevels()
        {
            for (int i = 0; i < levels.Length; i++)
            {
                var levelUnlocked = currentLevel >= i + 1;
                levels[i].SetState(levelUnlocked);
            }
        }

        public void LevelComplete(int levelNumber)
        {
            if(levelNumber >= currentLevel)
            {
                currentLevel = levelNumber + 1;
            }

            PlayerPrefs.SetInt("CurrentLevel", levelNumber);
            PlayerPrefs.Save();

            UpdateLevels();
        }

        [ContextMenu("ResetProgress")]
        private void ResetProgress()
        {
            PlayerPrefs.SetInt("CurrentLevel", 1);
            PlayerPrefs.Save();
        }

        [ContextMenu("Create")]
        private void CreateList()
        {
            levels = GetComponentsInChildren<LevelsView>();

            for (int i = 0; i < levels.Length; i++)
            {
                levels[i].LevelNumber = i + 1;
            }
        }
    }
}