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
const int PROBABILIDAD_PROTECCION_DIFICIL = 10; // 10%
const int PROBABILIDAD_PROTECCION_MAESTRO = 15; // 15%
const int PROBABILIDAD_PROTECCION_IMPOSIBLE = 50; // 50%

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
    // variables globales de sesión (persisten durante toda la ejecución del programa)
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

    int opcionElegida = 0;

    do {
        // menú principal
        writeLine("---- MENÚ PRINCIPAL ----");
        writeLine(OPCION_MENU_PRINCIPAL_JUGAR + ".- Entrar al juego 👾");
        writeLine(OPCION_MENU_PRINCIPAL_COMO_JUGAR + ".- ¿Cómo se juega? 🤷‍♀️");
        writeLine(OPCION_MENU_PRINCIPAL_SALIR + ".- Salir 😔");

        opcionElegida = leerEntero("Opción elegida: ");
        writeLine("---------------------------------");

        switch(opcionElegida) {
            case OPCION_MENU_PRINCIPAL_JUGAR:
                seleccionarDificultad(ref victoriasFacil, ref numeroPartidasFacil, ref intentosTotalesFacil,
                                      ref victoriasMedio, ref numeroPartidasMedio, ref intentosTotalesMedio,
                                      ref victoriasDificil, ref numeroPartidasDificil, ref intentosTotalesDificil,
                                      ref victoriasMaestro, ref numeroPartidasMaestro, ref intentosTotalesMaestro,
                                      ref victoriasImposible, ref numeroPartidasImposible, ref intentosTotalesImposible);
                break;

            case OPCION_MENU_PRINCIPAL_COMO_JUGAR:
                mostrarInstrucciones();
                break;

            case OPCION_MENU_PRINCIPAL_SALIR:
                writeLine("Ha sido un placer 😉");
                break;

            default:
                writeLine("❌ Opción introducida no válida. Introduzca una de las " + OPCION_MENU_PRINCIPAL_SALIR + " opciones posibles.");
                break;
        }

    } while (opcionElegida != OPCION_MENU_PRINCIPAL_SALIR);
}


procedure mostrarInstrucciones() {

    writeLine("--🦟 INSTRUCCIONES 🦟--");
    writeLine("El objetivo es golpear a la mosca hasta quitarle todas sus vidas.");
    writeLine("Cada golpe acertado le quita una vida, a no ser que el aura protectora pare el golpeo.");
    writeLine("Si fallas, la mosca puede quedarse quieta o moverse a otra posición(en caso de golpear al lado).");
    writeLine("--⚙️ DIFICULTADES ⚙️--");
    writeLine("🟢 FÁCIL:");
    writeLine(" - Tablero: 6x6");
    writeLine(" - Vidas de la mosca: 1");
    writeLine(" - Sin protección. Un golpe y muere.");
    writeLine("🟡 MEDIO:");
    writeLine(" - Tablero: 7x7");
    writeLine(" - Vidas de la mosca: 2");
    writeLine(" - No tiene protección, pero es más difícil acertar.");
    writeLine("🟠 DIFÍCIL:");
    writeLine(" - Tablero: 8x8");
    writeLine(" - Vidas de la mosca: 2");
    writeLine(" - La mosca tiene un 10% de probabilidad de protegerse.");
    writeLine("🔴 MAESTRO:");
    writeLine(" - Tablero: 10x10");
    writeLine(" - Vidas de la mosca: 3");
    writeLine(" - La mosca tiene un 15% de probabilidad de protegerse.");
    writeLine("💀 IMPOSIBLE:");
    writeLine(" - Tablero: 15x15");
    writeLine(" - Vidas de la mosca: 5");
    writeLine(" - La mosca tiene un 50% de probabilidad de protegerse.");
    writeLine("--❗ IMPORTANTE ❗--");
    writeLine("Debes ganar una partida en cada dificultad para desbloquear la siguiente.");
    writeLine("Buena suerte cazamoscas 😊");
}



