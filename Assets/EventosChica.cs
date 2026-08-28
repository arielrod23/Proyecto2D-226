using UnityEngine;

public class EventosChica : MonoBehaviour
{
    public ControlChica ctrlChica;

    public void IniciarDisparo()
    {
        ctrlChica.Disparar();
    }

    public void FinalizarDisparo()
    {
        ctrlChica.disparando = false;
        ctrlChica.luzPistola.enabled = false;
    }
}
