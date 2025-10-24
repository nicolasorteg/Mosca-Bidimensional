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


procedure simularPartidaFacil(ref int victoriasFacil, ref int numeroPartidasFacil, ref int intentosTotalesFacil) {

    // creacion del tablero, matriz rellena de 0
    int [][] panelJuego = int[FILAS_PANEL_FACIL][COLUMNAS_PANEL_FACIL];

    int filaElegida;
    int columnaElegida;
    int vidas = VIDAS_FACIL;
    bool isMoscaMuerta = false;

    generarPosicionMosca(panelJuego, FILAS_PANEL_FACIL, COLUMNAS_PANEL_FACIL);
    
    do {

        imprimirTabla(OPCION_MENU_JUEGO_FACIL);
        
        filaElegida = leerEntero("Golpeo en la fila: ");
        columnaElegida = leerEntero("Columna donde golpear: ");

        if (((filaElegida <= 0)  || (filaElegida > FILAS_PANEL_FACIL)) || ((columnaElegida <= 0)  || (columnaElegida > COLUMNAS_PANEL_FACIL))) {

            writeLine("❌ Posición no válida. Por favor, introduzca una posición de las disponibles, en este caso el tablero es " + FILAS_PANEL_FACIL + "x" + COLUMNAS_PANEL_FACIL);

        } else {

            comprobarGolpeo(filaElegida,columnaElegida, panelJuego, FILAS_PANEL_FACIL, COLUMNAS_PANEL_FACIL, ref vidas);
            intentosTotalesFacil += 1;

            if (vidas < 1) {
                isMoscaMuerta = true;
                victoriasFacil += 1;
                writeLine("🎉 ENHORABUENA. Has ganado la partida en dificultad FÁCIL.");
            }
        }
    } while (!isMoscaMuerta); // repite hasta que la mosca esté muerta

    numeroPartidasFacil += 1;
}


procedure simularPartidaMedio(ref int victoriasMedio, ref int numeroPartidasMedio, ref int intentosTotalesMedio) {
    
    // creacion del tablero, matriz rellena de 0
    int [][] panelJuego = int[FILAS_PANEL_MEDIO][COLUMNAS_PANEL_MEDIO];

    int filaElegida;
    int columnaElegida;
    int vidas = VIDAS_MEDIO;
    bool isMoscaMuerta = false;

    generarPosicionMosca(panelJuego, FILAS_PANEL_MEDIO, COLUMNAS_PANEL_MEDIO);
    
    do {
        
        imprimirTabla(OPCION_MENU_JUEGO_MEDIO);
        
        filaElegida = leerEntero("Golpeo en la fila: ");
        columnaElegida = leerEntero("Columna donde golpear: ");

        if (((filaElegida <= 0)  || (filaElegida > FILAS_PANEL_MEDIO)) || ((columnaElegida <= 0)  || (columnaElegida > COLUMNAS_PANEL_MEDIO))) {

            writeLine("❌ Posición no válida. Por favor, introduzca una posición de las disponibles, en este caso el tablero es " + FILAS_PANEL_MEDIO + "x" + COLUMNAS_PANEL_MEDIO);

        } else {

            comprobarGolpeo(filaElegida, columnaElegida, panelJuego, FILAS_PANEL_MEDIO, COLUMNAS_PANEL_MEDIO, ref vidas);
            intentosTotalesMedio += 1;

            if (vidas < 1) {
                isMoscaMuerta = true;
                victoriasMedio += 1;
                writeLine("🎉 ENHORABUENA. Has ganado la partida en dificultad MEDIO.");
            }
        }
    } while (!isMoscaMuerta); // repite hasta que la mosca esté muerta

    numeroPartidasMedio += 1;
}


