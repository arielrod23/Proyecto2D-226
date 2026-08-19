using UnityEngine;

public class AnimPersonajeBasico : MonoBehaviour
{
    [SerializeField] private float velocidad = 4f;
    public Animator miAnimador;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float entradaX = Input.GetAxis("Horizontal");
        Debug.Log("el jugador esta presionando " + entradaX);
        Debug.Log("tiempo delta " + Time.deltaTime);

        if (entradaX != 0)
        {
            transform.Translate(new Vector2(entradaX * Time.deltaTime * velocidad, 0));
            miAnimador.SetBool("caminando", true);

            if (transform.localScale.x > 0 && entradaX < 0 || transform.localScale.x < 0 && entradaX > 0)
            {
                GirarPersonaje();
            }
        }
        else
        {
            miAnimador.SetBool("caminando", false);
        }
    }

    void GirarPersonaje()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1f,
                                            transform.localScale.y,
                                            transform.localScale.z);
    }

   
}
