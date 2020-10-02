using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehaviour : MonoBehaviour
{
    public float speed = 5f;

    private float mvt_hor = 0f;
    private float mvt_ver = 0f;
    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        mvt_hor = Input.GetAxis("Horizontal");
        mvt_ver = Input.GetAxis("Vertical");
        rigidBody.velocity = new Vector3(mvt_hor * speed, rigidBody.velocity.y, mvt_ver * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("player enter on collision with : " + collision.gameObject.name);
    }
}
