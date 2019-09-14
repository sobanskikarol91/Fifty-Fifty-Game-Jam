using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    Transform player;
    private void Start()
    {
      player =  GameManager.instance.Player;
    }

    void Update()
    {

        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
