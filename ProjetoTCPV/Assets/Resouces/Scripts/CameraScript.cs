using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{

    [SerializeField] public float altura, profundidade;

    [SerializeField] public float alturaDaVisao;

    [SerializeField] Transform targetVision;

    [SerializeField] InputField alturaBox, profundidadeBox, targetAlturaBox;


    private void Start()
    {
        transform.LookAt(targetVision);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPosition = this.transform.position;

        if(camPosition.x != targetVision.position.x)
        {
            camPosition.x = targetVision.position.x;
        }

        if (camPosition.y != altura)
        {
            camPosition.y = altura;
        }

        if(camPosition.z != profundidade)
        {
            camPosition.z = profundidade;
        }

        if(targetVision.position.y != alturaDaVisao)
        {
            targetVision.position = new Vector3(targetVision.position.x, alturaDaVisao, targetVision.position.z);
            transform.LookAt(targetVision);
        }

        this.transform.position = camPosition;
    }

    public void SetAlturaCamera()
    {
        altura = float.Parse(alturaBox.text);
    }
    public void SetProfundidadeCamera(int value)
    {
        profundidade = -float.Parse(profundidadeBox.text) - 8;
    }
    public void SetAlturaDaVisao(int value)
    {
        alturaDaVisao = float.Parse(targetAlturaBox.text);
    }
}
