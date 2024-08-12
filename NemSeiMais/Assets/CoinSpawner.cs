using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Prefab da moeda que será instanciada
    public float spawnInterval = 2f; // Intervalo de tempo entre o spawn de moedas
    public Vector2 spawnAreaMin; // Ponto mínimo da área de spawn (canto inferior esquerdo)
    public Vector2 spawnAreaMax; // Ponto máximo da área de spawn (canto superior direito)

    void Start()
    {
        InvokeRepeating("SpawnCoin", 0f, spawnInterval);
    }

    void SpawnCoin()
    {
        // Gera uma posição aleatória dentro da área de spawn
        float spawnX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float spawnY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);

        // Instancia a moeda na posição gerada
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }

    void OnDrawGizmosSelected()
    {
        // Desenha a área de spawn no editor para visualização
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector2(spawnAreaMin.x, spawnAreaMin.y), new Vector2(spawnAreaMax.x, spawnAreaMin.y));
        Gizmos.DrawLine(new Vector2(spawnAreaMin.x, spawnAreaMin.y), new Vector2(spawnAreaMin.x, spawnAreaMax.y));
        Gizmos.DrawLine(new Vector2(spawnAreaMax.x, spawnAreaMax.y), new Vector2(spawnAreaMin.x, spawnAreaMax.y));
        Gizmos.DrawLine(new Vector2(spawnAreaMax.x, spawnAreaMax.y), new Vector2(spawnAreaMax.x, spawnAreaMin.y));
    }
}
