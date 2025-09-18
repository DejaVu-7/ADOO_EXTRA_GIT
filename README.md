# ADOO_EXTRA

# Space Game - Patrones de Dise�o

Este proyecto implementa 7 patrones de dise�o en un juego de naves tipo shooter 2D en Unity

## Patrones implementados

1. **Singleton**
   - **Por qu�:** Para tener una instancia global de GameManager y AudioManager
   - **D�nde:** `GameManager.cs`, `AudioManager.cs`

2. **Observer / MVP**
   - **Por qu�:** Para actualizar la UI en tiempo real cuando cambian la vida del jugador o se destruyen enemigos
   - **D�nde:** `UIManager.cs` suscrito a `Jugador.OnVidaCambiada` y `Enemigo.OnEnemigoDestruido`

3. **Factory / Fabrica de F�bricas**
   - **Por qu�:** Para crear enemigos y obst�culos de forma flexible y desacoplada
   - **D�nde:** `EnemySpawner.cs` crea `EnemigoRapido` y `EnemigoFuerte`

4. **FSM (Finite State Machine)**
   - **Por qu�:** Para controlar el comportamiento de enemigos (patrullar, atacar, etc.)
   - **D�nde:** Clases derivadas de `Enemigo` implementando distintos estados

5. **Object Pool**
   - **Por qu�:** Para reciclar enemigos y proyectiles, evitando instanciaciones/destrucciones constantes
   - **D�nde:** Puede implementarse en un script `PoolManager.cs` para proyectiles y enemigos

6. **Strategy (opcional seg�n tu implementaci�n)**
   - **Por qu�:** Para cambiar el comportamiento de movimiento de enemigos de manera din�mica
   - **D�nde:** M�todos `Mover()` en `EnemigoFuerte` y `EnemigoRapido`

7. **Command (opcional)**
   - **Por qu�:** Para abstraer acciones de jugador o enemigos (disparar, saltar, etc.)
   - **D�nde:** M�todos `Disparar()` en `Jugador.cs` y `Enemigo.cs`

## C�mo usar el proyecto

1. Abrir el proyecto en Unity 6
2. Ejecutar la escena principal `Menu`.
3. Controles:
   - mover: flechas o WASD
   - disparar: barra espaciadora

