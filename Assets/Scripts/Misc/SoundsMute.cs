using UnityEngine.UI;

namespace TechnoApp.Misc
{
    public class SoundsMute : ToggleClick
    {
        protected override void ToggleValueChanged(Toggle toggle)
        {
            base.ToggleValueChanged(toggle);
            audioManager.SetSoundsMute(toggle.isOn);
        }

        protected override void SetValue()
        {
            Toggle.isOn = audioManager.IsSoundsMute;
        }
    }
}