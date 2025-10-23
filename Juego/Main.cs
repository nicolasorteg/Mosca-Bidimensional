// empezamos creando el paquete Math que nos ayudará a generar la posición aleatoria de la Mosca.
using Math;

// opciones menú principal, declaras como const globales para mejorar la legibilidad y mantenibilidad del código
const int OPCION_MENU_PRINCIPAL_JUGAR = 1;
const int OPCION_MENU_PRINCIPAL_ESTADISTICAS = 2;
const int OPCION_MENU_PRINCIPAL_COMO_JUGAR = 3;
const int OPCION_MENU_PRINCIPAL_SALIR = 4;

// opciones para elegir la dificultad del juego
const int OPCION_MENU_JUEGO_FACIL = 1;
const int OPCION_MENU_JUEGO_MEDIO = 2;
const int OPCION_MENU_JUEGO_DIFICIL = 3;
const int OPCION_MENU_JUEGO_MAESTRO = 4;
const int OPCION_MENU_JUEGO_IMPOSIBLE = 5;
const int OPCION_MENU_JUEGO_SALIR = 6;

// --------- tamaños de los paneles según dificultad ---------
// FÁCIL
const int FILAS_PANEL_FACIL = 6;
const int COLUMNAS_PANEL_FACIL = 6;  
// MEDIO
const int FILAS_PANEL_MEDIO = 7;
const int COLUMNAS_PANEL_MEDIO = 7;  
// DIFÍCIL
const int FILAS_PANEL_DIFICIL = 8;
const int COLUMNAS_PANEL_DIFICIL = 8;  
// MAESTRO
const int FILAS_PANEL_MAESTRO = 10;
const int COLUMNAS_PANEL_MAESTRO = 10;  
// IMPOSIBLE
const int FILAS_PANEL_IMPOSIBLE = 15;
const int COLUMNAS_PANEL_IMPOSIBLE = 15;  

// --------- vidas según dificultad ---------
// FÁCIL
const int VIDAS_FACIL = 1;
// MEDIO
const int VIDAS_MEDIO = 2;
// DIFÍCIL
const int VIDAS_DIFICIL = 2;
// MAESTRO
const int VIDAS_MAESTRO = 3;
// IMPOSIBLE
const int VIDAS_IMPOSIBLE = 5;

// --------- probabilidad de defensa ---------
const decimal PROBABILIDAD_PROTECCION_DIFICIL = 0.10; // 10%
const decimal PROBABILIDAD_PROTECCION_MAESTRO = 0.15; // 15%
const decimal PROBABILIDAD_PROTECCION_IMPOSIBLE = 0.50; // 50%


/*
Función Main. Es por donde se empieza a ejecutar el programa y se encarga de dar la bienvenida.
Después de la bienvenida comienza la simulación, empezando por el menú principal del juego.
*/
Main {
    writeLine("--🦟 Bienvenid@ al Minijuego de la Mosca 🦟--");
    ejecutarMenuPrincipal();
}


procedure ejecutarMenuPrincipal() {
    // variable que almacena la opcion que elige el usuario del menú, inicializada al 0 para prevenir errores y garantizar la entrada
    int opcionElegida = 0;

    do {

        writeLine("---- MENÚ PRINCIPAL ----");
        writeLine(OPCION_MENU_PRINCIPAL_JUGAR + ".- Jugar 👾"); // 1
        writeLine(OPCION_MENU_PRINCIPAL_ESTADISTICAS + ".- Mostrar estadísticas 📊"); // 2
        writeLine(OPCION_MENU_PRINCIPAL_COMO_JUGAR + ".- ¿Cómo se juega? 🤷‍♀️"); // 3
        writeLine(OPCION_MENU_PRINCIPAL_SALIR + ".- Salir 😔"); // 4

        opcionElegida = leerEntero("Opción elegida: ");
        writeLine("--------------------");







        
    } while (opcionElegida != OPCION_MENU_PRINCIPAL_SALIR); // se repite siempre y cuando NO se pulse la opción que sale del programa
}
    

