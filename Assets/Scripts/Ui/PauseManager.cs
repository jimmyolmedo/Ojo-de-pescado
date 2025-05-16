using UnityEngine;

public class PauseManager : MonoBehaviour
{
    bool inPause;

    private void Start()
    {
        inPause = true;
    }

    public void SwitchPauseState()
    {
        if (inPause)
        {
            UIManager.Instance.SwitchPanel("Gameplay");
            GameManager.SwitchState(GameState.Gameplay);
            Time.timeScale = 1f;
            inPause = false;
            Debug.Log("Gameplay");
        }
        else
        {
            UIManager.Instance.SwitchPanel("Pause");
            GameManager.SwitchState(GameState.Pause);
            Time.timeScale = 0f;
            inPause = true;
            Debug.Log("Pausa");
        }
    }
}
