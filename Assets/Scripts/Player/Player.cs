using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] int playerID;

    //variables
    [Header("Player Health")]
    [SerializeField] int maxHeath;
    int currentHealth;
    [SerializeField] Transform pointDetect;
    [SerializeField] float ratioDetect;
    [SerializeField] PlayerMovement pM;

    //properties
    //controla la vida del jugador
    public int CurrentHealth
    {
        get => currentHealth;

        set
        {
            currentHealth = value;
            if(currentHealth <= 0)
            {
                Die();
            }
        }
    }
    //identificador del jugador
    public int PlayerID {  get => playerID;}

    //determinar si el jugador esta absorbiendo basura
    public bool IsAbsorbing { get; private set; }
    //methods

    //metodo para recoger los objetos(la basura)
    public void GetObj(InputAction.CallbackContext context)
    {
        //crear un circulo para detectar los objetos
        Collider2D[] colls = Physics2D.OverlapCircleAll(pointDetect.position, ratioDetect);

        //comprobar si el jugador esta presionando el boton(mantener presionado)
        if (context.started)
        {
            pM.CanMove = false;
            IsAbsorbing = true;
            //atraer los objetos hacia el jugador
            if (colls.Length != 0)
            {
                foreach (Collider2D coll in colls)
                {
                    if (coll.TryGetComponent(out Trush trush))
                    {
                        trush.ChangeTarget(transform.position);
                        Debug.Log("estoy atrayendo enemigos");
                    }
                }
            }
        }

        if(context.canceled)
        {
            pM.CanMove = true;
            IsAbsorbing = false;
            if (colls.Length != 0)
            {
                foreach (Collider2D coll in colls)
                {
                    if (coll.TryGetComponent(out Trush trush))
                    {
                        trush.ChangeTarget(Planet.instance.transform.position);
                    }
                }
            }
        }
    }

    //metodo para quitarle vida al jugador
    public void GetDamage(int _damage)
    {
        //animacion de daño

        //quitar vida al jugador
        CurrentHealth -= _damage;
    }

    //metodo para cuando el jugador pierde
    void Die()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointDetect.position, ratioDetect);
    }
}
