using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullAndPush : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isAttached = false; // Biến để kiểm tra xem nhân vật có đang dính vào vật không
    private Transform attachedObject; // Transform của vật mà nhân vật đang dính vào

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*        // Kiểm tra nếu phím E được nhấn
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!isAttached)
                    {
                        Debug.Log("Phim E da duoc an");
                        // Nếu nhân vật chưa dính vào vật nào, thử dính vào vật
                        TryAttachToObject();
                    }
                    else
                    {
                        // Nếu nhân vật đang dính vào vật, thả ra
                        DetachFromObject();
                    }
                }
            }*/
    }

    void TryAttachToObject()
    {
        // Raycast để kiểm tra xem có vật nào ở phía trước của nhân vật không
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 1f);

        if (hit.collider != null)
        {
            // Nếu có vật, dính vào vật đó
            isAttached = true;
            attachedObject = hit.collider.transform;
        }
    }

    void DetachFromObject()
    {
        // Thả ra khỏi vật đang dính
        isAttached = false;
        attachedObject = null;
    }

    void FixedUpdate()
    {
        // Nếu nhân vật đang dính vào vật, di chuyển cùng với vật đó
        if (isAttached && attachedObject != null)
        {
            rb.MovePosition(attachedObject.position);
        }
    }
}
