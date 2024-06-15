using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    private static bool isInstantiated = false;
    private static string uniqueObjectKey = "UniqueObjectExists";

    void Awake()
    {
        // Kiểm tra nếu object đã được đánh dấu là tồn tại trong PlayerPrefs
        if (PlayerPrefs.GetInt(uniqueObjectKey, 0) == 2)
        {
            // Nếu object đã tồn tại, phá hủy object này
            Destroy(gameObject);
            return;
        }

        // Đảm bảo chỉ có một instance của object trong suốt quá trình chạy
        if (!isInstantiated)
        {
            isInstantiated = true;
            PlayerPrefs.SetInt(uniqueObjectKey, 1); // Lưu trạng thái object đã tồn tại vào PlayerPrefs
            DontDestroyOnLoad(gameObject); // Giữ object khi load scene khác
        }
        else
        {
            // Nếu đã có instance tồn tại, phá hủy object này
            Destroy(gameObject);
        }
    }

}
