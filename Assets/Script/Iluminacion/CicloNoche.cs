using UnityEngine;

public class NightCycle : MonoBehaviour
{
    public Light nightLight; // Referencia a la luz direccional
    public float cycleDuration = 10.0f; // Duraci�n del ciclo de 180 grados en segundos
    public GameObject Day;
    public GameObject Farolas;

    private bool activo = true;
    private float rotationSpeed;
    private int currentNight = 0;
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
        nightLight.transform.Rotate(Vector3.right, rotationThisFrame);

        // Actualiza la rotaci�n actual
        currentRotation += rotationThisFrame;

        UpdateLightIntensity();

        // Reinicia la rotaci�n despu�s de 180 grados
        if (currentRotation >= 180.0f)
        {

            this.gameObject.SetActive(false);
            currentRotation = 0.0f;
            currentNight++;
            nightLight.transform.rotation = Quaternion.Euler(0, 0, 0);
            Day.SetActive(true);
            
            Debug.Log("Noche " + currentNight );
        }
    }
    private void UpdateLightIntensity()
    {
        // Calcula el �ngulo actual de la luz en el rango de 0 a 180 grados
        float angle = currentRotation;

        // Calcula la intensidad basada en el �ngulo
        // M�xima intensidad (1.0) cuando el �ngulo es 90 grados (mediod�a)
        // Cero intensidad (0.0) cuando el �ngulo es 0 o 180 grados (amanecer y atardecer)
        float intensity = Mathf.Clamp(-Mathf.Abs(angle - 90) / 9.0f + 8.0f, 0.0f, 8.0f);

        // Actualiza la intensidad de la luz
        nightLight.intensity = intensity;
    }
}