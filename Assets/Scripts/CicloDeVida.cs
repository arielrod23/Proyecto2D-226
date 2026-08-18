using UnityEngine;

public class CicloDeVida : MonoBehaviour
{

    void Awake()
    {
        Debug.Log("Awake");
    }
    void OnEnable()
    {
        Debug.Log("Enable");
    }
 
    void Start()
    {
        Debug.Log("Start");
    }

    void Update()
    {
        Debug.Log("Update");
    }

    private void FixedUpdate()
    {
        Debug.Log("Fixed");
    }

    private void LateUpdate()
    {
        Debug.Log("Late");
    }

    private void OnDisable()
    {
        Debug.Log("Disable");
    }

    private void OnDestroy()
    {
        Debug.Log("Destroy");
    }
}
