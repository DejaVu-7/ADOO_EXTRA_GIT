# Space Game - Patrones de Diseño

Este proyecto es un juego shooter 2D desarrollado en Unity que implementa 7 patrones de diseño en el proyecto

## Patrones implementados

1. **Singleton**
   - **Por qué:** Para garantizar que exista solo una instancia global de los sistemas centrales del juego, permitiendo acceso desde cualquier script sin acoplar objetos directamente
   - **Dónde:** `GameManager.cs` (gestiona estado del juego y escenas)

2. **Observer / Event**
   - **Por qué:** Para desacoplar la lógica del jugador y los enemigos de la UI, permitiendo que los cambios en vida o muerte se reflejen automáticamente en la interfaz
   - **Dónde:** 
     - `UIManager.cs` se suscribe a `Jugador.OnVidaCambiada` para actualizar la barra de vida
     - `UIManager.cs` se suscribe a `Enemigo.OnEnemigoDestruido` para actualizar el puntaje

3. **Factory / Fabrica de Fábricas**
   - **Por qué:** Para crear enemigos de manera flexible y sin acoplar el spawner a tipos concretos, facilitando añadir nuevos enemigos sin modificar el spawner
   - **Dónde:** `EnemySpawner.cs` crea instancias de `EnemigoRapido` y `EnemigoFuerte` de manera aleatoria

4. **Abstract Factory / Clases abstractas**
   - **Por qué:** Para definir un contrato de comportamiento común para todos los enemigos (`Enemigo.cs`), obligando a las subclases a implementar el método `Mover()`
   - **Dónde:** `Enemigo.cs` (clase abstracta), `EnemigoFuerte.cs`, `EnemigoRapido.cs`

5. **Interface / Polimorfismo**
   - **Por qué:** Para permitir que cualquier objeto que pueda recibir daño implemente un contrato común (`IDanable`), simplificando la interacción entre proyectiles y objetivos
   - **Dónde:** `IDanable.cs` implementada en `Jugador.cs`, `Enemigo.cs`, `EnemyProjectile.cs`

6. **Delegates / Events para comunicación entre objetos**
   - **Por qué:** Para notificar de manera eficiente cuando un enemigo es destruido o cambia la vida del jugador, sin crear dependencias directas
   - **Dónde:** 
     - `Enemigo.OnEnemigoDestruido`  
     - `Jugador.OnVidaCambiada`  
     - usado por `UIManager.cs` para actualizar la UI

7. **Component / Modularidad**
   - **Por qué:** Para separar responsabilidades en componentes individuales, siguiendo la arquitectura de Unity y SOLID. Cada script tiene una sola responsabilidad: mover, disparar, controlar UI, spawnear enemigos, etc
   - **Dónde:**  
     - `Jugador.cs` → movimiento y disparo del jugador  
     - `Proyectil.cs` y `EnemyProjectile.cs` → lógica de proyectiles  
     - `UIManager.cs` → gestión de la interfaz  
     - `EnemySpawner.cs` → generación de enemigos  
     - `GameManager.cs` → control general del juego  

## Cómo usar el proyecto

1. Abrir el proyecto en Unity 6
2. Ejecutar la escena principal `Menu`.
3. Controles:
   - mover: flechas o WASD
   - disparar: barra espaciadora

