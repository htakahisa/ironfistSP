using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmokoCommand : MonoBehaviour
{
    [SerializeField]
    private int isAttacking = 0;
    int hp = 100;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update() {
        Animator anim = GetComponent<Animator>();
        if (Input.GetKey(KeyCode.Space)) {
            anim.SetBool("Attack", true);
        } else { 
            anim.SetBool("Attack", false); 
        }
        
        if (Input.GetKey(KeyCode.LeftArrow)) {
            //ç¿ïWÇèëÇ´ä∑Ç¶ÇÈ
            transform.position += new Vector3(-2, 0, 0) * Time.deltaTime;
            anim.SetBool("Walk", true);
        } 
        
        if (Input.GetKey(KeyCode.RightArrow)) {
            //ç¿ïWÇèëÇ´ä∑Ç¶ÇÈ
            transform.position += new Vector3(2, 0, 0) * Time.deltaTime;
            anim.SetBool("Walk", true);
        } 

        if (Input.GetKey(KeyCode.UpArrow)) {
            anim.SetBool("âäçñåù", true);
        } else {
            anim.SetBool("âäçñåù", false);
        }

        if(!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)) {
            anim.SetBool("Walk", false);
        }

       
    }



    private void OnTriggerStay2D(Collider2D collision) {
        ComputerController com = collision.gameObject.GetComponent<ComputerController>();
        if (com == null) {
            return;
        }
        if (com.getIsAttacking() > 0) {
            hp -= com.getIsAttacking();
            Debug.Log("omoko:" + hp);
            com.AnimEnd();

        }
    }



    public int getIsAttacking() {
        return this.isAttacking;
    }

    public void AnimStart(int power) {
        isAttacking = power;
    }

    public void punch(int power) {
        isAttacking = power;
        OmokoAttack omoAt = transform.GetChild(0).GetComponent<OmokoAttack>();
        omoAt.setActive(true);
    }


    public void attackB(int power) {
        isAttacking = power;
    }

    public void AnimEnd() {
        OmokoAttack omoAt = gameObject.GetComponentInChildren<OmokoAttack>();
        omoAt.setActive(false);
        isAttacking = 0;
    }

    public void damage(int damage) {

        this.hp -= damage;
        Debug.Log("omoko:" + hp);
    }

    public int getHp() {
        return this.hp;
    }



}
