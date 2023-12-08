using UnityEngine.UI;

public class MusicMute : ToggleClick
{
    protected override void ToggleValueChanged(Toggle toggle)
    {
        audioManager.SetMusicMute(toggle.isOn);
    }

    protected override void SetValue()
    {
        Toggle.isOn = audioManager.IsMusicMute;
    }
}
