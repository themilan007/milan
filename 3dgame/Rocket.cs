using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 5;
    [SerializeField] float angularSpeed = 180;

    void Update()
    {
        Transform self = transform;

        Vector3 targetDirection = target.position - self.position;  // Ebben az ir�nyban van a c�l
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);   // Ahhoz ebbe az ir�nyba akarunk fordulni

        // Fordul�s:
        float maxAngle = angularSpeed * Time.deltaTime;  // Maximum ekkora sz�gben fordulhatunk most
        self.rotation = Quaternion.RotateTowards(self.rotation, targetRotation, maxAngle);  // Towards met�dus

        // Halad�s:
        float offset = speed * Time.deltaTime;   // Ennyit l�p�nk el�re
        self.position += self.forward * offset;  // El�re ir�nyba megy�nk
    }
}
