using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DilboMove : MonoBehaviour {

    //states
    const string S_WALK_RIGHT = "WalkingRight";
    const string S_WALK_LEFT = "WalkingLeft";
    const string S_WALK_UP = "WalkingUp";
    const string S_WALK_DOWN = "WalkingDown";

    //parameters
    const string P_RIGHT = "dilboRight";
    const string P_LEFT = "dilboLeft";
    const string P_UP = "dilboUp";
    const string P_DOWN = "dilboDown";

    public float speed = 2f;
    public bool right, left, up, down;
    public Animator anim;
    public KeyCode rk, lk, uk, dk;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
	// Update is called once per frame
	void Update () {
        MoveChar();
	}

    void MoveChar()
    {
        //if(Input.GetKeyDown(rk))
        //{
        //    anim.SetBool(P_LEFT, false);
        //    left = false;

        //    anim.SetBool(P_RIGHT, true);
        //    right = true;

        //    anim.SetBool(P_UP, false);
        //    up = false;

        //    anim.SetBool(P_DOWN, false);
        //    down = false;

        //    transform.Translate(Vector3.right * speed * Time.deltaTime);
        //}
        //if(Input.GetKeyDown(lk))
        //{
        //    anim.SetBool(P_LEFT, true);
        //    left = true;

        //    anim.SetBool(P_RIGHT, false);
        //    right = false;

        //    anim.SetBool(P_UP, false);
        //    up = false;

        //    anim.SetBool(P_DOWN, false);
        //    down = false;

        //    transform.Translate(Vector3.left * speed * Time.deltaTime);
        //}
        //if(Input.GetKeyDown(uk))
        //{
        //    anim.SetBool(P_LEFT, false);
        //    left = false;

        //    anim.SetBool(P_RIGHT, false);
        //    right = false;

        //    anim.SetBool(P_UP, true);
        //    up = true;

        //    anim.SetBool(P_DOWN, false);
        //    down = false;

        //    transform.Translate(Vector3.up * speed * Time.deltaTime);
        //}
        //if(Input.GetKeyDown(dk))
        //{
        //    anim.SetBool(P_LEFT, false);
        //    left = false;

        //    anim.SetBool(P_RIGHT, false);
        //    right = false;

        //    anim.SetBool(P_UP, false);
        //    up = false;

        //    anim.SetBool(P_DOWN, true);
        //    down = true;

        //    transform.Translate(Vector3.down * speed * Time.deltaTime);
        //}

        //continue moving if applicapble
        if(right)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        if(left)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (up)
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (down)
            transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
