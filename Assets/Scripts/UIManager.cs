using UnityEngine;
using UnityEngine.UI;
using TMPro;

// clase para manejar la UI del juego (vida y puntaje)
public class UIManager : MonoBehaviour
{
    public Jugador jugador;           // referencia al jugador
    public TMP_Text puntajeText;      // texto para mostrar el puntaje
    public Slider vidaBar;            // barra de vida
    private int puntaje = 0;          // puntaje actual

    void Start()
    {
        InicializarVida();                // inicializa la barra de vida
        SuscribirseEventosJugador();     // escucha cambios de vida del jugador
        SuscribirseEnemigosExistentes(); // suscribe enemigos que ya estan en la escena
        SuscribirseSpawners();           // suscribe enemigos que spawneen despues
        ActualizarPuntajeUI();           // actualiza el texto del puntaje
    }

    private void InicializarVida()
    {
        vidaBar.maxValue = jugador.vida;
        vidaBar.value = jugador.vida;
    }

    private void SuscribirseEventosJugador()
    {
        if (jugador != null)
            jugador.OnVidaCambiada += ActualizarVida; // cada vez que cambia la vida, actualiza barra
    }

    private void SuscribirseEnemigosExistentes()
    {
        Enemigo[] enemigos = Object.FindObjectsByType<Enemigo>(FindObjectsSortMode.None);
        foreach (var enemigo in enemigos)
            enemigo.OnEnemigoDestruido += AumentarPuntaje; // cuando enemigo muere, aumenta puntaje
    }

    private void SuscribirseSpawners()
    {
        EnemySpawner[] spawners = Object.FindObjectsByType<EnemySpawner>(FindObjectsSortMode.None);
        foreach (var spawner in spawners)
            spawner.OnEnemySpawned += SuscribirEnemigo; // suscribimos enemigos nuevos a puntaje
    }

    private void SuscribirEnemigo(Enemigo enemigo)
    {
        enemigo.OnEnemigoDestruido += AumentarPuntaje;
    }

    private void ActualizarVida(int nuevaVida)
    {
        vidaBar.value = nuevaVida; // actualiza la barra de vida
    }

    private void AumentarPuntaje(Enemigo enemigo)
    {
        puntaje += enemigo.puntos;      // suma puntos del enemigo destruido
        ActualizarPuntajeUI();           // actualiza texto del puntaje

        // si se alcanza el puntaje objetivo, victoria
        if (puntaje >= GameManager.Instance.puntajeObjetivo)
            GameManager.Instance.Victoria();
    }

    private void ActualizarPuntajeUI()
    {
        puntajeText.text = "Score: " + puntaje; // muestra el puntaje en pantalla
    }
}
