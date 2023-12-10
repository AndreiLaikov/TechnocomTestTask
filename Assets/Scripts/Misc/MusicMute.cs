using UnityEngine.UI;

namespace TechnoApp.Misc
{
    public class MusicMute : ToggleClick
    {
        protected override void ToggleValueChanged(Toggle toggle)
        {
            base.ToggleValueChanged(toggle);
            audioManager.SetMusicMute(toggle.isOn);
        }

        protected override void SetValue()
        {
            Toggle.isOn = audioManager.IsMusicMute;
        }
    }
}