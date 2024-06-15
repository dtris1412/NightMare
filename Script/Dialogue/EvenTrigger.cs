using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvenTrigger : MonoBehaviour
{
    
    public int eventIndex; // Chỉ số của sự kiện này
    private Dialogue dialogue;
    Player player;

    void Start()
    {
        dialogue = FindObjectOfType<Dialogue>();
        player = FindObjectOfType<Player>();    
    }

    // Hàm này sẽ được gọi để bắt đầu đối thoại của sự kiện
    public void TriggerDialogue()
    {
        dialogue.StartEventDialogue(eventIndex);
    }

    // Bạn có thể xóa hoặc không sử dụng phương thức này nếu không cần thiết
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
        
            TriggerDialogue();
        }
    }
}
