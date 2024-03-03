using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class move : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 180f;
    
    private Rigidbody rb;
   public Joystick  joystick ;
   public Slider slider ;
   public int score;
   public TextMeshProUGUI text;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
     
    }

    void Update()
    {
        float verticalInput = joystick.Vertical;
        float horizontalInput = joystick.Horizontal;

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.3f);
         
        }
        else
        {
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("green"))
        {
            score = score+1;
            text.SetText(score.ToString());
            Destroy(other.gameObject);
        }
         if(other.gameObject.tag.Equals("black"))
        {
            slider.value -= 10;
            
            Destroy(other.gameObject);
        }
    }
}