using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float _speed = 1f;

    //cached references
    Rigidbody2D _myRigidBody;
    CircleCollider2D _myCollider;
    BoxCollider2D _groundToucher;
    // Start is called before the first frame update
    void Start()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
        _myCollider = GetComponent<CircleCollider2D>();
        _groundToucher = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            _myRigidBody.velocity = new Vector2(_speed, 0f);
        }
        else
        {
            _myRigidBody.velocity = new Vector2(-_speed, 0f);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(_myRigidBody.velocity.x)), 1f);
    }
}