procedure simularPartidaDificil(ref int victoriasDificil, ref int numeroPartidasDificil, ref int intentosTotalesDificil) {

    // creacion del tablero, matriz rellena de 0
    int [][] panelJuego = int[FILAS_PANEL_DIFICIL][COLUMNAS_PANEL_DIFICIL];

    int filaElegida;
    int columnaElegida;
    int vidas = VIDAS_DIFICIL;
    bool isMoscaMuerta = false;

    generarPosicionMosca(panelJuego, FILAS_PANEL_DIFICIL, COLUMNAS_PANEL_DIFICIL);
    
    do {

        imprimirTabla(OPCION_MENU_JUEGO_DIFICIL);
        
        filaElegida = leerEntero("Golpeo en la fila: ");
        columnaElegida = leerEntero("Columna donde golpear: ");

        if (((filaElegida <= 0)  || (filaElegida > FILAS_PANEL_DIFICIL)) || ((columnaElegida <= 0)  || (columnaElegida > COLUMNAS_PANEL_DIFICIL))) {

            writeLine("❌ Posición no válida. Por favor, introduzca una posición de las disponibles, en este caso el tablero es " + FILAS_PANEL_DIFICIL + "x" + COLUMNAS_PANEL_DIFICIL);

        } else {

            comprobarGolpeo(filaElegida, columnaElegida, panelJuego, FILAS_PANEL_DIFICIL, COLUMNAS_PANEL_DIFICIL, ref vidas);
            intentosTotalesDificil += 1;

            int num = Math.random(1, 100); 
            if (num <= PROBABILIDAD_PROTECCION_DIFICIL) {
                writeLine("🔮 El aura protectora de la Mosca para el golpeo (" + PROBABILIDAD_PROTECCION_DIFICIL + "% de que pase).");
            }

            if (vidas < 1) {
                isMoscaMuerta = true;
                victoriasDificil += 1;
                writeLine("🎉 ENHORABUENA. Has ganado la partida en dificultad DIFÍCIL.");
            }
        }
    } while (!isMoscaMuerta); // repite hasta que la mosca esté muerta

    numeroPartidasDificil += 1;

}


procedure simularPartidaMaestro(ref int victoriasMaestro, ref int numeroPartidasMaestro, ref int intentosTotalesMaestro) {

    // creacion del tablero, matriz rellena de 0
    int [][] panelJuego = int[FILAS_PANEL_MAESTRO][COLUMNAS_PANEL_MAESTRO];

    int filaElegida;
    int columnaElegida;
    int vidas = VIDAS_MAESTRO;
    bool isMoscaMuerta = false;

    generarPosicionMosca(panelJuego, FILAS_PANEL_MAESTRO, COLUMNAS_PANEL_MAESTRO);
    
    do {

        imprimirTabla(OPCION_MENU_JUEGO_DIFICIL);
        
        filaElegida = leerEntero("Golpeo en la fila: ");
        columnaElegida = leerEntero("Columna donde golpear: ");

        if (((filaElegida <= 0)  || (filaElegida > FILAS_PANEL_MAESTRO)) || ((columnaElegida <= 0)  || (columnaElegida > COLUMNAS_PANEL_MAESTRO))) {

            writeLine("❌ Posición no válida. Por favor, introduzca una posición de las disponibles, en este caso el tablero es " + FILAS_PANEL_MAESTRO + "x" + COLUMNAS_PANEL_MAESTRO);

        } else {

            comprobarGolpeo(filaElegida, columnaElegida, panelJuego, FILAS_PANEL_MAESTRO, COLUMNAS_PANEL_MAESTRO, ref vidas);
            intentosTotalesMaestro += 1;

            int num = Math.random(1, 100); 
            if (num <= PROBABILIDAD_PROTECCION_MAESTRO) {
                writeLine("🔮 El aura protectora de la Mosca para el golpeo (" + PROBABILIDAD_PROTECCION_MAESTRO + "% de que pase).");
            }

            if (vidas < 1) {
                isMoscaMuerta = true;
                victoriasMaestro += 1;
                writeLine("🎉 ENHORABUENA. Has ganado la partida en dificultad MAESTRO.");
            }
        }
    } while (!isMoscaMuerta); // repite hasta que la mosca esté muerta

    numeroPartidasMaestro += 1;
}


