using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI�g���Ƃ��͖Y�ꂸ�ɁB
using UnityEngine.UI;

public class HpBar : MonoBehaviour {
    //�ő�HP�ƌ��݂�HP�B
    //Slider������
    public Slider slider;
    public GameObject omoko; 
    void Start() {
        //Slider�𖞃^���ɂ���B
        slider.value = 1;
    }
    private void Update() {
        OmokoCommand omo = omoko.GetComponent<OmokoCommand>();
        slider.value = omo.getHp();

    }
}

