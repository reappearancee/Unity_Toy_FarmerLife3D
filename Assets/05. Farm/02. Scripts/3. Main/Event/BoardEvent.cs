using System;
using UnityEngine;

public class BoardEvent : MonoBehaviour
{
    [SerializeField] private GameObject boardUI; // 보드를 선택하는 UI
    [SerializeField] private GameObject singleBoard;
    [SerializeField] private GameObject aiBoard;
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            boardUI.gameObject.SetActive(true);
            Single_BoardController.startAction?.Invoke();
            BoardController.startAction?.Invoke();
            
            GameManager.Instance.SetCameraState(CameraState.Board);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            boardUI.gameObject.SetActive(false);
            singleBoard.gameObject.SetActive(false);
            aiBoard.gameObject.SetActive(false);
            
            GameManager.Instance.SetCameraState(CameraState.House);
        }
    }
}