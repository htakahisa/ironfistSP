using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmokoCommand : MonoBehaviour
{
    private bool isAttacking = true;
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



    private void OnTriggerEnter2D(Collider2D collision) {

        ComputerController com = collision.gameObject.GetComponent<ComputerController>();

        if (com.getIsAttacking()) {
            hp -= 1;
            Debug.Log("omoko:" + hp);
        }


    }



    public bool getIsAttacking() {
        return this.isAttacking;
    }





}
