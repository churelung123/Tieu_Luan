using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obtacle : MonoBehaviour
{
    public int regentStamina = 2;
    public float obtacleForce = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            FindObjectOfType<StaminaManager>().Obtacle(regentStamina, hitDirection, obtacleForce);
        }
    }
}
