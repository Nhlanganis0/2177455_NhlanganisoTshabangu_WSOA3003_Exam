using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    [SerializeField] GameObject rotatePlatform;
    [SerializeField] GameObject movePlatform1;
    [SerializeField] GameObject movePlatform2;
    [SerializeField] GameObject slidePlatform;
    [SerializeField] GameObject slideUp_Platform;
    [SerializeField] GameObject Door1;
    [SerializeField] GameObject Door2;

    
    Animator rotatePlatform_anim;
    Animator slidePlatform_anim;
    Animator slideUp_Platform_anim;
    Animator Door1_anim;
    Animator Door2_anim;

    void Start()
    {
        rotatePlatform_anim = rotatePlatform.GetComponent<Animator>();
        slidePlatform_anim = slidePlatform.GetComponent<Animator>();
        slideUp_Platform_anim = slideUp_Platform.GetComponent<Animator>();
        Door1_anim = Door1.GetComponent<Animator>();
        Door2_anim = Door2.GetComponent<Animator>();
    }

    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ButtonTrigger1"))
        {
            StartCoroutine(DelayRotation());
        }

        if (collision.gameObject.CompareTag("ButtonTrigger2"))
        {
            movePlatform1.GetComponent<MovePlatform>().enabled = true;
        }

        if (collision.gameObject.CompareTag("SlideUpTrigger"))
        {
            movePlatform1.GetComponent<MovePlatform>().enabled = true;
            movePlatform2.GetComponent<MovePlatform>().enabled = true;
            Door1_anim.SetBool("CanOpen", true);
            Door2_anim.SetBool("CanOpen", true);
        }

        if (collision.gameObject.CompareTag("SlideButtonTrigger"))
        {
            StartCoroutine(DelaySlide());

        }

        if (collision.gameObject.CompareTag("ChipTrigger"))
        {
            StartCoroutine(DelaySlideUp());
        }
    }

    IEnumerator DelayRotation()
    {
        yield return new WaitForSeconds(2);
        rotatePlatform_anim.SetBool("Rotate", true);
    }

    IEnumerator DelaySlide()
    {
        yield return new WaitForSeconds(1);
        slidePlatform_anim.SetBool("Slide", true);
    }

    IEnumerator DelaySlideUp()
    {
        yield return new WaitForSeconds(2);
        slideUp_Platform_anim.SetBool("canOpen", true);
    }
}
