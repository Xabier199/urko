using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionBoton : MonoBehaviour, IInteractable
{
    public List<Light> luces = new List<Light>(); // Lista de luces
    private bool encendido;

    public void Interact()
    {
        encendido = !encendido;

        foreach (Light luz in luces)
        {
            luz.enabled = encendido;
        }

        if (encendido)
        {
            Debug.Log("Luces encendidas");
        }
        else
        {
            Debug.Log("Luces apagadas");
        }
    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionBoton : MonoBehaviour, IInteractable
{
    public Light Luz1;
    private bool encendido;
    public void Interact()
    {
        if (encendido == true)
        {
            Debug.Log("Luz apagada");
            Luz1.enabled = false;
            encendido = false;
        }else if (encendido == false)
        {
            Debug.Log("Luz encendida");
            Luz1.enabled = true;
            encendido = true;   
        }
    }
}*/

