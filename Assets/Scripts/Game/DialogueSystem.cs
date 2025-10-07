using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] string[] dialogues;
    [SerializeField] TextMeshProUGUI textReference;
    int index = 0;

    void Start()
    {
        textReference.text = dialogues[index];
        index++;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (index < dialogues.Length)
            {
                textReference.text = dialogues[index];
                index++;
            }
            else
            {
                GoToMenu();
            }
        }
    }


    void GoToMenu()
    {
        SceneManager.instance.LoadScene("Menu");
    }
}
