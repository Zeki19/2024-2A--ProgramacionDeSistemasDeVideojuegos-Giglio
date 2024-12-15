Como jugar?
A/D: moverse
E: Usar el poder
Q: Atacar con flecha

Patrones.

- Pool: Implemente Pool para las unidades y las flechas. (Generic)
- Prototype: Uso el instantiate multiples veces en las factories.
- ServiceLocateor: Implemente un Locator e Installer para poder llamar a los distintos servicios que requiero, como al GameMediator o a la Pool cuando las unidades mueren.
- Flyweights, mis unidades usa SO.
- Command: Hice distintos commandos para facilitar el Spawn de los enemigos o para mandar mensajes a la MessageBox.
- Abstract Factory: La implemente para que controle a las factories conctretas que creean unidades o objetos.
- State: Implemente 3 estados en las unidades para controlar su comportamiento.
- State Machine: Cada unidad maneja y pasa de estados cuando cumplen una accion especifica.
- Strategy: Este patron esta implementado, para que las unidades solo tienen que Atacar, la strategy despues decidira de que manera (Melee o Rango).
- Wrapper: Esta implementado en la vida de las unidades.

Idea.
La idea del juego es que vengan hordas de enemigos y vos como el jugador las tengas que parar. Mucho un juego no es, pero si una aplicacion de los patrones de disenio.
