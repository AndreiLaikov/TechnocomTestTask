using UnityEngine;

namespace TechnoApp.Managers
{
    [RequireComponent (typeof(AudioSource))]
    public class AudioManager : Singleton<AudioManager>
    {
        private AudioSource audioSource;
        public AudioClip ClickSound;
        public AudioClip Music;

        public bool IsMusicMute;
        public bool IsSoundsMute;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = Music;
            LoadPrefs();
            PlayMusic();
        }

        public void PlaySound()
        {
            if (!IsSoundsMute)
            {
                audioSource.PlayOneShot(ClickSound);
            }
        }

        public void SetSoundsMute(bool value)
        {
            IsSoundsMute = value;
            SavePrefs(StaticStrings.SoundsMute_key, IsSoundsMute);
        }

        public void SetMusicMute(bool value)
        {
            IsMusicMute = value;
            PlayMusic();
            SavePrefs(StaticStrings.MusicMute_key, IsMusicMute);
        }

        private void PlayMusic()
        {
            if (IsMusicMute)
                audioSource.Stop();
            else
                audioSource.Play();
        }

        private void SavePrefs(string key, bool value)
        {
            PlayerPrefs.SetInt(key, boolToInt(value));
            PlayerPrefs.Save();
        }

        private void LoadPrefs()
        {
            IsSoundsMute = intToBool(PlayerPrefs.GetInt(StaticStrings.SoundsMute_key));
            IsMusicMute = intToBool(PlayerPrefs.GetInt(StaticStrings.MusicMute_key));
        }

        int boolToInt(bool val)
        {
            return val ? 1 : 0;
        }

        bool intToBool(int val)
        {
            return val != 0;
        }
    }
}