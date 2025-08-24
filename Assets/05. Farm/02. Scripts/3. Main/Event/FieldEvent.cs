using Unity.Cinemachine;
using UnityEngine;

public class FieldEvent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetCameraState(CameraState.Field);
            GameManager.Instance.ui.ActivateFieldUI(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetCameraState(CameraState.Outside);
            GameManager.Instance.field.fieldState = FieldManager.FieldState.None;
            GameManager.Instance.ui.ActivateFieldUI(false);
        }
    }
}