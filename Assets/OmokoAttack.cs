using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmokoAttack : MonoBehaviour
{

    [SerializeField]
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (!isActive) {
            return;
        }
        ComputerController com = collision.gameObject.GetComponent<ComputerController>();
        if (com == null) {
            return;
        }

        OmokoCommand omoko = transform.parent.gameObject.GetComponent<OmokoCommand>();
        if (omoko.getIsAttacking() > 0) {
            com.damage(omoko.getIsAttacking());
            this.isActive = false;
        }
    }

    public void setActive(bool isActive) {
        this.isActive = isActive;
    }
}
