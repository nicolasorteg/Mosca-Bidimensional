// empezamos creando el paquete Math que nos ayudará a generar la posición aleatoria de la Mosca.
using Math;

// opciones menú principal, declaras como const globales para mejorar la legibilidad y mantenibilidad del código
const int OPCION_MENU_PRINCIPAL_JUGAR = 1;
const int OPCION_MENU_PRINCIPAL_COMO_JUGAR = 2;
const int OPCION_MENU_PRINCIPAL_SALIR = 3;

// opciones para elegir la dificultad del juego
const int OPCION_MENU_JUEGO_FACIL = 1;
const int OPCION_MENU_JUEGO_MEDIO = 2;
const int OPCION_MENU_JUEGO_DIFICIL = 3;
const int OPCION_MENU_JUEGO_MAESTRO = 4;
const int OPCION_MENU_JUEGO_IMPOSIBLE = 5;
const int OPCION_MENU_JUEGO_ESTADISTICAS = 6;
const int OPCION_MENU_JUEGO_SALIR = 7;

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

// valores iniciales
const int VICTORIAS_INICIALES = 0;
const int PARTIDAS_INICIALES = 0;
const int INTENTOS_INICIALES = 0;

/*
Función Main. Es por donde se empieza a ejecutar el programa y se encarga de dar la bienvenida.
Después de la bienvenida comienza la simulación, empezando por el menú principal del juego.
*/
Main {
    writeLine("--🦟 Bienvenid@ al Minijuego de la Mosca 🦟--");
    ejecutarMenuPrincipal();
    writeLine("Fin del programa.");
}

/*
Gestiona el menú principal de la simulación. Se repite hasta que el usuario decida acabar con esta seleccionando salir
*/
procedure ejecutarMenuPrincipal() {
    // variable que almacena la opcion que elige el usuario del menú, inicializada al 0 para prevenir errores y garantizar la entrada
    int opcionElegida = 0;

    do {

        // menú
        writeLine("---- MENÚ PRINCIPAL ----");
        writeLine(OPCION_MENU_PRINCIPAL_JUGAR + ".- Entrar al juego 👾"); // 1
        writeLine(OPCION_MENU_PRINCIPAL_COMO_JUGAR + ".- ¿Cómo se juega? 🤷‍♀️"); // 2
        writeLine(OPCION_MENU_PRINCIPAL_SALIR + ".- Salir 😔"); // 3

        // 1a capa de validación: que no se introduzca texto
        opcionElegida = leerEntero("Opción elegida: "); 
        writeLine("---------------------------------");

        switch(opcionElegida) {
            case OPCION_MENU_PRINCIPAL_JUGAR: // 1
                seleccionarDificultad();
                break;

            case OPCION_MENU_PRINCIPAL_COMO_JUGAR: // 2
                mostrarInstrucciones();
                break; 

            case OPCION_MENU_PRINCIPAL_SALIR: // 3
                writeLine("Ha sido un placer 😉");
                break;

            default: // 2a capa de validación: que se introduzca una opción posible
                writeLine("❌ Opción introducida no válida. Introduzca una de las " + OPCION_MENU_PRINCIPAL_SALIR + " opciones posibles.");
                break;
        }
    } while (opcionElegida != OPCION_MENU_PRINCIPAL_SALIR); // se repite siempre y cuando NO se pulse la opción que sale del programa
}


