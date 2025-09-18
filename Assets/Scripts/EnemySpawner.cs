using UnityEngine;

// spawner de enemigos que genera enemigos rapidos o fuertes
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemigoRapidoPrefab; // prefab del enemigo rapido
    public GameObject enemigoFuertePrefab; // prefab del enemigo fuerte
    public float intervalo = 3f; // tiempo entre spawn de enemigos

    // delegado y evento para avisar cuando se genera un enemigo
    public delegate void EnemySpawned(Enemigo enemigo);
    public event EnemySpawned OnEnemySpawned;

    void Start()
    {
        // llama al metodo SpawnEnemigo repetidamente segun el intervalo
        InvokeRepeating(nameof(SpawnEnemigo), 1f, intervalo);
    }

    void SpawnEnemigo()
    {
        // elige aleatoriamente entre enemigo rapido o fuerte
        GameObject prefab = (Random.value > 0.5f) ? enemigoRapidoPrefab : enemigoFuertePrefab;
        GameObject nuevo = Instantiate(prefab, transform.position, Quaternion.identity); // instanciamos enemigo
        Enemigo enemigo = nuevo.GetComponent<Enemigo>();
        OnEnemySpawned?.Invoke(enemigo); // avisamos que se creo un enemigo
    }
}
