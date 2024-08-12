using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Prefab da moeda que ser� instanciada
    public float spawnInterval = 2f; // Intervalo de tempo entre o spawn de moedas
    public Vector2 spawnAreaMin; // Ponto m�nimo da �rea de spawn (canto inferior esquerdo)
    public Vector2 spawnAreaMax; // Ponto m�ximo da �rea de spawn (canto superior direito)

    void Start()
    {
        InvokeRepeating("SpawnCoin", 0f, spawnInterval);
    }

    void SpawnCoin()
    {
        // Gera uma posi��o aleat�ria dentro da �rea de spawn
        float spawnX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float spawnY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        // Instancia a moeda na posi��o gerada
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        // Desenha a �rea de spawn no editor para visualiza��o
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector2(spawnAreaMin.x, spawnAreaMin.y), new Vector2(spawnAreaMax.x, spawnAreaMin.y));
        Gizmos.DrawLine(new Vector2(spawnAreaMin.x, spawnAreaMin.y), new Vector2(spawnAreaMin.x, spawnAreaMax.y));
        Gizmos.DrawLine(new Vector2(spawnAreaMax.x, spawnAreaMax.y), new Vector2(spawnAreaMin.x, spawnAreaMax.y));
        Gizmos.DrawLine(new Vector2(spawnAreaMax.x, spawnAreaMax.y), new Vector2(spawnAreaMax.x, spawnAreaMin.y));
    }
}
