using UnityEngine;
using System.Collections;

public class GeneradorMonedas: MonoBehaviour {
    // Límites para la generación de monedas
    public static float minX = -8f;
    public static float maxX = 8f;
    public static float minY = -3.4f;
    public static float maxY = 2.8f;

    [SerializeField] private float tiempoMinEspera = 10f;    
    
    [SerializeField] private float tiempoMaxEspera = 15f;    

    // Prefab de la moneda para instanciar
    [SerializeField] private GameObject monedaPrefab;

    void Start() {
        // Si es la primera moneda, guardar el prefab y comenzar a generar monedas
        StartCoroutine(GenerarMonedasAleatorias());
    }

    // Corrutina para generar monedas aleatorias
    IEnumerator GenerarMonedasAleatorias()
    {
        while (true)
        {
            // Esperar un tiempo aleatorio entre 10 y 15 segundos
            float tiempoEspera = Random.Range(tiempoMinEspera, tiempoMaxEspera);
            yield return new WaitForSeconds(tiempoEspera);
            
            // Generar posición aleatoria dentro de los límites
            Vector2 posicionAleatoria = new Vector2(
                Random.Range(minX, maxX),
                Random.Range(minY, maxY)
            );
            
            // Instanciar una nueva moneda en la posición aleatoria
            Instantiate(monedaPrefab, posicionAleatoria, Quaternion.identity);
            
            // Debug.Log("Moneda generada en posición: " + posicionAleatoria);
        }
    }
}