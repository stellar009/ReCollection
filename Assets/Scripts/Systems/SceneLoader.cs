using UnityEngine;
using UnityEngine.SceneManagement;

// tiny helper script for buttons, basically just loads scenes and quits the game
public class SceneLoader : MonoBehaviour
{
    // loads a scene by name, just hook this up to a button in the inspector
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // quits the game, for the quit button obviously
    // (does nothing in the editor, only works in a build)
    public void QuitGame()
    {
        Application.Quit();
    }

}
