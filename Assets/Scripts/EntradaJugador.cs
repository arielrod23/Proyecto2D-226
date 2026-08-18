using UnityEngine;

public class EntradaJugador : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
        }
        if (Input.GetButton("Jump"))
        {

        }
        if (Input.GetMouseButton(0))
        {

        }
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {

        }
    }
}
