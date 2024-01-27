using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class npc : MonoBehaviour
{
    public NPCConversation myConvo;
    GameObject cameraObject = GameObject.Find("Camera");

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
       // if (other.CompareTag("Player")) // Check if the collider is the player
        //{
            ConversationManager.Instance.StartConversation(myConvo);
            cameraObject.isInConversation = true;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        // Optional: Add any logic you want to happen when the player leaves the trigger area
    }
}