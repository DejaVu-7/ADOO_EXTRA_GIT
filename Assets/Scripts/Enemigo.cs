using UnityEngine;

// clase base para todos los enemigos, implementa idanable
public abstract class Enemigo : MonoBehaviour, IDanable
{
    public int vida = 1; // vida del enemigo
    public int puntos = 10; // puntos que da al morir

    // delegado y evento para avisar cuando el enemigo es destruido
    public delegate void EnemigoDestruido(Enemigo enemigo);
    public event EnemigoDestruido OnEnemigoDestruido;

    // para disparar
    public GameObject proyectilPrefab; // prefab del proyectil que dispara
    public Transform puntoDisparo; // desde donde sale el proyectil
    public float intervaloDisparo = 2f; // tiempo entre disparos

    protected float tiempoUltimoDisparo; // para controlar el tiempo del ultimo disparo

    void start()
    {
        tiempoUltimoDisparo = Time.time; // inicializamos el tiempo del primer disparo
    }

    void update()
    {
        Mover(); // llamamos al metodo abstracto mover, definido en cada enemigo
        Disparar(); // llamamos al metodo disparar
    }

    // metodo abstracto que obliga a las clases hijas a implementar el movimiento
    public abstract void Mover();

    // metodo para disparar proyectiles, puede usarlo cualquier enemigo que tenga proyectil
    protected void Disparar()
    {
        if (proyectilPrefab == null || puntoDisparo == null)
            return; // si no hay proyectil o punto de disparo, no hace nada

        // revisamos si ya paso el tiempo del intervalo para disparar
        if (Time.time - tiempoUltimoDisparo >= intervaloDisparo)
        {
            Instantiate(proyectilPrefab, puntoDisparo.position, Quaternion.identity); // creamos el proyectil
            tiempoUltimoDisparo = Time.time; // actualizamos el tiempo del ultimo disparo
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // si colisiona con el jugador
        Jugador jugador = other.GetComponent<Jugador>();
        if (jugador != null)
        {
            jugador.RecibirDaño(1); // toca y daña al jugador
            RecibirDaño(vida); // el enemigo muere al tocar al jugador
        }
    }

    public void RecibirDaño(int cantidad)
    {
        vida -= cantidad; // reducimos vida
        if (vida <= 0)
        {
            OnEnemigoDestruido?.Invoke(this); // avisamos que el enemigo fue destruido
            Destroy(gameObject); // destruimos el objeto enemigo
        }
    }
}
