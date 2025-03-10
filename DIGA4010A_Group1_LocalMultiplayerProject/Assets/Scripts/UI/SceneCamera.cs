using UnityEngine;

public class SceneCamera : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        Canvas canvas = this.gameObject.GetComponent<Canvas>();

        canvas.worldCamera = mainCamera;
    }
}
