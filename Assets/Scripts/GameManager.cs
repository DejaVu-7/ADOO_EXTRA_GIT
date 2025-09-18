using UnityEngine;
using UnityEngine.SceneManagement;

// clase para manejar el estado general del juego
public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // singleton para acceder desde cualquier parte
    public bool juegoTerminado = false; // indica si el juego ya termino
    public int puntajeObjetivo = 50;    // puntaje necesario para ganar

    private void Awake()
    {
        // configuramos singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // no se destruye al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // si ya existe otro, destruimos este
        }
    }

    public void GameOver()
    {
        if (juegoTerminado) return; // si ya termino, no hace nada
        juegoTerminado = true;
        Debug.Log("GAME OVER");
        SceneManager.LoadScene("GameOver"); // carga escena de game over
    }

    public void Victoria()
    {
        if (juegoTerminado) return; // si ya termino, no hace nada
        juegoTerminado = true;
        Debug.Log("VICTORIA");
        SceneManager.LoadScene("Victoria"); // carga escena de victoria
    }
}
