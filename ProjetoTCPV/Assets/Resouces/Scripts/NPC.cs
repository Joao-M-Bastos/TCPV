using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] float speed;
    
    SimpleAlly simpleAlly;


    public bool directionRight;

    public void Awake()
    {
        simpleAlly = gameObject.GetComponent<SimpleAlly>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!directionRight)
        {
            transform.Rotate(0, 120, 0);
            speed *= -1;
        }
    }

    public void SetTarget(Transform target)
    {
        simpleAlly.targetPlace = target;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1,0,0)* Time.deltaTime * speed; 
    }

    private void OnTriggerEnter(Collider other)
    {
        int randomValue = Random.Range(5, 15);

        if(ManagerScrpt.feverValue >= randomValue)
        {
            simpleAlly.ChangeToAlly();
            this.gameObject.tag = "Ally";

            Destroy(this);
        }
    }
}
