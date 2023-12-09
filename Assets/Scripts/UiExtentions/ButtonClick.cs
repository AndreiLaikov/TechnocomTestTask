using TechnoApp.Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour, IPointerClickHandler
{
    private Selectable selectable;

    void Start()
    {
        selectable = GetComponent<Selectable>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (selectable.interactable)
        {
            AudioManager.Instance.PlaySound();
        }
    }
}
