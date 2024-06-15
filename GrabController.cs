using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    /*// Biến để kiểm tra xem vật phẩm đã dính chưa
    private bool isStuck = false;

    // Biến để lưu trữ vị trí gốc của vật phẩm
    private Vector2 originalPosition;

    void Start()
    {
        // Lưu trữ vị trí gốc của vật phẩm khi bắt đầu
        originalPosition = transform.position;
    }

    void Update()
    {
        // Kiểm tra xem người chơi đã bấm Space chưa
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isStuck)
            {
                // Nếu đang dính thì thả ra
                Unstick();
            }
            else
            {
                // Nếu chưa dính thì dính vào
                Stick();
            }
        }
    }

    // Phương thức để dính vật phẩm
    void Stick()
    {
        // Lưu trạng thái dính
        isStuck = true;

        // Di chuyển vật phẩm về vị trí của người chơi (có thể thay đổi vị trí này tùy ý)
        transform.position = PlayerC.instance.transform.position;

        // Gắn vật phẩm vào người chơi (tùy thuộc vào vật phẩm và người chơi)
        transform.parent = PlayerController.instance.transform;
    }

    // Phương thức để thả vật phẩm
    void Unstick()
    {
        // Đặt lại trạng thái dính
        isStuck = false;

        // Thả vật phẩm khỏi người chơi
        transform.parent = null;

        // Đặt lại vị trí gốc của vật phẩm
        transform.position = originalPosition;
    }*/
}
