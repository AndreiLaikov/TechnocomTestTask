using UnityEngine;
using UnityEngine.SceneManagement;

namespace TechnoApp.Misc
{
    public class SceneLoader : MonoBehaviour
    {
        public string SceneName;

        public void LoadScene()
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}