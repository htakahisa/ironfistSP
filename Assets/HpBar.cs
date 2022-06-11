using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI使うときは忘れずに。
using UnityEngine.UI;

public class HpBar : MonoBehaviour {
    //最大HPと現在のHP。
    //Sliderを入れる
    public Slider slider;
    public GameObject omoko; 
    void Start() {
        //Sliderを満タンにする。
        slider.value = 1;
    }
    private void Update() {
        OmokoCommand omo = omoko.GetComponent<OmokoCommand>();
        slider.value = omo.getHp();

    }
}

