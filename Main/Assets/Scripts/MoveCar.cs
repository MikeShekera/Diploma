using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        float speed = (float)(DataHolder._startSpeed / 20);
        if (transform.position.y < 0)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
