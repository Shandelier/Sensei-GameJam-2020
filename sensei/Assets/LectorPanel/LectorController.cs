using Core.SoundManager;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LectorController : MonoBehaviourSingleton<LectorController>
{
    public GameObject Panel;
    public Text TextField;
    public Image LectorIcon;

    public float maxDistance;
    public float speed;
    public bool forward;

    float startX;
    Color colorStart;
    bool showing;
    bool hiding;

    IEnumerator coroutine;

    void Start()
    {
        startX = LectorIcon.transform.position.x;
        //Color colorStart = Panel.GetComponent<Image>().material.color;
        //showing = false;
        //hiding = false;

        TextField.text = "Huh... are you waked up?";
        Panel.SetActive(false);
    }

    public void Show(float delay, float duration, string text)
    {
        StartCoroutine(ShowDialogue(delay, duration, text));
        int random = Random.Range(0, 4)%4;

        switch (random)
        {
            case 0:
                SoundManager.PlaySound(SoundManager.Sound.voice1);
                break;
            case 1:
                SoundManager.PlaySound(SoundManager.Sound.voice2); break;
            case 2:
                SoundManager.PlaySound(SoundManager.Sound.voice3); break;
            case 3:
                SoundManager.PlaySound(SoundManager.Sound.voice4); break;
            default:
                SoundManager.PlaySound(SoundManager.Sound.voice4); break;
        }
    }

    void Update()
    {
        if (LectorIcon.transform.position.x <= startX + maxDistance && forward)
        {
            LectorIcon.transform.position += Vector3.right * Time.deltaTime * speed * 2;
            //TextField.transform.position += Vector3.right * Time.deltaTime * speed;
            if (LectorIcon.transform.position.x >= startX + maxDistance)
            {
                forward = false;
            }
        }
        else if (LectorIcon.transform.position.x >= startX - maxDistance && !forward)
        {
            LectorIcon.transform.position -= Vector3.right * Time.deltaTime * speed * 2;
            //TextField.transform.position -= Vector3.right * Time.deltaTime * speed;
            if (LectorIcon.transform.position.x <= startX - maxDistance)
            {
                forward = true;
            }
        }

        /*
        if (showing && Panel.GetComponent<Image>().material.color.a < colorStart.a - 3)
        {
            Color colorBuffer = Panel.GetComponent<Image>().material.color;
            colorBuffer.a += Time.deltaTime * 1.2f;
            Panel.GetComponent<Image>().material.color = colorBuffer;
        }
        
        if (hiding)
        {
            Color colorBuffer = Panel.GetComponent<Image>().material.color;
            colorBuffer.a -= Time.deltaTime * 0.7f;
            Panel.GetComponent<Image>().material.color = colorBuffer;

            if (Panel.GetComponent<Image>().material.color.a < 3)
                hiding = false;
        }
        */
    }

    private IEnumerator ShowDialogue(float startTime, float duration, string text)
    {
        yield return new WaitForSeconds(startTime);
        Panel.SetActive(true);
        //showing = true;
        TextField.text = text;
        yield return new WaitForSeconds(duration);
        Panel.SetActive(false);
        //showing = false;
        //hiding = true;
    }
}
