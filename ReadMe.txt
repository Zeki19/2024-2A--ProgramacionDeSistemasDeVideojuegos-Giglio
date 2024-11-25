Como jugar?
A/D: moverse
E: Usar el poder
Q: Atacar con flecha

Patrones.
Stategy: esta implementado en la Habilidad que puede elegir el jugador. El player solo se entera de que cuando aprieta E deberia salir el poder. Utilizando strategy para darle la habilidad indicada.
Factory: Para crear unidades. Hay solo un prefab y la factory crea una unidad aliada o enemiga, melee o rango, dependiendo de lo pedido.
Command: Para la comunicacion de los botones con las unidades.
State: Los posibles estados de las unidades, searching, Attacking & cd.
StateMachine: Como cambia dentro de esos estados. Searching state --> camina para adelante y busca un contrincante --> Al encontrarlo --> Attacking state --> Ataca (Rango o Melee, depnede la clase) --> Entra en CD state. Y dependiendo si el contrincantte muere o se aleja vuelve a Attacking state o Searching state.  