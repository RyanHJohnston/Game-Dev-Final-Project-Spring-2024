using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadPreviousScene()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        // Calculate the index of the previous scene
        int previousSceneIndex = currentSceneIndex - 1;

        // Check if there is a previous scene to load (i.e., not the first scene)
        if (previousSceneIndex >= 0)
        {
            SceneManager.LoadScene(previousSceneIndex);
        }
        else
        {
            Debug.LogWarning("There is no previous scene to load!");
        }
    }
}
