using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePosition : MonoBehaviour
{
    private string posXKey;
    private string posYKey;
    private string posZKey;

    private Vector3 initialPosition;

    void Awake()
    {
        // Sử dụng một khóa duy nhất cho mỗi object dựa trên tên của nó
        posXKey = gameObject.name + "_posX";
        posYKey = gameObject.name + "_posY";
        posZKey = gameObject.name + "_posZ";

        // Lưu trữ vị trí ban đầu
        initialPosition = transform.position;
    }

    void Start()
    {
        // Load vị trí khi scene bắt đầu, nếu có vị trí đã lưu
        LoadPosition();
    }

    void OnDisable()
    {
        // Lưu vị trí khi object bị vô hiệu hóa (chuyển scene)
        SavePositionData();
    }

    public void SavePositionData()
    {
        Vector3 position = transform.position;
        PlayerPrefs.SetFloat(posXKey, position.x);
        PlayerPrefs.SetFloat(posYKey, position.y);
        PlayerPrefs.SetFloat(posZKey, position.z);
        PlayerPrefs.Save();
    }

    public void LoadPosition()
    {
        // Chỉ load vị trí đã lưu khi chuyển scene, không phải khi khởi động game
        if (PlayerPrefs.HasKey(posXKey) && PlayerPrefs.HasKey(posYKey) && PlayerPrefs.HasKey(posZKey))
        {
            float x = PlayerPrefs.GetFloat(posXKey);
            float y = PlayerPrefs.GetFloat(posYKey);
            float z = PlayerPrefs.GetFloat(posZKey);
            transform.position = new Vector3(x, y, z);
        }
    }

    void OnApplicationQuit()
    {
        // Đảm bảo vị trí quay về ban đầu khi tắt game
        PlayerPrefs.DeleteKey(posXKey);
        PlayerPrefs.DeleteKey(posYKey);
        PlayerPrefs.DeleteKey(posZKey);
    }
}
