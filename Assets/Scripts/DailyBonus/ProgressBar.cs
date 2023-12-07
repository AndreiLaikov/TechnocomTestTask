using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TechnoApp.Dailybonus
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private Slider progressBar;
        [SerializeField] private TextMeshProUGUI currentProgress;

        public void SetValues(int value)
        {
            value++;
            progressBar.value = value;
            currentProgress.text = value + "/7";
        }
    }
}