/*
Se encarga de imprimir el Menu para seleccionar la dificultad del juego, además de la opción de mostrar las stats de la sesión.
Se repite hasta que se selecciona la opcion de volver al menú principal.
En este caso el 'switch' es algo más grande ya que requiere validar si con las stats actuales se puede jugar en esa dificultad.
*/
procedure seleccionarDificultad() {

    int opcionElegida = 0;

    // variables que almacenaran los datos que se mostraran en las estadísticas
    int victoriasFacil = VICTORIAS_INICIALES;
    int victoriasMedio = VICTORIAS_INICIALES;
    int victoriasDificil = VICTORIAS_INICIALES;
    int victoriasMaestro = VICTORIAS_INICIALES;
    int victoriasImposible = VICTORIAS_INICIALES;

    int numeroPartidasFacil = PARTIDAS_INICIALES;
    int numeroPartidasMedio = PARTIDAS_INICIALES;
    int numeroPartidasDificil = PARTIDAS_INICIALES;
    int numeroPartidasMaestro = PARTIDAS_INICIALES;
    int numeroPartidasImposible = PARTIDAS_INICIALES;

    int intentosTotalesFacil = INTENTOS_INICIALES;
    int intentosTotalesMedio = INTENTOS_INICIALES;
    int intentosTotalesDificil = INTENTOS_INICIALES;
    int intentosTotalesMaestro = INTENTOS_INICIALES;
    int intentosTotalesImposible = INTENTOS_INICIALES;

    do {
        // menú
        writeLine("---- SELECTOR DE DIFICULTAD ----");
        writeLine(OPCION_MENU_JUEGO_FACIL + ".- Fácil 😊");
        writeLine(OPCION_MENU_JUEGO_MEDIO + ".- Medio 🤔");
        writeLine(OPCION_MENU_JUEGO_DIFICIL + ".- Difícil 😨");
        writeLine(OPCION_MENU_JUEGO_MAESTRO + ".- Maestro 👺");
        writeLine(OPCION_MENU_JUEGO_IMPOSIBLE + ".- Imposible 💀");
        writeLine(OPCION_MENU_JUEGO_ESTADISTICAS + ".- Mostrar estadísticas 📊");
        writeLine(OPCION_MENU_JUEGO_SALIR + ".- Volver al menú.");

        // 1a capa de validación: que no se introduzca texto
        opcionElegida = leerEntero("Opción elegida: "); 
        writeLine("---------------------");

        // al ser un switch que solo llama a la funcion en caso de que haya ganado en la dificultad anterior se extrae a otra funcion para cumplir el Principio de Responsabilidad Única.
        gestionarDificultad(opcionElegida);

    } while (opcionElegida != OPCION_MENU_JUEGO_SALIR); // se repite siempre y cuando NO se pulse la opción que sale del selector de dificultad 
}

/*
Se encarga de llamar a la partida de su respectiva dificultad. 
Se podría hacer dentro de 'seleccionarDificultad', pero como dentro del switch hay que validar las victorias anteriores queda muy grande y no cumpliría del todo el Principio de Responsabilidad Única.
Se le pasa por valor la opción que elige el usuario.
*/
procedure gestionarDificultad(int opcionElegida) {

    // se llama a la respectiva funcion que simula cada dificultad. se le pasa por ref los datos para poder modificarlos y actualizar las stats
    // para desbloquear una dificultad se requiere al menos 1 win en las anteriores, para ello se usan los 'if' que no permiten la simulacion si no se cumple esto
    switch (opcionElegida) {

        case OPCION_MENU_JUEGO_FACIL: // 1
            simularPartidaFacil(ref victoriasFacil, ref numeroPartidasFacil, ref intentosTotalesFacil);
            break;

        case OPCION_MENU_JUEGO_MEDIO: // 2
            if (victoriasFacil >= 1) { // si ha ganado en la difultad anterior
                simularPartidaMedio(ref victoriasMedio, ref numeroPartidasMedio, ref intentosTotalesMedio);
            } else {
                writeLine("⛓ Dificultad bloqueada. Necesitas ganar el la dificultad 'Fácil' primero.");
            }
            break;

        case OPCION_MENU_JUEGO_DIFICIL: // 3
            if (victoriasMedio >= 1) { // si ha ganado en la difultad anterior
                simularPartidaDificil(ref victoriasDificil, ref numeroPartidasDificil, ref intentosTotalesDificil);
            } else {
                writeLine("⛓ Dificultad bloqueada. Necesitas ganar el la dificultad 'Medio' primero.");
            }
            break;

        case OPCION_MENU_JUEGO_MAESTRO: // 4
            if (victoriasDificil >= 1) { // si ha ganado en la difultad anterior
                simularPartidaMaestro(ref victoriasMaestro, ref numeroPartidasMaestro, ref intentosTotalesMaestro);
            } else {
                writeLine("⛓ Dificultad bloqueada. Necesitas ganar el la dificultad 'Dificil' primero.");
            }
            break;

        case OPCION_MENU_JUEGO_IMPOSIBLE: // 5
            if (victoriasMaestro >= 1) { // si ha ganado en la difultad anterior
                simularPartidaImposible(ref victoriasImposible, ref numeroPartidasImposible, ref intentosTotalesImposible);
            } else {
                writeLine("⛓ Dificultad bloqueada. Necesitas ganar el la dificultad 'Maestro' primero.");
            }
            break;

        case OPCION_MENU_JUEGO_ESTADISTICAS: // 6
            mostrarEstadisticas(ref victoriasFacil, ref numeroPartidasFacil, ref intentosTotalesFacil, 
                                ref victoriasMedio, ref numeroPartidasMedio, ref intentosTotalesMedio, 
                                ref victoriasDificil, ref numeroPartidasDificil, ref intentosTotalesDificil,
                                ref victoriasMaestro, ref numeroPartidasMaestro, ref intentosTotalesMaestro, 
                                ref victoriasImposible, ref numeroPartidasImposible, ref intentosTotalesImposible);
            break;

        case OPCION_MENU_JUEGO_SALIR: // 7
            writeLine("Volviendo al Menú Principal...");
            break;

        default: // 2a capa de validación: que se introduzca una opción posible
            writeLine("❌ Opción introducida no válida. Introduzca una de las " + OPCION_MENU_JUEGO_SALIR + " opciones posibles.");
            break;
    }
}




