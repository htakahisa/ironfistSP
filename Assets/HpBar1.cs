using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI�g���Ƃ��͖Y�ꂸ�ɁB
using UnityEngine.UI;

public class HpBar1 : MonoBehaviour {
    //�ő�HP�ƌ��݂�HP�B
    //Slider������
    public Slider slider;
    public GameObject gameObject; 
    void Start() {
        //Slider�𖞃^���ɂ���B
        slider.value = 1;
    }
    private void Update() {
        ComputerController com = gameObject.GetComponent<ComputerController>();
        slider.value = com.getHp();

    }
}

