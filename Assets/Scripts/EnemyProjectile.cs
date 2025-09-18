using UnityEngine;

// proyectil de los enemigos que puede dañar al jugador
public class EnemyProjectile : MonoBehaviour, IDanable
{
    public int daño = 1; // daño que hace al jugador
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
            jugador.RecibirDaño(daño); // aplica daño al jugador
            Destroy(gameObject); // destruye el proyectil al impactar
        }
    }

    // metodo de idanable para recibir daño (por disparos del jugador)
    public void RecibirDaño(int cantidad)
    {
        Destroy(gameObject); // destruimos el proyectil al recibir daño
    }
}
