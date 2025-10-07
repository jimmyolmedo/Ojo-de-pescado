using UnityEngine;
using TMPro;
public class ScoreManager : Singleton<ScoreManager> 
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private AudioClip scoreAudio;
    protected override bool persistent => false;
    private int _score;

    public int Score
    {
        get => _score;

        private set
        {
            _score = value;
            scoreText.text = _score.ToString();
        }
    }

    public void AddScore(int score)
    {
        Score += score;
        AudioManager.instance.PlayAudio(scoreAudio);
    }

    public void SubstractScore(int score)
    {
        Score -= score;
    }
}
