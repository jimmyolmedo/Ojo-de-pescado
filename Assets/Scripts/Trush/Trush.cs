using UnityEngine;

public class Trush : MonoBehaviour
{
    //variables
    [SerializeField] int objID;
    [SerializeField] float speed;
    Vector2 target;

    //methods
    private void Start()
    {
        target = Planet.instance.transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public void ChangeTarget(Vector2 _target)
    {
        target = _target;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //detectar si colisiono con un jugador y si el jugador esta absorbiendo basura
        if(collision.TryGetComponent(out Player player))
        {
            if (player.IsAbsorbing)
            {
                //si colisiono con un jugador comprobar si la id del jugador es igual a la de este objeto
                if (player.PlayerID == objID)
                {
                    //si es igual sumarselo al "inventario"
                    Debug.Log("tomaste el objeto correcto");
                    Destroy(gameObject);
                }
                else
                {
                    //si no es igual, quitarle una vida al jugador
                    Debug.Log("te equivocaste de objeto");
                    Destroy(gameObject);
                }
            }
        }

    }
}