/*
Se encarga de imprimir el Menu para seleccionar la dificultad del juego, además de la opción de mostrar las stats de la sesión.
Se repite hasta que se selecciona la opcion de volver al menú principal.
En este caso el 'switch' es algo más grande ya que requiere validar si con las stats actuales se puede jugar en esa dificultad.
*/
procedure seleccionarDificultad(ref int victoriasFacil, ref int numeroPartidasFacil, ref int intentosTotalesFacil,
                                ref int victoriasMedio, ref int numeroPartidasMedio, ref int intentosTotalesMedio,
                                ref int victoriasDificil, ref int numeroPartidasDificil, ref int intentosTotalesDificil,
                                ref int victoriasMaestro, ref int numeroPartidasMaestro, ref int intentosTotalesMaestro,
                                ref int victoriasImposible, ref int numeroPartidasImposible, ref int intentosTotalesImposible) {

    int opcionElegida = 0;

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
        gestionarDificultad(opcionElegida,  ref victoriasFacil, ref numeroPartidasFacil, ref intentosTotalesFacil,
                                            ref victoriasMedio, ref numeroPartidasMedio, ref intentosTotalesMedio,
                                            ref victoriasDificil, ref numeroPartidasDificil, ref intentosTotalesDificil,
                                            ref victoriasMaestro, ref numeroPartidasMaestro, ref intentosTotalesMaestro,
                                            ref victoriasImposible, ref numeroPartidasImposible, ref intentosTotalesImposible);

    } while (opcionElegida != OPCION_MENU_JUEGO_SALIR); // se repite siempre y cuando NO se pulse la opción que sale del selector de dificultad 
}


