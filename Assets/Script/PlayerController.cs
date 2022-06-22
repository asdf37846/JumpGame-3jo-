using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Floor floor;
    Rigidbody2D rigid2D;
    Animator anim;
    float jumpForce = 500.0f;
    float walkForce = 30.0f;

    float maxWalkSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.floor = FindObjectOfType<Floor>();
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0) 
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }
        int key = 0;
        if (Input.GetKey(KeyCode.D)) key = 1;
        if (Input.GetKey(KeyCode.A)) key = -1;
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        if(speedx<this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
        if(key!=0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        this.anim.speed = speedx * 0.5f;
        if (this.gameObject.transform.position.y<-5)
        {
            floor.Return();
            transform.position = new Vector3(0, -1.1f, 0);
            rigid2D.velocity = new Vector3(0, 0, 0);
        }
    }
}
