using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvenScript : MonoBehaviour
{
    public Dialogue dialogue; // Tham chiếu đến DialogueManager

    // Phương thức này được gọi để kích hoạt đối thoại
    public void TriggerDialogue(int dialogueIndex)
    {
        dialogue.StartEventDialogue(dialogueIndex);
    }
}
