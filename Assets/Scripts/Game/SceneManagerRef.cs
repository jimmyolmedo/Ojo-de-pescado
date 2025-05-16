using UnityEngine;

public class SceneManagerRef : MonoBehaviour
{
    public void LoadScene(string sceneManager)
    {
        SceneManager.instance.LoadScene(sceneManager);
    }
    public void QuitGame()
    {
        SceneManager.instance.QuitGame();
    }
}
