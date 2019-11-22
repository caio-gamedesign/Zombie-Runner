using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas damageCanvas;
    [SerializeField] float timeToFade = 0.3f;
    public const string LEFT = "left";
    public const string RIGHT = "right";

    private RectTransform rect;

    private void Start()
    {
        rect = damageCanvas.GetComponentInChildren<Image>().rectTransform;

        damageCanvas.enabled = false;   
    }

    public void ShowDamage(string direction = "")
    {
        StartCoroutine(ShowBlood(direction));
    }

    private IEnumerator ShowBlood(string direction = "")
    {
        float yDirection = 0;

        if (direction == LEFT)
        {
            yDirection = 180;
        }
        else if (direction == RIGHT)
        {
            yDirection = 0;
        }

        rect.eulerAngles = new Vector3(rect.eulerAngles.x, yDirection, rect.eulerAngles.z);

        damageCanvas.enabled = true;
        yield return new WaitForSeconds(timeToFade);
        damageCanvas.enabled = false;
    }
}
