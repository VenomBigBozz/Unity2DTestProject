using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //current camera position
        Vector3 temp = transform.position;

        //temp position will be in te same position of player
        temp.x = playerTransform.position.x;

        if (playerTransform.position.y < 10 && playerTransform.position.y > -30)
            temp.y = playerTransform.position.y;

        //camera position setted as the same position of temp
        transform.position = temp;
    }
}
