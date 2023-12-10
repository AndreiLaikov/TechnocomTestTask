using TechnoApp.Managers;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => PlaySound());
    }

    private void PlaySound()
    {
        AudioManager.Instance.PlaySound(); 
    }
}
