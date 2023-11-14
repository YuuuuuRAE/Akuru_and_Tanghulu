using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour
{
    public float ruby;
    public float moveSpeed = 2.0f;
    public float dropRange;
    public GameObject incomeText;

    private Vector3 targetPosition;
    private bool isMoving = false;

    private void Start()
    {
        // 아이템 생성 시 모체 주위의 랜덤한 위치를 계산
        Vector3 offset = new Vector3(
            Random.Range(-dropRange, 0.4f), // 랜덤한 x 좌표 범위
            Random.Range(-dropRange, 0.4f), // 랜덤한 y 좌표 범위
            0
        );

        targetPosition = transform.position + offset;

        // 아이템 이동 시작
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            // 아이템을 목표 위치로 이동
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // 목표 위치에 도달하면 이동 중지
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }

    public void OnMouseDown()
    {
        GameManager.instance.currentRuby += 100;
        Destroy(gameObject);

        // 수입 텍스트 출력
        GameObject income = Instantiate(incomeText, transform.position, Quaternion.identity);
        income.GetComponent<Income>().income = ruby;
    }
}
