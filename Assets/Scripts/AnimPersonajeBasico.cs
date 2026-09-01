using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimPersonajeBasico : MonoBehaviour
{
    [SerializeField] private float velocidad = 4f;
    [SerializeField] private float fuerzaSalto = 6f;
    [SerializeField] private bool pisando;
    [SerializeField] private bool saltando;
    [SerializeField] private bool muerto;

    [SerializeField] Rigidbody2D miCuerpo;
    public Animator miAnimador;

    void Start()
    {

    }

    void Update()
    {
        if (muerto)
            return;

        float entradaX = Input.GetAxis("Horizontal");
        Debug.Log("el jugador esta presionando " + entradaX);
        //Debug.Log("tiempo delta " + Time.deltaTime);

        //verificando si el jugador quiere moverse
        if (entradaX != 0)
        {
            //transform.Translate(new Vector2(entradaX * Time.deltaTime * velocidad, 0));
            miCuerpo.linearVelocityX = entradaX * velocidad;
        }

            miAnimador.SetBool("caminando", true);

            if (transform.localScale.x > 0 && entradaX < 0 || transform.localScale.x < 0 && entradaX > 0)
            {
                GirarPersonaje();
            }
        }

        private void OnGUI()
        {
        Rect btnMuerto = new Rect(10, 10, 100, 30);
        Rect btnDaño = new Rect(10, 0, 100, 50);

        if (GUI.Button(btnPrueba, "Matar"))
        {
            MatarPersonaje();
        }
        if (GUI.Button(btnDaño, "Dañar"))
        {
            DañarPersonaje();
        }

        void DañarPersonaje()
        {
            muerto = true;
            miAnimador.SetBool("muerto", muerto);
            miAnimador.SetTrigger("daño");
        }

        //leyendo la tecla de salto
        if (Input.GetButtonDown("Jump") && pisando)
        {
            miCuerpo.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
        }

        miAnimador.SetBool("pisando", pisando);
        miAnimador.SetFloat("velY", miCuerpo.linearVelocityY);

    void GirarPersonaje()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1f,
                                            transform.localScale.y,
                                            transform.localScale.z);
    }

    private void OnGUI()
    {
        Rect btnMuerto = new Rect(10, 10, 100, 50);
        Rect btnDaño = new Rect(10, 80, 100, 50);

        if (GUI.Button(btnMuerto, "Matar"))
        {
            MatarPersonaje();
        }

        if (GUI.Button(btnDaño, "Dañar"))
        {
            DañarPersonaje();
        }
    }
    void MatarPersonaje()
    {
        muerto = true;
        miAnimador.SetBool("muerto", muerto);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("piso"))
        {
            pisando = true;
        }
    }
        {
            pisando = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("piso"))
        {
            pisando = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
    }
}
