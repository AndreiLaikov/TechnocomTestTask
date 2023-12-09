using UnityEngine;
using UnityEngine.UI;

public class ClosePopup : MonoBehaviour
{
    [SerializeField] private Button buttonClose;
    [SerializeField] private GameObject popUp;

    private void Start()
    {
        if (buttonClose == null)
        {
            buttonClose = GetComponent<Button>();
        }

        buttonClose.onClick.AddListener(()=>Close());
    }

    private void Close()
    {
        popUp.SetActive(false);
    }
}