procedure simularPartidaFacil(ref int victoriasFacil, ref int numeroPartidasFacil, ref int intentosTotalesFacil) {

    // creacion del tablero, matriz rellena de 0
    int [][] panelJuego = int[FILAS_PANEL_FACIL][COLUMNAS_PANEL_FACIL];


}

procedure simularPartidaMedio(ref int victoriasMedio, ref int numeroPartidasMedio, ref int intentosTotalesMedio) {
    
    // creacion del tablero, matriz rellena de 0
    int [][] panelJuego = int[FILAS_PANEL_MEDIO][COLUMNAS_PANEL_MEDIO];


}

procedure simularPartidaDificil(ref int victoriasDificil, ref int numeroPartidasDificil, ref int intentosTotalesDificil) {

    // creacion del tablero, matriz rellena de 0
    int [][] panelJuego = int[FILAS_PANEL_DIFICIL][COLUMNAS_PANEL_d];


}

procedure simularPartidaMaestro(ref int victoriasMaestro, ref int numeroPartidasMaestro, ref int intentosTotalesMaestro) {

    // creacion del tablero, matriz rellena de 0
    int [][] panelJuego = int[FILAS_PANEL_MAESTRO][COLUMNAS_PANEL_MAESTRO];


}

procedure simularPartidaFacil(ref int victoriasFacil, ref int numeroPartidasFacil, ref int intentosTotalesFacil) {

    // creacion del tablero, matriz rellena de 0
    int [][] panelJuego = int[FILAS_PANEL_IMPOSIBLE][COLUMNAS_PANEL_IMPOSIBLE];


}



procedure mostrarInstrucciones() {
    writeLine("...");
}



/*
Se encarga de verificar que un valor pasado por teclado sea un número entero. 
En caso de que se introduzca una cadena de texto, el programa atrapa la excepción y pide de nuevo el dato.
Devuelve el valor leído.
*/
function int leerEntero(string message) {

    int valorLeido = 0;
    bool isFormatoCorrecto = false; //flag

    do {
        writeLine(message);
        try {
            valorLeido = (int)readLine(); 
            isFormatoCorrecto = true;
        } catch (FormatoException e) {
            writeLine("❌ Error de formato. Por favor, introduzca un número.");
        }
    } while (!isFormatoCorrecto); // se repite hasta que se introduzca un número

    return valorLeido; // devuelve el valor leido, no lo hace hasta que sea valido
}

