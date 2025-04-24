using UnityEngine;

public class Moneda : MonoBehaviour
{
    // Prefab de la moneda para instanciar
    public static GameObject monedaPrefab;
    
    void Start()
    {
        // Si es la primera moneda, guardar el prefab y comenzar a generar monedas
        if (monedaPrefab == null)
        {
            monedaPrefab = gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    // Método que se ejecuta cuando otro objeto entra en colisión con la moneda
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            PlayerInformation.Shared.AddCoins(1); // Añade 1 moneda al jugador
            Debug.Log("Moneda recogida. Total monedas: " + PlayerInformation.Shared.Coins);
        }
    }

}
