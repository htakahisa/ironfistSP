using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour {

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
            //���W������������
            transform.position += new Vector3(-10, 0, 0) * Time.deltaTime;
            anim.SetBool("Walk", true);
        } else {
            anim.SetBool("Walk", false);
        }
        if (tomato == 3) {
            //���W������������
            transform.position += new Vector3(10, 0, 0) * Time.deltaTime;
            anim.SetBool("Walk", true);
        } else {
            anim.SetBool("Walk", false);
            if (tomato == 4) {
                anim.SetBool("������", true);             
            } else {
                anim.SetBool("������", false);
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
    }

    public void attackB(int power) {
        isAttacking = power;
    }


    public void AnimEnd() {
        isAttacking = 0;
    }


    public void damage(int damage) {

        this.hp -= damage;
        Debug.Log("com:" + hp);
    }

    public int getHp() {
        return this.hp;
    }

}
