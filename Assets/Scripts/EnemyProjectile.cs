using UnityEngine;

// proyectil de los enemigos que puede da�ar al jugador
public class EnemyProjectile : MonoBehaviour, IDanable
{
    public int da�o = 1; // da�o que hace al jugador
    public float velocidad = 5f; // velocidad de movimiento hacia abajo

    void Update()
    {
        // mueve el proyectil hacia abajo cada frame
        transform.Translate(Vector3.down * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // si colisiona con el jugador
        Jugador jugador = other.GetComponent<Jugador>();
        if (jugador != null)
        {
            jugador.RecibirDa�o(da�o); // aplica da�o al jugador
            Destroy(gameObject); // destruye el proyectil al impactar
        }
    }

    // metodo de idanable para recibir da�o (por disparos del jugador)
    public void RecibirDa�o(int cantidad)
    {
        Destroy(gameObject); // destruimos el proyectil al recibir da�o
    }
}
