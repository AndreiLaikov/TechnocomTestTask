using TechnoApp.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace TechnoApp.Misc
{
    public class ButtonClick : MonoBehaviour
    {
        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(() => PlaySound());
        }

        private void PlaySound()
        {
            AudioManager.Instance.PlaySound();
        }
    }
}