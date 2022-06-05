using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour {

    private bool isAttacking;

    private float time;
    int hp = 100;
    // Start is called before the first frame update
    void Start() {
       
    }

    // Update is called once per frame
    void Update() {

        time += Time.deltaTime;
        if (time > 1) {
            Command();
            time = 0;
        }
    }
    void Command() {
        int tomato = Random.Range(1, 5);
        Animator anim = GetComponent<Animator>();
        if (tomato == 1) {
            anim.SetBool("Attack", true);
        } else { anim.SetBool("Attack", false); }
        if (tomato == 2) {
            //À•W‚ğ‘‚«Š·‚¦‚é
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime;
            anim.SetBool("Walk", true);
        } else {
            anim.SetBool("Walk", false);
        }
        if (tomato == 3) {
            //À•W‚ğ‘‚«Š·‚¦‚é
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime;
            anim.SetBool("Walk", true);
        } else {
            anim.SetBool("Walk", false);
            if (tomato == 4) {
                anim.SetBool("‰Š–Œ", true);
            } else {
                anim.SetBool("‰Š–Œ", false);
            }
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        OmokoCommand com = collision.gameObject.GetComponent<OmokoCommand>();

        if (com.getIsAttacking()) {
            hp -= 1;
            Debug.Log("com:" + hp);
        }


    }


    public bool getIsAttacking() {
        return this.isAttacking;
    }

}
