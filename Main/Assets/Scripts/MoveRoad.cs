using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MoveRoad : MonoBehaviour
{
    public GameObject road;
    private void FixedUpdate()
    {
        float speed = (float)(DataHolder._startSpeed / 20);
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if(transform.position.y < -20f)
        {
            Instantiate(road, new Vector3(0f, 33f, 0f), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
