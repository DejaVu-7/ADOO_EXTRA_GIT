# ADOO_EXTRA

# Space Game - Patrones de Diseño

Este proyecto implementa 7 patrones de diseño en un juego de naves tipo shooter 2D en Unity

## Patrones implementados

1. **Singleton**
   - **Por qué:** Para tener una instancia global de GameManager y AudioManager
   - **Dónde:** `GameManager.cs`, `AudioManager.cs`

2. **Observer / MVP**
   - **Por qué:** Para actualizar la UI en tiempo real cuando cambian la vida del jugador o se destruyen enemigos
   - **Dónde:** `UIManager.cs` suscrito a `Jugador.OnVidaCambiada` y `Enemigo.OnEnemigoDestruido`

3. **Factory / Fabrica de Fábricas**
   - **Por qué:** Para crear enemigos y obstáculos de forma flexible y desacoplada
   - **Dónde:** `EnemySpawner.cs` crea `EnemigoRapido` y `EnemigoFuerte`

4. **FSM (Finite State Machine)**
   - **Por qué:** Para controlar el comportamiento de enemigos (patrullar, atacar, etc.)
   - **Dónde:** Clases derivadas de `Enemigo` implementando distintos estados

5. **Object Pool**
   - **Por qué:** Para reciclar enemigos y proyectiles, evitando instanciaciones/destrucciones constantes
   - **Dónde:** Puede implementarse en un script `PoolManager.cs` para proyectiles y enemigos

6. **Strategy (opcional según tu implementación)**
   - **Por qué:** Para cambiar el comportamiento de movimiento de enemigos de manera dinámica
   - **Dónde:** Métodos `Mover()` en `EnemigoFuerte` y `EnemigoRapido`

7. **Command (opcional)**
   - **Por qué:** Para abstraer acciones de jugador o enemigos (disparar, saltar, etc.)
   - **Dónde:** Métodos `Disparar()` en `Jugador.cs` y `Enemigo.cs`

## Cómo usar el proyecto

1. Abrir el proyecto en Unity 6
2. Ejecutar la escena principal `Menu`.
3. Controles:
   - mover: flechas o WASD
   - disparar: barra espaciadora

