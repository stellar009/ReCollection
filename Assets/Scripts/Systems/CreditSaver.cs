using System;
using System.IO;
using UnityEngine;

// just saves a credits txt file to the desktop so people can see who made the game lol
public class CreditsSaver : MonoBehaviour
{
    // runs when the game starts
    private void Start()
    {
        SaveCreditsToDesktop();
    }

    // writes the credits file, but only if it doesn't already exist
    // (don't wanna spam people's desktops every time they launch the game)
    public void SaveCreditsToDesktop()
    {
        // figure out where the desktop is (works on different pcs)
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(desktopPath, "credits.txt");

        // already got one? then skip it, no need to rewrite
        if (File.Exists(filePath))
        {
            return;
        }

        // the actual credits text, pretty self explanatory
        string content = "Game by Crimson Duo\n\nCredits:\n Fonts from Google Fonts: Oxanium by sevmeyer " +
            "\n\n Background Music from NCS: Elektronomia - Sky High";

        // wrap in try/catch just in case something goes wrong
        // (like if writing to desktop is blocked or something weird happens)
        try
        {
            File.WriteAllText(filePath, content);
            Debug.Log("Credits saved to: " + filePath);
        }
        catch (Exception e)
        {
            // if it fails just log it, don't crash the whole game over a txt file
            Debug.LogError("Failed to save credits: " + e.Message);
        }
    }
}