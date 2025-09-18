using UnityEngine;
using UnityEngine.SceneManagement;

// clase para manejar la carga de escenas y salir del juego
public class SceneLoader : MonoBehaviour
{
    // metodo para cargar una escena por nombre
    public void CargarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    // metodo para salir del juego
    public void SalirJuego()
    {
        Application.Quit(); // cierra la aplicacion
    }
}
