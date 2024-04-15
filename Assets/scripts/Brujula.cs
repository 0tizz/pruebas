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
            // Calcular la dirección hacia el objetivo
            Vector3 direccion = objetivo.position - transform.position;
            direccion.y = 0; // Mantener la brújula en plano horizontal

            // Calcular la rotación necesaria para mirar al objetivo
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);

            // Aplicar la rotación gradualmente
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, Time.deltaTime * 5f);

            // Comprobar si está mirando al objetivo dentro del rango de visión
            float anguloDiferencia = Quaternion.Angle(transform.rotation, rotacionObjetivo);
            mirandoHaciaObjetivo = anguloDiferencia < rangoDeVision;
        }
        else
        {
            mirandoHaciaObjetivo = false; // Si no hay objetivo, no está mirando hacia él
        }
    }
}
