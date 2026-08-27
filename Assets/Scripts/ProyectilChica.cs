using UnityEngine;

public class ProyectilChica : MonoBehaviour
{

    [SerializeField] Rigidbody2D cuerpoBala;

    public void AplicarFuerza(float dir)
    {
        cuerpoBala.linearVelocityX = 40f * dir;
    }
}