using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private TMP_Text finalScore;
    void OnEnable()
    {
        finalScore.text = ScoreManager.instance.Score.ToString();
    }
}
