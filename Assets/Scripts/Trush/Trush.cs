using UnityEngine;

public class Trush : MonoBehaviour
{
    //variables
    [SerializeField] int objID;
    [SerializeField] float speed;
    [SerializeField] private float speedRotation;
    
    
    Vector2 target;

    //properties
    public float Speed { get => speed; set => speed = value; }

    //methods
    private void Start()
    {
        target = Planet.instance.transform.position;
    }

    private void Update()
    {
        if (GameManager.CurrentState == GameState.Gameplay)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            transform.Rotate(new Vector3(0,0, speedRotation * Time.deltaTime)); 
        }
    }

    public void ChangeTarget(Vector2 _target)
    {
        target = _target;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //detectar si colisiono con un jugador y si el jugador esta absorbiendo basura
        if (collision.TryGetComponent(out Player player))
        {
            if (player.IsAbsorbing)
            {
                //si colisiono con un jugador comprobar si la id del jugador es igual a la de este objeto
                if (player.PlayerID == objID)
                {
                    //si es igual sumarselo al "inventario"
                    ScoreManager.instance.AddScore(5);
                    Debug.Log("tomaste el objeto correcto");
                    Destroy(gameObject);
                }
                else
                {
                    //si no es igual, quitarle una vida al jugador
                    Debug.Log("te equivocaste de objeto");
                    player.GetDamage(1);
                    Destroy(gameObject);
                }
            }
        }
        if (collision.TryGetComponent(out Planet planet))
        {
            Destroy(gameObject);
        }

    }
}
