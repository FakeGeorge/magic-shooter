using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(0)]
public class AIManager : MonoBehaviour
{
    public List<AIUnit> aiUnitsInScene;

    private void Start()
    {
        // Inicializar la lista
        aiUnitsInScene = new List<AIUnit>();

        // Encontrar todos los objetos con el script MyScript
        AIUnit[] foundObjects = FindObjectsOfType<AIUnit>();

        // A�adirlos a la lista
        foreach (AIUnit obj in foundObjects)
        {
            aiUnitsInScene.Add(obj);
        }

        // Opcional: Imprimir el n�mero de objetos encontrados
        Debug.Log("N�mero de objetos encontrados: " + aiUnitsInScene.Count);
    }
}
