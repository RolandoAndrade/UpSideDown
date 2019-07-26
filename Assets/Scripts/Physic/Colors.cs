using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors
{
    public static Color AZUL = getColor(133, 193, 233, 1);
    public static Color ROJO = getColor(241, 148, 138, 1);
    public static Color MORADO = getColor(187, 143, 206, 1);
    public static Color TURQUESA = getColor(163, 228, 215, 1);
    public static Color VERDE = getColor(171, 235, 198, 1);
    public static Color AMARILLO = getColor(249, 231, 159, 1);
    public static Color NARANJA = getColor(237, 187, 153, 1);
    public static Color GRIS = getColor(174, 182, 191, 1);
    public static Color ROSADO = getColor(195, 155, 211, 1);
    public static Color AZULGRIS = getColor(171, 178, 185, 1);
    public static Color MORADOINTENSO = getColor(165, 105, 189, 1);
    public static Color GRISCLARO = getColor(215, 219, 221, 1);
    public static Color DEEP_ORANGE = getColor(229, 152, 102, 1);
    public static Color ESMERALD = getColor(88, 214, 141, 1);
    public static Color GRAY = getColor(128, 139, 150, 1);
    public static List<Color> RANDOM = new List<Color>(new Color[]{AZUL, ROJO, MORADO,TURQUESA,VERDE,AMARILLO,NARANJA,ROSADO,AZULGRIS,MORADOINTENSO,
    DEEP_ORANGE,ESMERALD});
    public static Color getColor(float r, float g, float b, float a)
    {
        return new Color(r / 255f, g / 255f, b / 255f, a);
    }
    public static Color Random()
    {
        int aux = new System.Random().Next(RANDOM.Count);
        return RANDOM[aux];
    }
}
