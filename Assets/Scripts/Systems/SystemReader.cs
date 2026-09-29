using TMPro;
using UnityEngine;

public class SystemReader : MonoBehaviour
{
    [Header("UI Setup")]
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI batteryLevel;
    public TextMeshProUGUI logs;

    private string m_DeviceName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logs.text = string.Empty;

        m_DeviceName = SystemInfo.deviceName;
        playerNameText.text = $"Hi,<color=#00B4FF> {m_DeviceName.ToUpperInvariant()} </color>";

        batteryLevel.text = $"Battery Level: <color=yellow>{SystemInfo.batteryLevel * 100} ({SystemInfo.batteryStatus})</color>";
    }

    public void Settings()
    {
        logs.text = $"<color=yellow>{SystemInfo.deviceModel}</color> Doesnot Support Setting Modification";
    }
}
