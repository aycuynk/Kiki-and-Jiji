using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class About : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject aboutCard;
    [SerializeField] GameObject OkSign;

    void Start() 
    {
        aboutCard.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        aboutCard.SetActive(true);
         OkSign.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        aboutCard.SetActive(false);
         OkSign.SetActive(false);
    }
    

}
