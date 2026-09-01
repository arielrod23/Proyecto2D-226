using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputSystem_Actions controlesJugador;
    [SerializeField] float velocidadPlayer = 4f;
    [SerializeField] float multiplicadorVelocidad = 2f;
    [SerializeField] float multiplicadorVelocidadActual;
    [SerializeField] Rigidbody2D miCuerpo;

    Vector2 entradaJugador;

    private void Awake()
    {
        controlesJugador = new InputSystem_Actions();
    }

    private void Start()
    {
        miCuerpo = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        controlesJugador.Player.Enable();

        controlesJugador.Player.Interact.started += Interactuar;
    }

    private void Interactuar(InputAction.CallbackContext ctx)
    {
        Debug.Log("Debo interactuar");
    }

    private void Update()
    {
        Vector2 velocidadObjetivo;

        entradaJugador = controlesJugador.Player.Move.ReadValue<Vector2>();

        multiplicadorVelocidadActual = controlesJugador.Player.Sprint.IsPressed() ? multiplicadorVelocidad : 1;

        velocidadObjetivo = entradaJugador * velocidadPlayer * multiplicadorVelocidadActual;

        //Debug.Log(entradaJugador.magnitude);
        miCuerpo.linearVelocity = velocidadObjetivo;
        //transform.Translate(new Vector2(entradaJugador.x * Time.deltaTime * velocidadPlayer * multiplicadorVelocidadActual, 0));
    }

    private void OnDisable()
    {
        controlesJugador.Player.Disable();

        controlesJugador.Player.Interact.started -= Interactuar;
    }
}
