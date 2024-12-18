using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class DayNightCycle : MonoBehaviour
{
    public Light dayLight; // Referencia a la luz direccional
    public float cycleDuration = 10.0f; // Duraci�n del ciclo de 180 grados en segundos
    public GameObject Night;
    public GameObject Farolas;
    public Material daySkybox;

    private bool activo = true;
    private float rotationSpeed;
    private int currentDay = 0;
    private float currentRotation = 0.0f;

    private void Start()
    {
        // Calcula la velocidad de rotaci�n necesaria para completar 180 grados en el tiempo dado
        rotationSpeed = 180.0f / cycleDuration;

        // Establece el skybox inicial a d�a
        UnityEngine.RenderSettings.skybox = daySkybox;

        // Establece la luz ambiental inicial
        UnityEngine.RenderSettings.ambientIntensity = 1.0f;
    }

    private void Update()
    {
        // Calcula la rotaci�n de la luz en cada frame
        float rotationThisFrame = rotationSpeed * Time.deltaTime;
        dayLight.transform.Rotate(Vector3.right, rotationThisFrame);

        // Actualiza la rotaci�n actual
        currentRotation += rotationThisFrame;

        UpdateLightIntensity();

        if (currentRotation >= 160.0f)
        {
            // Encender la luz de las farolas
            Farolas.SetActive(true);
        }
        else if (currentRotation >= 30.0f && currentRotation <= 60.0f)
        {
            Farolas.SetActive(false);
        }

        // Reinicia la rotaci�n despu�s de 180 grados
        if (currentRotation >= 180.0f)
        {
            // Reiniciar rotaci�n, activar la luz de noche y desactivar el objeto
            this.gameObject.SetActive(false);
            currentRotation = 0.0f;
            currentDay++;
            dayLight.transform.rotation = Quaternion.Euler(0, 0, 0);

            // Cambiar el skybox a noche
            UnityEngine.RenderSettings.skybox = null; // Limpiar el skybox para evitar problemas
            UnityEngine.RenderSettings.skybox = Night.GetComponent<NightCycle>().nightSkybox;

            // Reducir la intensidad de la luz ambiental para la noche
            UnityEngine.RenderSettings.ambientIntensity = 0.2f;

            Night.SetActive(true);
            Debug.Log("D�a " + currentDay);
        }
    }

    private void UpdateLightIntensity()
    {
        // Calcula el �ngulo actual de la luz en el rango de 0 a 180 grados
        float angle = currentRotation;

        // Calcula la intensidad basada en el �ngulo
        // M�xima intensidad (1.0) cuando el �ngulo es 90 grados (mediod�a)
        // Cero intensidad (0.0) cuando el �ngulo es 0 o 180 grados (amanecer y atardecer)
        float intensity = Mathf.Clamp(-Mathf.Abs(angle - 90) / 9.0f + 10.0f, 0.0f, 10.0f);

        // Actualiza la intensidad de la luz
        dayLight.intensity = intensity;
    }
}



/*using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class DayNightCycle : MonoBehaviour
{
    public Light dayLight; // Referencia a la luz direccional
    public float cycleDuration = 10.0f; // Duraci�n del ciclo de 180 grados en segundos
    public GameObject Night;
    public GameObject Farolas;

    private bool activo = true;
    private float rotationSpeed;
    private int currentDay = 0;
    private float currentRotation = 0.0f;

    private void Start()
    {
        // Calcula la velocidad de rotaci�n necesaria para completar 180 grados en el tiempo dado
        rotationSpeed = 180.0f / cycleDuration;
    }

    private void Update()
    {
        // Calcula la rotaci�n de la luz en cada frame
        float rotationThisFrame = rotationSpeed * Time.deltaTime;
        dayLight.transform.Rotate(Vector3.right, rotationThisFrame);

        // Actualiza la rotaci�n actual
        currentRotation += rotationThisFrame;

        UpdateLightIntensity();

        if (currentRotation >= 160.0f)
        {
            //Encender la luz de las farolas
            Farolas.SetActive(true);
          
        }else if (currentRotation >= 30.0f && currentRotation <= 60.0f)

        {
            Farolas.SetActive(false);
        }


        // Reinicia la rotaci�n despu�s de 180 grados
        if (currentRotation >= 180.0f)
        {
            //Reiniciar rotaci�n, activar la luz de noche y desactivar el objeto
            this.gameObject.SetActive(false);
            currentRotation = 0.0f;
            currentDay++;
            dayLight.transform.rotation = Quaternion.Euler(0, 0, 0);
            Night.SetActive(true);
            Debug.Log("Dia " + currentDay);
        }



    }
    private void UpdateLightIntensity()
    {
        // Calcula el �ngulo actual de la luz en el rango de 0 a 180 grados
        float angle = currentRotation;

        // Calcula la intensidad basada en el �ngulo
        // M�xima intensidad (1.0) cuando el �ngulo es 90 grados (mediod�a)
        // Cero intensidad (0.0) cuando el �ngulo es 0 o 180 grados (amanecer y atardecer)
        float intensity = Mathf.Clamp(-Mathf.Abs(angle - 90) / 9.0f + 10.0f, 0.0f, 10.0f);

        // Actualiza la intensidad de la luz
        dayLight.intensity = intensity;
    }
}*/

