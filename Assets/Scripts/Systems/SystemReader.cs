using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SystemReader : MonoBehaviour
{
    [Header("UI Setup")]
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI logs;
    public TextMeshProUGUI appVersion;

    private string m_DeviceName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logs.text = string.Empty;

        m_DeviceName = SystemInfo.deviceName;
        playerNameText.text = $"Hi,<color=#FFFB00> {m_DeviceName.ToUpperInvariant()} </color>";


        appVersion.text = string.Empty;
        appVersion.text = $"<color=#38b6ff>Application Version: </color><color=#ff3131>{Application.version}</color>";
    }

    public void Settings()
    {
        EventSystem.current.SetSelectedGameObject(null);

        logs.text = $"<color=#38b6ff>{SystemInfo.deviceModel}</color>Doesnot Support Setting Modification";
    }
}
