using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Frases
{
    private static string[] _frasesAlmacenadas = new string[] {
        "Mi corazon... Duele...",
        "Ay no, creo que me esta dando un ataque.",
        "Dentro del pecho hay algo que hace bom bom...",
        "La sangre deberia estar dentro de mi cuerpo, ¿no?",
        "¡Mi pierna!, ¡¡¡AAAAAHHHH!!!",
        "So... co... rroooo....",
        "O tengo hambre o algo me esta devorando por dentro.",
        "Creo que tengo un xenomorfo... deberia haber usado proteccion.",
        "¡Mi pecho!, ¡Dolor!",
        "Hay una viga en mi...",
        "No es por echarle mas hierro al asunto pero, ayuda...",
        "No puedo moverme, llamen a una ambulancia o algo.",
        "Que mareo, me han subido la factura de la luz.",
        "Hola buenas, ¿me puedes dar un paracetamol?",
        "Yo estoy sano, pero una revision siempre viene bien.",
        "¡EY, NO, LLEVAME A MI!",
        "¡YO ESTOY MAS GRAVE!",
        "Yo soy mejor que el, ¡Salvame!"

    };

    public static string GetFrase(int n)
    {
        if (n >= _frasesAlmacenadas.Length)
            return "null";

        return _frasesAlmacenadas[n];
    }
}
