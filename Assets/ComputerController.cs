using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour {

    [SerializeField]
    private int isAttacking = 0;

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
        } else {
            anim.SetBool("Attack", false);
        }
        if (tomato == 2) {
            //À•W‚ğ‘‚«Š·‚¦‚é
            // transform.position += new Vector3(-10, 0, 0) * Time.deltaTime;

        Rigidbody2D rb = this.GetComponent<Rigidbody2D> ();  // rigidbody‚ğæ“¾
        Vector3 force = new Vector3 (-1,0.0f,0.0f);    // —Í‚ğİ’è
        rb.AddForce (force, ForceMode2D.Impulse); 

            anim.SetBool("Walk", true);
        } else {
            anim.SetBool("Walk", false);
        }
        if (tomato == 3) {
            //À•W‚ğ‘‚«Š·‚¦‚é
            // transform.position += new Vector3(10, 0, 0) * Time.deltaTime;
        Rigidbody2D rb = this.GetComponent<Rigidbody2D> ();  // rigidbody‚ğæ“¾
        Vector3 force = new Vector3 (-2,0.0f,0.0f);    // —Í‚ğİ’è
        rb.AddForce (force, ForceMode2D.Impulse);
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

    private void OnTriggerStay2D(Collider2D collision) {

        OmokoCommand com = collision.gameObject.GetComponent<OmokoCommand>();
        if (com == null) {
            return;
        }
        if (com.getIsAttacking() > 0) {
            hp -= com.getIsAttacking();
            Debug.Log("com:" + hp);
            com.AnimEnd();

 
          
        }
    }


    public int getIsAttacking() {
        return isAttacking;
    }

    public void punch(int power) {
        isAttacking = power;
        ComputerAttack at = transform.GetChild(0).GetComponent<ComputerAttack>();
        at.setActive(true);
    }

    public void attackB(int power) {
        isAttacking = power;
    }


    public void AnimEnd() {
        isAttacking = 0;
        
        ComputerAttack at = transform.GetChild(0).GetComponent<ComputerAttack>();
        at.setActive(false);
    }


    public void damage(int damage) {

        this.hp -= damage;

        float burst = (100 - this.hp) / 10 / 2;

        Rigidbody2D rb = this.GetComponent<Rigidbody2D> ();  // rigidbody‚ğæ“¾
        Vector3 force = new Vector3 (burst,burst,0.0f);    // —Í‚ğİ’è
        rb.AddForce (force, ForceMode2D.Impulse); 

        Debug.Log("com:" + hp);
    }

    public int getHp() {
        return this.hp;
    }

}
