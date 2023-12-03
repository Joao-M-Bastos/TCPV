using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{

    [SerializeField] float altura;

    [SerializeField]  Transform playerTargetTransform;

    int distacica;

    // Update is called once per frame
    void Update()
    {
        Vector3 camPosition = this.transform.position;

        if (camPosition.y != altura)
        {
            camPosition.y = altura;
        }

        if(distacica != playerTargetTransform.position.x)
        {
            camPosition.x = playerTargetTransform.position.x;
        }

        this.transform.position = camPosition;
    }
}
