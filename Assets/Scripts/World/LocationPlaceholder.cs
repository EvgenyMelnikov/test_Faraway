using UnityEngine;

/// <summary>
/// Класс хранилище юнити обьектов и настроек границ мира
/// </summary>
public class LocationPlaceholder : MonoBehaviour
{
    public Transform Container;
    public Camera Camera;

    public Vector2 Size => Camera.ViewportToWorldPoint(new Vector3(1, 1, 0)) * 2 + Vector3.right * 2;
    public float RightBorder => Size.x / 2;
    public float LeftBorder => -RightBorder;
}