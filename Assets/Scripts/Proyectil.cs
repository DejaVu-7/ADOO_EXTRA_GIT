using UnityEngine;

// clase para los proyectiles que disparan los enemigos o jugador
public class Proyectil : MonoBehaviour
{
    public float velocidad = 10f; // velocidad a la que se mueve el proyectil
    public int daño = 1; // daño que hace al impactar

    void Update()
    {
        // mueve el proyectil hacia arriba cada frame
        transform.Translate(Vector3.up * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // si colisiona con algo que implemente IDanable
        IDanable dañable = other.GetComponent<IDanable>();
        if (dañable != null)
        {
            dañable.RecibirDaño(daño); // aplica daño
            Destroy(gameObject); // destruye el proyectil al impactar
        }
    }
}
