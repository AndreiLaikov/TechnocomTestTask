using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TechnoApp.Levels
{
    [RequireComponent(typeof(Button))]
    public class LevelsView : MonoBehaviour
    {
        public int LevelNumber;
        [SerializeField] private TMP_Text levelLabel;
        [SerializeField] private GameObject lockIcon;
        [SerializeField] private Button levelButton;

        private LevelProgressController controller;

        public void Init(LevelProgressController progressController)
        {
            controller = progressController;

            levelButton = GetComponent<Button>();
            levelButton.onClick.AddListener(() => controller.LevelComplete(LevelNumber));

            levelLabel.text = LevelNumber.ToString();
        }

        public void SetState(bool levelUnlocked)
        {
            lockIcon.SetActive(!levelUnlocked);
            levelLabel.enabled = levelUnlocked;
            levelButton.interactable = levelUnlocked;
        }
    }
}