/*
Se encarga de llamar a la partida de su respectiva dificultad. 
Se podría hacer dentro de 'seleccionarDificultad', pero como dentro del switch hay que validar las victorias anteriores queda muy grande y no cumpliría del todo el Principio de Responsabilidad Única.
Se le pasa por valor la opción que elige el usuario.
*/
procedure gestionarDificultad(int opcionElegida, ref int victoriasFacil, ref int numeroPartidasFacil, ref int intentosTotalesFacil,
                                                 ref int victoriasMedio, ref int numeroPartidasMedio, ref int intentosTotalesMedio,
                                                 ref int victoriasDificil, ref int numeroPartidasDificil, ref int intentosTotalesDificil,
                                                 ref int victoriasMaestro, ref int numeroPartidasMaestro, ref int intentosTotalesMaestro,
                                                 ref int victoriasImposible, ref int numeroPartidasImposible, ref int intentosTotalesImposible) {

    // se llama a la respectiva funcion que simula cada dificultad. se le pasa por ref los datos para poder modificarlos y actualizar las stats
    // para desbloquear una dificultad se requiere al menos 1 win en las anteriores, para ello se usan los 'if' que no permiten la simulacion si no se cumple esto
    switch (opcionElegida) {

        case OPCION_MENU_JUEGO_FACIL: // 1
            simularPartida(OPCION_MENU_JUEGO_FACIL, ref victoriasFacil, ref numeroPartidasFacil, ref intentosTotalesFacil);
            break;

        case OPCION_MENU_JUEGO_MEDIO: // 2
            if (victoriasFacil >= 1) { // si ha ganado en la difultad anterior
                simularPartida(OPCION_MENU_JUEGO_MEDIO, ref victoriasMedio, ref numeroPartidasMedio, ref intentosTotalesMedio);
            } else {
                writeLine("⛓ Dificultad bloqueada. Necesitas ganar el la dificultad 'Fácil' primero.");
            }
            break;

        case OPCION_MENU_JUEGO_DIFICIL: // 3
            if (victoriasMedio >= 1) { // si ha ganado en la difultad anterior
                simularPartida(OPCION_MENU_JUEGO_DIFICIL, ref victoriasDificil, ref numeroPartidasDificil, ref intentosTotalesDificil);
            } else {
                writeLine("⛓ Dificultad bloqueada. Necesitas ganar el la dificultad 'Medio' primero.");
            }
            break;

        case OPCION_MENU_JUEGO_MAESTRO: // 4
            if (victoriasDificil >= 1) { // si ha ganado en la difultad anterior
                simularPartida(OPCION_MENU_JUEGO_MAESTRO, ref victoriasMaestro, ref numeroPartidasMaestro, ref intentosTotalesMaestro);
            } else {
                writeLine("⛓ Dificultad bloqueada. Necesitas ganar el la dificultad 'Dificil' primero.");
            }
            break;

        case OPCION_MENU_JUEGO_IMPOSIBLE: // 5
            if (victoriasMaestro >= 1) { // si ha ganado en la difultad anterior
                simularPartida(OPCION_MENU_JUEGO_IMPOSIBLE, ref victoriasImposible, ref numeroPartidasImposible, ref intentosTotalesImposible);
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

procedure mostrarEstadisticas(ref victoriasFacil, ref numeroPartidasFacil, ref intentosTotalesFacil, 
                                ref victoriasMedio, ref numeroPartidasMedio, ref intentosTotalesMedio, 
                                ref victoriasDificil, ref numeroPartidasDificil, ref intentosTotalesDificil,
                                ref victoriasMaestro, ref numeroPartidasMaestro, ref intentosTotalesMaestro, 
                                ref victoriasImposible, ref numeroPartidasImposible, ref intentosTotalesImposible) {

    int victoriasTotales = victoriasFacil + victoriasMedio + victoriasDificil + victoriasMaestro + victoriasImposible;
    int partidasTotales = numeroPartidasFacil + numeroPartidasMedio + numeroPartidasDificil + numeroPartidasMaestro + numeroPartidasImposible;
    int intentosTotales = intentosTotalesFacil + intentosTotalesMedio + intentosTotalesDificil + intentosTotalesMaestro + intentosTotalesImposible;

    decimal promedioFacil = (victoriasFacil > 0) ? ((decimal)intentosTotalesFacil / victoriasFacil) : 0;
    decimal promedioMedio = (victoriasMedio > 0) ? ((decimal)intentosTotalesMedio / victoriasMedio) : 0;
    decimal promedioDificil = (victoriasDificil > 0) ? ((decimal)intentosTotalesDificil / victoriasDificil) : 0;
    decimal promedioMaestro = (victoriasMaestro > 0) ? ((decimal)intentosTotalesMaestro / victoriasMaestro) : 0;
    decimal promedioImposible = (victoriasImposible > 0) ? ((decimal)intentosTotalesImposible / victoriasImposible) : 0;
    decimal promedioTotal = (victoriasTotales > 0) ? ((decimal)intentosTotales / victoriasTotales) : 0;

    writeLine("---- 😊 FÁCIL ----");
    writeLine("Victorias: " + victoriasFacil);
    writeLine("Partidas jugadas: " + numeroPartidasFacil);
    writeLine("Promedio de intentos por victoria: " + promedioFacil);
    writeLine("---- 🤔 MEDIO ----");
    writeLine("Victorias: " + victoriasMedio);
    writeLine("Partidas jugadas: " + numeroPartidasMedio);
    writeLine("Promedio de intentos por victoria: " + promedioMedio);
    writeLine("---- 😨 DIFÍCIL ----");
    writeLine("Victorias: " + victoriasDificil);
    writeLine("Partidas jugadas: " + numeroPartidasDificil);
    writeLine("Promedio de intentos por victoria: " + promedioDificil);
    writeLine("---- 👺 MAESTRO ----");
    writeLine("Victorias: " + victoriasMaestro);
    writeLine("Partidas jugadas: " + numeroPartidasMaestro);
    writeLine("Promedio de intentos por victoria: " + promedioMaestro);
    writeLine("---- 💀 IMPOSIBLE ----");
    writeLine("Victorias: " + victoriasImposible);
    writeLine("Partidas jugadas: " + numeroPartidasImposible);
    writeLine("Promedio de intentos por victoria: " + promedioImposible);
    writeLine("---------------------------------------------------");
    writeLine("🏁 DATOS GENERALES:");
    writeLine("Victorias totales: " + victoriasTotales);
    writeLine("Partidas totales: " + partidasTotales);
    writeLine("Promedio general de intentos por victoria: " + promedioTotal);
    writeLine("---------------------------------------------------");
}

procedure simularPartida(int dificultad, ref int victorias, ref int numeroPartidas, ref int intentosTotales) {

    int filas;
    int columnas;
    int vidas;
    int probProteccion = 0; // por defecto 0 para FACIL y MEDIO
    bool isMoscaMuerta = false;
    int intentosPartida = 0;

    switch (dificultad) {
        case OPCION_MENU_JUEGO_FACIL:
            filas = FILAS_PANEL_FACIL;
            columnas = COLUMNAS_PANEL_FACIL;
            vidas = VIDAS_FACIL;
            break;

        case OPCION_MENU_JUEGO_MEDIO:
            filas = FILAS_PANEL_MEDIO;
            columnas = COLUMNAS_PANEL_MEDIO;
            vidas = VIDAS_MEDIO;
            break;

        case OPCION_MENU_JUEGO_DIFICIL:
            filas = FILAS_PANEL_DIFICIL;
            columnas = COLUMNAS_PANEL_DIFICIL;
            vidas = VIDAS_DIFICIL;
            probProteccion = PROBABILIDAD_PROTECCION_DIFICIL;
            break;

        case OPCION_MENU_JUEGO_MAESTRO:
            filas = FILAS_PANEL_MAESTRO;
            columnas = COLUMNAS_PANEL_MAESTRO;
            vidas = VIDAS_MAESTRO;
            probProteccion = PROBABILIDAD_PROTECCION_MAESTRO;
            break;

        case OPCION_MENU_JUEGO_IMPOSIBLE:
            filas = FILAS_PANEL_IMPOSIBLE;
            columnas = COLUMNAS_PANEL_IMPOSIBLE;
            vidas = VIDAS_IMPOSIBLE;
            probProteccion = PROBABILIDAD_PROTECCION_IMPOSIBLE;
            break;

        default:
            writeLine("❌ Dificultad no reconocida.");
            return;
    }

    int [][] panelJuego = int[filas][columnas];
    generarPosicionMosca(panelJuego, filas, columnas);

    do {
        imprimirTabla(dificultad);

        int filaElegida = leerEntero("Golpeo en la fila: ");
        int columnaElegida = leerEntero("Columna donde golpear: ");

        if (filaElegida <= 0 || filaElegida > filas || columnaElegida <= 0 || columnaElegida > columnas) {
            writeLine("❌ Posición no válida. Tablero: " + filas + "x" + columnas);
        } else {

            comprobarGolpeo(filaElegida, columnaElegida, panelJuego, filas, columnas, probProteccion, ref vidas);
            intentosTotales += 1;
            intentosPartida += 1;

            writeLine("Intentos en esta partida: " + intentosPartida);

            if (vidas < 1) {
                isMoscaMuerta = true;
                victorias += 1;
                writeLine("🎉 ¡ENHORABUENA! Has ganado la partida en dificultad " + dificultad + ".");
            }
        }

    } while (!isMoscaMuerta); // no acaba hasta que la mosca está muerta

    numeroPartidas += 1; // 
}


procedure generarPosicionMosca(int[][] panelJuego, int filaMaxima, int columnaMaxima) {

    int filaMosca = Math.random(0, filaMaxima - 1);
    int columnaMosca = Math.random(0, columnaMaxima - 1);

    for (int i = 0; i < filaMaxima; i += 1) {
        for (int j = 0; j < columnaMaxima; j += 1) {
            
            panelJuego[i][j] = 0;
        }
    }
    panelJuego[filaMosca][columnaMosca] = 1;
}

procedure comprobarGolpeo(int filaElegida, int columnaElegida, int[][] panelJuego, int filaMaxima, int columnaMaxima, int probProteccion, ref int vidas) {

    filaElegida -= 1;
    columnaElegida -= 1;

    if (panelJuego[filaElegida][columnaElegida] == 1) {
        writeLine("🟢 GOLPEASTE A LA MOSCA.");

        if (probProteccion > 0) {
            int num = Math.random(1, 100);
            if ((num <= probProteccion)) {
                writeLine("🔮 El aura protectora de la Mosca bloquea el golpe (" + probProteccion + "%).");
            } else {
                vidas -= 1;
            }
        }

    } else if (((filaElegida < filaMaxima - 1) && (panelJuego[filaElegida + 1][columnaElegida] == 1)) ||                                               // ⬆️ comprobacion arriba
               ((filaElegida > 0) && (panelJuego[filaElegida - 1][columnaElegida] == 1)) ||                                                            // ⬇️ comprobacion abajo 
               ((columnaElegida > 0) && (panelJuego[filaElegida][columnaElegida - 1] == 1)) ||                                                         // ⬅️ comprobación izquierda
               ((columnaElegida < columnaMaxima - 1) && (panelJuego[filaElegida][columnaElegida + 1] == 1)) ||                                         // ➡️ comprobación derecha
               (((filaElegida < filaMaxima - 1) && (columnaElegida > 0)) && (panelJuego[filaElegida + 1][columnaElegida - 1] == 1)) ||                 // ↖️ comprobación abajo izquierda
               (((filaElegida < filaMaxima - 1) && (columnaElegida < columnaMaxima - 1)) && (panelJuego[filaElegida + 1][columnaElegida + 1] == 1)) || // ↗️ comprobación abajo derecha
               (((filaElegida > 0) && (columnaElegida > 0)) && (panelJuego[filaElegida - 1][columnaElegida - 1] == 1)) ||                              // ↙️ comprobación arriba izquierda
               (((filaElegida > 0) && (columnaElegida < columnaMaxima - 1)) && (panelJuego[filaElegida - 1][columnaElegida + 1] == 1))) {              // ↘️ comprobación arriba derecha

        generarPosicionMosca(panelJuego, filaMaxima, columnaMaxima);
        writeLine("🟡 CASI. La mosca revolotea a una posición aleatoria.");

    } else {
        
        writeLine("🔴 FALLO. No has golpeado cerca de la mosca, continúa en su posición.");
    }                                                                          
}


procedure imprimirTabla(int dificultad) {

    switch (dificultad) {
        case OPCION_MENU_JUEGO_FACIL: // 1

            writeLine("-- BIENVENIDO AL JUEGO DE LA MOSCA. FÁCIL --");
            writeLine("--------------------------------------------");
            writeLine("-- TABLERO --");
            writeLine("    1    2    3    4   5    6");

            for (int i = 1; i <= FILAS_PANEL_FACIL; i += 1) {
                writeLine(i + "  [❔] [❔] [❔] [❔] [❔] [❔]");
            }
            break;

        case OPCION_MENU_JUEGO_MEDIO: // 2
            
            writeLine("-- BIENVENIDO AL JUEGO DE LA MOSCA. MEDIO --");
            writeLine("--------------------------------------------");
            writeLine("-- TABLERO --");
            writeLine("    1    2    3    4   5    6    7 ");

            for (int i = 1; i <= FILAS_PANEL_MEDIO; i += 1) {
                writeLine(i + "  [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            }
            break;
            
        case OPCION_MENU_JUEGO_DIFICIL: // 3
            
            writeLine("-- BIENVENIDO AL JUEGO DE LA MOSCA. DIFÍCIL --");
            writeLine("--------------------------------------------");
            writeLine("-- TABLERO --");
            writeLine("    1    2    3    4   5    6    7    8 ");

            for (int i = 1; i <= FILAS_PANEL_DIFICIL; i += 1) {
                writeLine(i + "  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            }
            break;

        case OPCION_MENU_JUEGO_MAESTRO: // 4

            writeLine("-- BIENVENIDO AL JUEGO DE LA MOSCA. MAESTRO --");
            writeLine("--------------------------------------------");
            writeLine("-- TABLERO --");
            writeLine("    1    2    3    4   5    6    7    8    9   10");

            for (int i = 1; i <= FILAS_PANEL_MAESTRO; i += 1) {
                writeLine(i + "  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            }
            break;

        case OPCION_MENU_JUEGO_IMPOSIBLE: // 5
            
             writeLine("-- BIENVENIDO AL JUEGO DE LA MOSCA. IMPOSIBLE --");
            writeLine("--------------------------------------------");
            writeLine("-- TABLERO --");
            writeLine("    1    2    3    4   5    6    7    8    9   10  11   12   13  14   15 ");

            for (int i = 1; i <= FILAS_PANEL_IMPOSIBLE; i += 1) {
                writeLine(i + "  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            }
            break;

        default:
            writeLine("❌Dificultad no reconocida.");
            break;
    }
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
