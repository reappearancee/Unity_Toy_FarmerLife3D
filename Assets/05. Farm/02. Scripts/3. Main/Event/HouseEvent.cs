using System;
using Unity.Cinemachine;
using UnityEngine;

public class HouseEvent : MonoBehaviour
{
    [SerializeField] private GameObject houseTop; // 지붕 오브젝트
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            houseTop.SetActive(false);
            GameManager.Instance.SetCameraState(CameraState.House);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            houseTop.SetActive(true);
            GameManager.Instance.SetCameraState(CameraState.Outside);
        }
    }
}