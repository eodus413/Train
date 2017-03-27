using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) transform.Translate(Vector2.left * Time.deltaTime);
        if (Input.GetKey(KeyCode.D)) transform.Translate(Vector2.right * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space)) _rigidbody.velocity = (Vector2.up * 3);
    }
}
