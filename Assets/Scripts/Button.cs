using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private ButtonAffected[] buttonAffecteds;
    [SerializeField] private Resize resize;
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject right;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals("Ball"))
        {
            resize.SetScale(transform.localScale.y / 2);
            resize.ResizeObject();
            left.SetActive(false);
            right.SetActive(false);
            foreach (ButtonAffected buttonAffected in buttonAffecteds)
            {
                buttonAffected.Buttoned();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag.Equals("Ball"))
        {
            resize.SetScale(transform.localScale.y);
            resize.ResizeObject();
            left.SetActive(true);
            right.SetActive(true);
            foreach (ButtonAffected buttonAffected in buttonAffecteds)
            {
                buttonAffected.UnBottoned();
            }

        }
    }


}
