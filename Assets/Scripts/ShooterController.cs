using UnityEngine;

public class ShooterController : MonoBehaviour
{
    //variables globales, disponibles para toda esta clase
    public int arma;
    public string nombre;
    public float velocidad;
    private float salud;
    private int puntaje;

    public EstadoJuego estadoActual;


    //metodo/funcion, que devuelve un entero
    public int GetPuntaje()
    {
        //varible local, no se puede acceder, desde afuera de aqui
        int prueba;
        return puntaje;
    }

    //metodo que no devuelve un valor
    //la funcion tiene un parametro de entrada
    //una funcion puede tener muchos parametros
    public void SetPuntaje(int nuevoPuntaje)
    {
        puntaje = nuevoPuntaje;
    }

    void Start()
    {
        if (estadoActual == EstadoJuego.Cargado)
        {
            Debug.Log("INICIAR JUEGO");
            estadoActual = EstadoJuego.Iniciado;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum EstadoJuego
{
    Cargado,
    Iniciado,
    EnPausa,
    GameOver,
    Cargando
}
