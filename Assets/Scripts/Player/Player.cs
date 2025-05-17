using JetBrains.Annotations;
using System.Collections;
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
    bool isInvul = false;
    [SerializeField] Transform respawn;
    [SerializeField] Transform pointDetect;
    [SerializeField] float ratioDetect;
    [SerializeField] PlayerMovement pM;

    [Header("Visual")]
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color damageColor;
    //properties
    //controla la vida del jugador
    public int CurrentHealth
    {
        get => currentHealth;

        set
        {
            currentHealth = value;
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }
    //identificador del jugador
    public int PlayerID { get => playerID; }

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
            animator.SetBool("isCollect", true);
            //atraer los objetos hacia el jugador
            if (colls.Length != 0)
            {
                foreach (Collider2D coll in colls)
                {
                    if (coll.TryGetComponent(out Trush trush))
                    {
                        trush.ChangeTarget(transform.position);
                        trush.Speed += 3f;
                        Debug.Log("estoy atrayendo enemigos");
                    }
                }
            }
        }

        if (context.canceled)
        {
            pM.CanMove = true;
            IsAbsorbing = false;
            animator.SetBool("isCollect", false);
            if (colls.Length != 0)
            {
                foreach (Collider2D coll in colls)
                {
                    if (coll.TryGetComponent(out Trush trush))
                    {
                        trush.ChangeTarget(Planet.instance.transform.position);
                        trush.Speed -= 3f;
                    }
                }
            }
        }
    }

    //metodo para quitarle vida al jugador
    public void GetDamage(int _damage)
    {
        if (isInvul) return;
        //animacion de da�o 
        StartCoroutine(DamageAnim());
        //quitar vida al jugador
        CurrentHealth -= _damage;
    }

    //metodo para cuando el jugador pierde
    void Die()
    {
        pM.CanMove = false;
        animator.Play("Death");

    }
    public void Respawn()
    {
        transform.position = respawn.position;
        transform.rotation = respawn.rotation;
        CurrentHealth = maxHeath;
        animator.Play("Idle");
    }
    IEnumerator DamageAnim()
    {
        isInvul = true;
        yield return null;
        // for (float i = 0; i < 0.1f; i += Time.deltaTime)
        int x = 0;
        while (x < 5)
        {
            spriteRenderer.color = damageColor;
            yield return new WaitForSeconds(0.25f);
            spriteRenderer.color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.25f);
            x++;
        }
        isInvul = false;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointDetect.position, ratioDetect);
    }
    
}
