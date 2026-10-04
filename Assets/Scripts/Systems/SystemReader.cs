using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

// reads some system info (device name, version etc) and shows it on screen
// also has that fake "settings" thing that says the device doesn't support it lol
public class SystemReader : MonoBehaviour
{
    [Header("UI Setup")]
    public TextMeshProUGUI playerNameText; // shows the player's device name
    public TextMeshProUGUI logs;    // random messages we dump here
    public TextMeshProUGUI appVersion; // game version shown in the corner probably

    private string m_DeviceName; // just holding the device name for later

    // runs once at the start
    void Start()
    {
        // start with a clean slate, don't want old text hanging around
        logs.text = string.Empty;

        // grab the name of the pc/device the game is running on
        m_DeviceName = SystemInfo.deviceName;

        // show it all fancy with colors, uppercase cause it looks cooler that way
        playerNameText.text = $"<color=#38b6ff>Player Name:</color><color=#ff3131> {m_DeviceName.ToUpperInvariant()} </color>";

        // this line is kinda useless since we set it again right after lol
        appVersion.text = string.Empty;

        // just show the version number in red
        appVersion.text = $"<color=#ff3131>{Application.version}</color>";
    }

    // gets called when the player tries to open settings
    // but instead of actual settings we just tell them their device can't do it lol
    public void Settings()
    {
        // deselect whatever button was clicked so it doesn't stay highlighted weird
        EventSystem.current.SetSelectedGameObject(null);

        // show the device model + a message saying settings aren't supported
        // (probably just a fake error screen for vibes)
        logs.text = $"<color=#38b6ff>{SystemInfo.deviceModel}</color>Doesnot Support Setting Modification";
    }
}
