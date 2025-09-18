using UnityEngine;

// clase jugador que implementa idanable para recibir daño
public class Jugador : MonoBehaviour, IDanable
{
    public int vida = 3; // vida del jugador
    public float velocidad = 5f; // velocidad de movimiento
    public GameObject proyectilPrefab; // prefab del proyectil del jugador
    public Transform puntoDisparo; // desde donde salen los proyectiles

    // delegado y evento para avisar cuando cambia la vida
    public delegate void VidaCambiada(int nuevaVida);
    public event VidaCambiada OnVidaCambiada;

    private float minX, maxX, minY, maxY; // limites de movimiento en pantalla

    void Start()
    {
        CalcularLimitesPantalla(); // calculamos los limites de movimiento segun la camara
    }

    void Update()
    {
        Mover(); // movemos al jugador segun input
        Disparar(); // disparamos si se presiona espacio
    }

    private void CalcularLimitesPantalla()
    {
        Camera cam = Camera.main;
        Vector2 esquinaInferior = cam.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 esquinaSuperior = cam.ViewportToWorldPoint(new Vector2(1, 1));

        // ajustamos limites con un margen de 0.5 unidades
        minX = esquinaInferior.x + 0.5f;
        maxX = esquinaSuperior.x - 0.5f;
        minY = esquinaInferior.y + 0.5f;
        maxY = esquinaSuperior.y - 0.5f;
    }

    private void Mover()
    {
        float h = Input.GetAxis("Horizontal"); // input horizontal
        float v = Input.GetAxis("Vertical");   // input vertical

        Vector3 movimiento = new Vector3(h, v, 0) * velocidad * Time.deltaTime;
        transform.position += movimiento;

        // limitar dentro de los limites calculados
        float x = Mathf.Clamp(transform.position.x, minX, maxX);
        float y = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(x, y, 0);
    }

    private void Disparar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // instanciamos proyectil en el punto de disparo
            Instantiate(proyectilPrefab, puntoDisparo.position, Quaternion.identity);
        }
    }

    // metodo de idanable para recibir daño
    public void RecibirDaño(int cantidad)
    {
        vida -= cantidad;
        vida = Mathf.Max(vida, 0); // no permitir vida negativa
        OnVidaCambiada?.Invoke(vida); // avisamos que la vida cambio

        if (vida <= 0)
            GameManager.Instance.GameOver(); // si llega a 0 vida, game over
    }
}
