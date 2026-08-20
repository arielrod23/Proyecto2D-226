using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputSystem_Actions controlesJugador;
    [SerializeField] float velocidadPlayer = 4f;

    Vector2 entradaJugador;

    private void Awake()
    {
        controlesJugador = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        controlesJugador.Player.Enable();
    }

    private void Update()
    {
        entradaJugador = controlesJugador.Player.Move.ReadValue<Vector2>();
        transform.Translate(new Vector2(entradaJugador.x * Time.deltaTime * velocidadPlayer, 0));
    }

    private void OnDisable()
    {
        controlesJugador.Player.Disable();
    }
}