procedure simularPartidaImposible(ref int victoriasImposible, ref int numeroPartidasImposible, ref int intentosTotalesImposible) {

    // creacion del tablero, matriz rellena de 0
    int [][] panelJuego = int[FILAS_PANEL_IMPOSIBLE][COLUMNAS_PANEL_IMPOSIBLE];

    int filaElegida;
    int columnaElegida;
    int vidas = VIDAS_IMPOSIBLE;
    bool isMoscaMuerta = false;

    generarPosicionMosca(panelJuego, FILAS_PANEL_IMPOSIBLE, COLUMNAS_PANEL_IMPOSIBLE);
    
    do {

        imprimirTabla(OPCION_MENU_JUEGO_IMPOSIBLE);
        
        filaElegida = leerEntero("Golpeo en la fila: ");
        columnaElegida = leerEntero("Columna donde golpear: ");

        if (((filaElegida <= 0)  || (filaElegida > FILAS_PANEL_IMPOSIBLE)) || ((columnaElegida <= 0)  || (columnaElegida > COLUMNAS_PANEL_IMPOSIBLE))) {

            writeLine("❌ Posición no válida. Por favor, introduzca una posición de las disponibles, en este caso el tablero es " + FILAS_PANEL_IMPOSIBLE + "x" + COLUMNAS_PANEL_IMPOSIBLE);

        } else {

            comprobarGolpeo(filaElegida, columnaElegida, panelJuego, FILAS_PANEL_IMPOSIBLE, COLUMNAS_PANEL_IMPOSIBLE, ref vidas);
            intentosTotalesImposible += 1;

            int num = Math.random(1, 100); 
            if (num <= PROBABILIDAD_PROTECCION_IMPOSIBLE) {
                writeLine("🔮 El aura protectora de la Mosca para el golpeo (" + PROBABILIDAD_PROTECCION_IMPOSIBLE + "% de que pase).");
            } else if {
                        vidas -= 1;
            }

            if (vidas < 1) {
                isMoscaMuerta = true;
                victoriasImposible += 1;
                writeLine("🎉 ENHORABUENA. Has ganado la partida en dificultad IMPOSIBLE.");
            }
        }
    } while (!isMoscaMuerta); // repite hasta que la mosca esté muerta

    numeroPartidasImposible += 1;
}


/*

*/
procedure comprobarGolpeo(int filaElegida, int columnaElegida, int[][] panelJuego, int filaMaxima, int columnaMaxima, ref int vidas) {

    filaElegida -= 1;
    columnaElegida -= 1;

    if (panelJuego[filaElegida][columnaElegida] == 1) {
        writeLine("🟢 GOLPEASTE A LA MOSCA.");

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


procedure imprimirTabla(int dificultad) {

    switch (dificultad) {
        case OPCION_MENU_JUEGO_FACIL: // 1

            writeLine("-- BIENVENIDO AL JUEGO DE LA MOSCA. FÁCIL --");
            writeLine("--------------------------------------------");
            writeLine("-- TABLERO --");
            writeLine("    1    2    3    4   5    6");
            writeLine("1  [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("2  [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("3  [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("4  [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("5  [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("6  [❔] [❔] [❔] [❔] [❔] [❔]");
            break;

        case OPCION_MENU_JUEGO_MEDIO: // 2
            
            writeLine("-- BIENVENIDO AL JUEGO DE LA MOSCA. MEDIO --");
            writeLine("--------------------------------------------");
            writeLine("-- TABLERO --");
            writeLine("    1    2    3    4   5    6    7 ");
            writeLine("1  [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("2  [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("3  [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("4  [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("5  [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("6  [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("7  [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            break;
            
        case OPCION_MENU_JUEGO_DIFICIL: // 3
            
            writeLine("-- BIENVENIDO AL JUEGO DE LA MOSCA. DIFÍCIL --");
            writeLine("--------------------------------------------");
            writeLine("-- TABLERO --");
            writeLine("    1    2    3    4   5    6    7    8 ");
            writeLine("1  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("2  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("3  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("4  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("5  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("6  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("7  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("8  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            break;

        case OPCION_MENU_JUEGO_MAESTRO: // 4

            writeLine("-- BIENVENIDO AL JUEGO DE LA MOSCA. MAESTRO --");
            writeLine("--------------------------------------------");
            writeLine("-- TABLERO --");
            writeLine("    1    2    3    4   5    6    7    8    9   10");
            writeLine("1  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("2  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("3  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("4  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("5  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("6  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("7  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("8  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("9  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("10 [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            break;

        case OPCION_MENU_JUEGO_IMPOSIBLE: // 5
            
             writeLine("-- BIENVENIDO AL JUEGO DE LA MOSCA. IMPOSIBLE --");
            writeLine("--------------------------------------------");
            writeLine("-- TABLERO --");
            writeLine("    1    2    3    4   5    6    7    8    9   10  11   12   13  14   15 ");
            writeLine("1  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("2  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("3  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("4  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("5  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("6  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("7  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("8  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("9  [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("10 [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("11 [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("12 [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("13 [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("14 [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            writeLine("15 [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔] [❔]");
            break;

        default:
            writeLine("❌Dificultad no reconocida.");
            break;
    }
}
