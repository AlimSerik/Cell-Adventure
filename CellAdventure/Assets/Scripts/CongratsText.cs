using UnityEngine;
using TMPro;

public class CongratsText : MonoBehaviour
{
    [SerializeField] private TMP_Text congratsText;

    public void ShowCongrats()
    {
        congratsText.gameObject.SetActive(true);
    }
}
