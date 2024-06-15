using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePicture : MonoBehaviour
{
    /*    private Vector3 offSet;
        private float distanceToCamera;
        private RectTransform imageRect;

        private void Start()
        {
            imageRect = GetComponent<RectTransform>();  
        }
        private void OnMouseDown()
        {
            distanceToCamera = Vector3.Distance(transform.position, Camera.main.transform.position);
            offSet = transform.position - GetMouseWorldPosition();
        }
        private void OnMouseDrag()
        {
            Vector3 mousePosition = GetMouseWorldPosition();
            Vector3 newPosition = mousePosition + offSet;

            // Giới hạn vị trí mới của đối tượng trong kích thước của hình ảnh
            float minX = imageRect.rect.xMin;
            float maxX = imageRect.rect.xMax;
            float minY = imageRect.rect.yMin;
            float maxY = imageRect.rect.yMax;


            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

            transform.position = newPosition;

            *//*        Vector3 mousePosition = GetMouseWorldPosition();
                    Vector3 newPosition = mousePosition + offSet;
                    transform.position = newPosition;*//*
        }
        private Vector3 GetMouseWorldPosition()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = distanceToCamera;
            return Camera.main.ScreenToWorldPoint(mousePos);
        }*/
    private Vector2 offset;
    private RectTransform rectTransform;
    private Canvas canvas;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        if (canvas == null)
        {
            Debug.LogError("Canvas not found");
        }
    }

    private void OnMouseDown()
    {
        Vector2 localMousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, canvas.worldCamera, out localMousePosition);
        offset = rectTransform.anchoredPosition - localMousePosition;
    }

    private void OnMouseDrag()
    {
        Vector2 localMousePosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, canvas.worldCamera, out localMousePosition);
        Vector2 newPosition = localMousePosition + offset;

        // Get the parent RectTransform's bounds
        RectTransform parentRectTransform = rectTransform.parent as RectTransform;

        if (parentRectTransform != null)
        {
            Vector3[] parentCorners = new Vector3[4];
            parentRectTransform.GetWorldCorners(parentCorners);

            Vector3[] objectCorners = new Vector3[4];
            rectTransform.GetWorldCorners(objectCorners);

            float minX = parentCorners[0].x - objectCorners[0].x + rectTransform.anchoredPosition.x;
            float maxX = parentCorners[2].x - objectCorners[2].x + rectTransform.anchoredPosition.x;
            float minY = parentCorners[0].y - objectCorners[0].y + rectTransform.anchoredPosition.y;
            float maxY = parentCorners[2].y - objectCorners[2].y + rectTransform.anchoredPosition.y;

            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        }

        rectTransform.anchoredPosition = newPosition;
    }

}
