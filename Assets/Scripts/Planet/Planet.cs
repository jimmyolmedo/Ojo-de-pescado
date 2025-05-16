using UnityEngine;

public class Planet : Singleton<Planet>
{
    //variables
    [SerializeField] int maxHealth = 12;
    int currentHealth;
    [SerializeField] Sprite[] sprites;
    [SerializeField] SpriteRenderer spriteRenderer;
    //properties
    protected override bool persistent => false;

    public int CurrentHealth
    {
        get => currentHealth;

        set
        {
            //quitar vida a planet
            currentHealth = value;
            //conprobar la vida a planet y ponerle su sprite correspondiente
            if (currentHealth == 12)
            {
                spriteRenderer.sprite = sprites[0];
            }
            else if (currentHealth == 8)
            {
                spriteRenderer.sprite = sprites[1];
            }
            else if (currentHealth == 4)
            {
                spriteRenderer.sprite = sprites[2];
            }

            if (currentHealth <= 0)
            {
                GameOver();
            }
        }

    }
    //methods
    protected override void Awake()
    {
        base.Awake();
        currentHealth = maxHealth;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Trush trush))
        {
            CurrentHealth--;
        }
    }
    private void GameOver()
    {
        UIManager.Instance.SwitchPanel("GameOver");
        GameManager.SwitchState(GameState.GameOver);
        Time.timeScale = 0f;
        Debug.Log("GameOver");
    }
}
