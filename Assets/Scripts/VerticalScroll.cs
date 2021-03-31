using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{
    [SerializeField] float _waterSpeed = 1f;

    Rigidbody2D _myRigidBody;

    private void Start()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * _waterSpeed * Time.deltaTime);
    }
}
