using Unity.Cinemachine;
using UnityEngine;

public enum CameraState
{
    Outside, Field, House, Animal, Board
}

public class GameManager : Singleton<GameManager>
{
    public FieldManager field;
    public UIManager ui;
    public ItemManager item;
    
    public CameraState cameraState = CameraState.Outside;

    [SerializeField] private CinemachineClearShot clearShot;

    public void SetCameraState(CameraState newState)
    {
        if (cameraState != newState)
        {
            cameraState = newState;

            foreach (var camera in clearShot.ChildCameras)
                camera.Priority = 1;

            clearShot.ChildCameras[(int)cameraState].Priority = 10;
        }
    }
}