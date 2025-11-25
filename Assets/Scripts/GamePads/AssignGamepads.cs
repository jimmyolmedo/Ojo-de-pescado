using UnityEngine;
using UnityEngine.InputSystem;

public class AssignGamepads : MonoBehaviour
{
    public PlayerInput player1;
    public PlayerInput player2;

    void Start()
    {
        // Obtener mandos conectados
        var gamepads = Gamepad.all;

        if (gamepads.Count < 2)
        {
            Debug.LogWarning("Se necesitan 2 mandos conectados");
            return;
        }

        // Asignar mando 1 al jugador 1
        player1.SwitchCurrentControlScheme(gamepads[0]);
        // Asignar mando 2 al jugador 2
        player2.SwitchCurrentControlScheme(gamepads[1]);

        Debug.Log("Mandos asignados correctamente");
    }
}

