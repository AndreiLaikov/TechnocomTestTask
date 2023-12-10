using UnityEngine;

namespace TechnoApp.Managers
{
    [RequireComponent (typeof(AudioSource))]
    public class AudioManager : Singleton<AudioManager>
    {
        private AudioSource audioSource;
        public AudioClip buttonSound;
        public AudioClip music;

        public bool IsMusicMute;
        public bool IsSoundsMute;

        private string isSoundsMute_key = "IsSoundMute";
        private string isMusicMute_key = "IsMusicMute";

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = music;
            LoadPrefs();
            PlayMusic();
        }

        public void PlaySound()
        {
            if (!IsSoundsMute)
            {
               audioSource.PlayOneShot(buttonSound);
            }
        }

        public void SetSoundsMute(bool value)
        {
            IsSoundsMute = value;
            SavePrefs(isSoundsMute_key, IsSoundsMute);
        }

        public void SetMusicMute(bool value)
        {
            IsMusicMute = value;
            PlayMusic();
            SavePrefs(isMusicMute_key,IsMusicMute);
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
            IsSoundsMute = intToBool(PlayerPrefs.GetInt(isSoundsMute_key));
            IsMusicMute = intToBool(PlayerPrefs.GetInt(isMusicMute_key));
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