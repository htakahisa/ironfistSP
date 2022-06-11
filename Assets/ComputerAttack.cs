using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerAttack : MonoBehaviour
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
        OmokoCommand omoko = collision.gameObject.GetComponent<OmokoCommand>();
        if (omoko == null) {
            return;
        }

        ComputerController com = transform.parent.gameObject.GetComponent<ComputerController>();
        if (com.getIsAttacking() > 0) {
            omoko.damage(com.getIsAttacking());
            this.isActive = false;
        }
    }

    public void setActive(bool isActive) {
        this.isActive = isActive;
    }
}
