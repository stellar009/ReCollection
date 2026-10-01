using System;
using System.IO;
using UnityEngine;

public class CreditsSaver : MonoBehaviour
{
    private void Start()
    {
        SaveCreditsToDesktop();
    }


    public void SaveCreditsToDesktop()
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(desktopPath, "credits.txt");

        if (File.Exists(filePath))
        {
            return;
        }

        string content = "Game by Crimson Duo\n\nCredits:\n Fonts from Google Fonts: Oxanium by sevmeyer \n\n Background Music from NCS: Elektronomia - Sky High";

        try
        {
            File.WriteAllText(filePath, content);
            Debug.Log("Credits saved to: " + filePath);
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to save credits: " + e.Message);
        }
    }
}