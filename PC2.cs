using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC2 : MonoBehaviour
{
    public float turnSpeed = .2f;
    public float moveSpeed = .1f;

    private Vector2 moveInput;

    public float x;
    public float y;

    //Euler z
    float z;

    //public Animator walk;
    public Animator walk;
    public Animator Emote1;


    public static int plantsPickedUp = 0;

    // Start is called before the first frame update
    void Start()
    {
        walk.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(plantsPickedUp);
        //wichtig für die Animation
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));


            //Drehung der Kamera mittels Pfeiltasten - "z" = Z-Achse
            if (Input.GetKey(KeyCode.RightArrow))
            {
                z = z - 10f;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                z = z + 10f;
            }

            //Dem momentanen Vector3 Eulerwert, wird ein neuer Wert zugeteilt
            //Nur der Z-Achse werden Werte genommen und hinzugefügt, um die Kamera nur von links nach rechts schwenken zu lassen
        Vector3 currentEulerAngles = new Vector3(0, 0, z) * turnSpeed;
        transform.eulerAngles = currentEulerAngles;

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.TransformDirection(Vector3.right) * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += transform.TransformDirection(Vector3.left) * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.TransformDirection(Vector3.up) * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += transform.TransformDirection(Vector3.down) * Time.deltaTime * moveSpeed;
        }


        //Animation

        if (moveInput.x == 0 && moveInput.y == 0)
        {
            walk.SetBool("isRunning", false);
        }
        else
        {
            walk.SetBool("isRunning", true);
        }

    }

    private void OnTriggerEnter2D(Collider2D cl2d)
    {
        if (cl2d.tag == "bush1")
        {

            Emote1.ResetTrigger("EmoteHappy");
            Emote1.SetTrigger("EmoteHappy");

            Emote1.ResetTrigger("EmoteOut");
            Emote1.SetTrigger("EmoteOut");
        }
    }

}
