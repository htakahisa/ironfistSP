using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI使うときは忘れずに。
using UnityEngine.UI;

public class HpBar1 : MonoBehaviour {
    //最大HPと現在のHP。
    //Sliderを入れる
    public Slider slider;
    public GameObject gameObject; 
    void Start() {
        //Sliderを満タンにする。
        slider.value = 1;
    }
    private void Update() {
        ComputerController com = gameObject.GetComponent<ComputerController>();
        slider.value = com.getHp();

    }
}

