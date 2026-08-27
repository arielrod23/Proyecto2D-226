using UnityEngine;

public class ControlChica : MonoBehaviour
{
    [SerializeField] private float velocidad = 4f;
    [SerializeField] private float fuerzaSalto = 6f;
    [SerializeField] private bool pisando;
    [SerializeField] private bool muerto;
    [SerializeField] private bool disparando;

    [SerializeField] Rigidbody2D miCuerpo;

    [SerializeField] Animator miAnimador;

    [SerializeField] ProyectilChica proyectil;
    [SerializeField] GameObject proyectilObj;
    [SerializeField] Transform puntaPistola;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (muerto)
            return;

        float entradaX = Input.GetAxis("Horizontal");
        Debug.Log("el jugador esta presionando " + entradaX);
        //Debug.Log("tiempo delta " + Time.deltaTime);

        //verificando si el jugador quiere moverse
        if (entradaX != 0 && !disparando)
        {
            //transform.Translate(new Vector2(entradaX * Time.deltaTime * velocidad, 0));
            miCuerpo.linearVelocityX = entradaX * velocidad;

            miAnimador.SetBool("corriendo", true);

            if (transform.localScale.x > 0 && entradaX < 0 || transform.localScale.x < 0 && entradaX > 0)
            {
                GirarPersonaje();
            }
        }
        else
        {
            miAnimador.SetBool("corriendo", false);
        }
        //leyendo la tecla de salto
        if (Input.GetButtonDown("Jump") && pisando)
        {
            miCuerpo.AddForceY(fuerzaSalto, ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            miAnimador.SetTrigger("disparo");
            GameObject nuevoProyectil = Instantiate(proyectilObj, puntaPistola.position, puntaPistola.rotation);
            nuevoProyectil.GetComponent<ProyectilChica>().AplicarFuerza(Mathf.Sign(transform.localScale.x));
        }

        //actualizamos variables de salto en el animador
        miAnimador.SetBool("pisando", pisando);
        miAnimador.SetFloat("velY", miCuerpo.linearVelocityY);
    }

    void GirarPersonaje()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1f,
                                            transform.localScale.y,
                                            transform.localScale.z);
    }
}
