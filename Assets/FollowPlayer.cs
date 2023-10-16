using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform Player;
    
    [SerializeField] float posX = 5;
    [SerializeField] float posY = 5;
    [SerializeField] float posZ = 5;

    void Update()
    {   
        transform.position = new Vector3(Player.position.x + posX, Player.position.y + posY, Player.position.z - posZ);
    }
}
