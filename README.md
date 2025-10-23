# Mosca-Bidimensional
**Simulación del juego de la Mosca usando una matriz.**

El juego de la Mosca es un minijuego que consiste en intentar cazar una mosca que se encuentra en un Panel. La mosca se sitúa en un sitio aleatorio de el Panel y es el usuario el que debe intentar cazarla. Este introducirá la coordenada donde desee golpear, y hay 3 sucesos posibles:
- **Acierta la posición**. La mosca gasta una vida.
- **Golpea en una posición adyacente** (encima, debajo, lateral o diagonal). La mosca revolotea y se coloca en una posición aleatoria.
- **Falla el golpeo**. La mosca se queda donde está.

Además, en esta versión del juego se puede elegir la dificultad. Estas son las posibles dificultades:
- **__Fácil__** 😊-> Tablero 6x6.
- **Medio** 🤔-> Tablero 7x7. 2 vidas.
- **Difícil** 😨-> Tablero 8x8. 2 vidas. 10% de posibilidades de defenderse del golpeo.
- **Maestro** 👺-> Tablero 10x10. 3 vidas. 15% de posibilidades de defenderse del golpeo.
- **Imposible** 💀-> Tablero 15x15. 5 vidas. 50% de posibilidades de defenderse del golpeo.

Para desbloquear una dificultad se **requiere haber matado a la mosca de la dificultad anterior**.
Cada vez que la mosca consume una vida esta revolotea a una posición aleatoria.

## IMPORTANTE
El archivo está un un .cs (C#), pero el lenguaje usado es un **pseudocódigo** orientado a la enseñanza. Leer lenguaje-daw.md para más información.
