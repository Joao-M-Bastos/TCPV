using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{

    [SerializeField] float frente, altura, distancia;

    [SerializeField]  Transform playerTargetTransform;

    // Update is called once per frame
    void Update()
    {
        Vector3 camPosition = this.transform.position;

        if (camPosition.y != altura)
        {
            camPosition.y = altura;
        }

        if (camPosition.z != distancia)
        {
            camPosition.z = distancia;
        }

        if (camPosition.x != playerTargetTransform.position.x + frente)
        {
            camPosition.x = playerTargetTransform.position.x + frente;
        }

        this.transform.position = camPosition;
    }
}
