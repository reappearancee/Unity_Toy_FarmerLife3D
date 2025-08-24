using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] private Transform centerPivot;

    [SerializeField] private Animator[] characterAnims;
    
    [SerializeField] private Button[] turnButtons; // 0 : Left / 1 : Right
    [SerializeField] private Button selectButton;
    
    private int currentIndex;

    private bool isTurn;

    void Start()
    {
        turnButtons[0].onClick.AddListener(() => Turn(true));
        turnButtons[1].onClick.AddListener(() => Turn(false));

        selectButton.onClick.AddListener(Select);
    }

    private void Turn(bool isLeft)
    {
        if (!isTurn)
        {
            isTurn = true;
            
            int value = isLeft ? -1 : 1;
            currentIndex += value;

            // 캐릭터가 4개이기 때문에 0 ~ 3까지 범위로 설정
            if (currentIndex < 0) currentIndex = 3;
            else if (currentIndex > 3) currentIndex = 0;

            float turnValue = value * 90;
            var targetRot = centerPivot.rotation * Quaternion.Euler(0, turnValue, 0);

            StartCoroutine(TurnRoutine(targetRot));
        }
    }

    IEnumerator TurnRoutine(Quaternion targetRot)
    {
        while (true)
        {
            yield return null; // while true문 사용시 무조건 안에 yield return이 필요

            // 부드럽게 회전
            centerPivot.rotation = Quaternion.Slerp(centerPivot.rotation, targetRot, 10f * Time.deltaTime);

            var angle = Quaternion.Angle(centerPivot.rotation, targetRot);
            if (angle <= 0.1f)
            {
                isTurn = false;
                centerPivot.rotation = targetRot;
                Debug.Log("Completed Turn");

                yield break;
            }
        }
    }

    private void Select()
    {
        Debug.Log($"현재 선택한 캐릭터는 {currentIndex}번째 캐릭터입니다.");
        
        // 선택한 캐릭터 인덱스 저장
        LoadSceneManager.Instance.SetCharacterIndex(currentIndex);
        
        StartCoroutine(SelectRoutine());
    }

    IEnumerator SelectRoutine()
    {
        characterAnims[currentIndex].SetTrigger("Select");

        yield return new WaitForSeconds(3f);

        LoadSceneManager.Instance.OnLoadScene();
    }

}