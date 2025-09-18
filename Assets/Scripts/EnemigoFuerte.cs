using UnityEngine;

// enemigo fuerte hereda de la clase base enemigo
public class EnemigoFuerte : Enemigo
{
    public float velocidad = 1.5f; // velocidad de movimiento hacia abajo

    // implementacion del metodo abstracto mover
    public override void Mover()
    {
        // mueve el enemigo hacia abajo cada frame segun la velocidad
        transform.Translate(Vector3.down * velocidad * Time.deltaTime);
    }
}
