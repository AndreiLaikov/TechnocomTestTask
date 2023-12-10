using TechnoApp.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace TechnoApp.Misc
{
    public abstract class ToggleClick : MonoBehaviour
    {
        protected Toggle Toggle;
        protected AudioManager audioManager;

        private void Start()
        {
            Toggle = GetComponent<Toggle>();
            Toggle.onValueChanged.AddListener(delegate { ToggleValueChanged(Toggle); });

            audioManager = AudioManager.Instance;
            SetValue();
        }

        protected virtual void ToggleValueChanged(Toggle toggle)
        {
            AudioManager.Instance.PlaySound();
        }

        protected virtual void SetValue() { }
    }
}