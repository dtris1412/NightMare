using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPushed : MonoBehaviour
{
    private SavePosition savePositionScript;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        savePositionScript = GetComponent<SavePosition>();
    }

    void Update()
    {
        // Kiểm tra nếu vật thể đang di chuyển
        if (rb.velocity.magnitude > 0.1f)
        {
            // Lưu vị trí của vật thể khi nó đang di chuyển
            savePositionScript.SavePositionData();
        }
    }
}
