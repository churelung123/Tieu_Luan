using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;


public class StaminaManager : MonoBehaviour
{
    public ThirdPersonController thePlayer;
    public int maxStamina;
    public int currentStamina;
    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        thePlayer = FindObjectOfType<ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Obtacle(int regent, Vector3 direction, float obtacleForce)
    {
        currentStamina -= regent;
        thePlayer.Knockback(direction, obtacleForce);
    }

    public void StaminaPlayer(int staminaAmount)
    {
        currentStamina += staminaAmount;
        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
    }
}
