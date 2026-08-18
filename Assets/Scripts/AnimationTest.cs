using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    public Animator miAnimador;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(CambiarAnimador), 10f);
    }

    void CambiarAnimador()
    {
        miAnimador.SetBool("cambiar", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
