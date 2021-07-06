using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    /* public float Moving_Speed;
     public bool IS_Moving = true;
     public static Animator anim;
     public float speed;
     public float speed_1;
     public float x_Scale_1;
     public float x_Scale;
     public float y_Scale;

     void Update()
     {
         if (IS_Moving == true)
         {
             transform.Translate(speed * Time.deltaTime * Moving_Speed, 0, 0);
             transform.localScale = new Vector3(x_Scale_1, 1f, 1f);
         }
         else
         {
             transform.Translate(speed_1 * Time.deltaTime * Moving_Speed, 0, 0);
             transform.localScale = new Vector3(x_Scale, 1f, 1f);
         }
     }

     private void OnCollisionEnter(Collision collision)
     {
         print("Trigger1");
         if (collision.gameObject.CompareTag("Trigger"))
         {
             if (IS_Moving)
             {
                 IS_Moving = false;
             }
             else
             {
                 IS_Moving = true;
             }
         }
     }
    */

    [SerializeField] private bool ChanjeDirection = false;
    [SerializeField] private float Speed;
    CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        SwitchDirection();
    }

    void SwitchDirection()
    {
        if(ChanjeDirection == false)
        {
            Vector3 moveDown = Vector3.down;
            moveDown = Vector3.ClampMagnitude(moveDown, 1f);

            cc.Move(moveDown * Speed * Time.deltaTime);
        }

        if (ChanjeDirection == true)
        {
            Vector3 moveUp = Vector3.up;
            moveUp = Vector3.ClampMagnitude(moveUp, 1f);

            cc.Move(moveUp * Speed * Time.deltaTime);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (ChanjeDirection == false)
        {
            var HitTrigger1 = hit.gameObject.CompareTag("UpDownTrigger1");

            if (HitTrigger1)
            {
                ChanjeDirection = true;
            }
        }
        
        if(ChanjeDirection == true)
        {
            var HitTrigger2 = hit.gameObject.CompareTag("UpDownTrigger2");
            if (HitTrigger2)
            {
                ChanjeDirection = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           // collision.collider.transform.SetParent(transform);
           // collision.gameObject.GetComponent<Collider>().transform.SetParent(transform);
            print("Player");
        }
    }
}
