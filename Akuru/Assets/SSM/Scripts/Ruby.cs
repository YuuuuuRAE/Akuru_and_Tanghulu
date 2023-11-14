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
        // ������ ���� �� ��ü ������ ������ ��ġ�� ���
        Vector3 offset = new Vector3(
            Random.Range(-dropRange, 0.4f), // ������ x ��ǥ ����
            Random.Range(-dropRange, 0.4f), // ������ y ��ǥ ����
            0
        );

        targetPosition = transform.position + offset;

        // ������ �̵� ����
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving)
        {
            // �������� ��ǥ ��ġ�� �̵�
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // ��ǥ ��ġ�� �����ϸ� �̵� ����
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

        // ���� �ؽ�Ʈ ���
        GameObject income = Instantiate(incomeText, transform.position, Quaternion.identity);
        income.GetComponent<Income>().income = ruby;
    }
}
