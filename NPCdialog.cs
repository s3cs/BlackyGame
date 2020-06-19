using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCdialog : MonoBehaviour {

    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public string secondDialog;
    public bool PlayerInRange;
    public GameObject img;

    
    void Update()
    {
        if (!PlayerInRange)
        {
            dialogBox.SetActive(false);
        }
        if(PlayerInRange && PC2.plantsPickedUp != 3)
        {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
        }
        if (PlayerInRange && PC2.plantsPickedUp == 3)
        {
            dialogBox.SetActive(true);
            dialogText.text = secondDialog;
            img.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerInRange = false;
        }
    }
}
