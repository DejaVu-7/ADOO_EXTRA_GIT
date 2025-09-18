using UnityEngine;

// enemigo rapido hereda de la clase base enemigo
public class EnemigoRapido : Enemigo
{
    public float velocidad = 3f; // velocidad mas alta que el enemigo fuerte

    // implementacion del metodo abstracto mover
    public override void Mover()
    {
        // mueve el enemigo hacia abajo cada frame segun la velocidad
        transform.Translate(Vector3.down * velocidad * Time.deltaTime);
    }
}
