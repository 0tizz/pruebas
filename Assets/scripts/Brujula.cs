using UnityEngine;

public class Brujula : MonoBehaviour
{
    public Transform objetivo;
    public bool mirandoHaciaObjetivo;
    public float rangoDeVision = 20f;

    void Update()
    {
        if (objetivo != null)
        {
            // Calcular la direcci�n hacia el objetivo
            Vector3 direccion = objetivo.position - transform.position;
            direccion.y = 0; // Mantener la br�jula en plano horizontal

            // Calcular la rotaci�n necesaria para mirar al objetivo
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);

            // Aplicar la rotaci�n gradualmente
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, Time.deltaTime * 5f);

            // Comprobar si est� mirando al objetivo dentro del rango de visi�n
            float anguloDiferencia = Quaternion.Angle(transform.rotation, rotacionObjetivo);
            mirandoHaciaObjetivo = anguloDiferencia < rangoDeVision;
        }
        else
        {
            mirandoHaciaObjetivo = false; // Si no hay objetivo, no est� mirando hacia �l
        }
    }
}
