using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryDialogue : MonoBehaviour
{
    public Queue<string> sentences;
    public void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Dialogue name " + dialogue.name);
    }
}
