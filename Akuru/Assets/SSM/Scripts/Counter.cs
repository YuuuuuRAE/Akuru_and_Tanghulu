using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    // ���ķ� ã�Ƽ� ����Ʈ�� �ֱ�
    public LayerMask tanghuluLayer; // "Tanghulu" ���̾ ����
    public List<GameObject> tanghuluObjects = new List<GameObject>();

    // ī���Ϳ� ���� �մ�
    public GameObject customer;

    // �մ��� ī���Ϳ� ����� ���
    public bool isCustomer;

    // ���ð� ����
    public float payDelay;
    public Slider progress;

    // ���ķ� �� �ݾ� ����
    public float price;

    // ���ӽð�
    public float acceleration = 1.5f;

    public void Update()
    {
        // �� ������Ʈ���� "Tanghulu" ���̾ ���� ��� ���� ������Ʈ�� ã�� ����Ʈ�� ����
        tanghuluObjects.Clear(); // ���� ����Ʈ�� �ʱ�ȭ

        GameObject[] allObjects = FindObjectsOfType<GameObject>(); // ��� ���� ������Ʈ�� ã��
        foreach (GameObject obj in allObjects)
        {
            if (((1 << obj.layer) & tanghuluLayer) != 0)
            {
                // "Tanghulu" ���̾ �ش��ϴ� ���� ������Ʈ�� ����Ʈ�� �߰�
                tanghuluObjects.Add(obj);
            }
        }

        // �մ� ��� ����
        if (isCustomer)
        {
            // Customer ������Ʈ�� �̸����� �ε��� ����
            string customerName = customer.name;
            int customerIndex = int.Parse(customerName.Substring(customerName.IndexOf('(') + 1, 1));

            // Customer�� ��Ī�Ǵ� Tanghulu ������Ʈ �̸� ����
            string tanghuluName = "Tanghulu (" + customerIndex + ")(Clone)";

            // Tanghulu ������Ʈ ã��
            GameObject tanghulu = tanghuluObjects.Find(obj => obj.name == tanghuluName);

            if (tanghulu != null)
            {
                // Tanghulu ������Ʈ ��������
                Tanghulu tanghuluComponent = tanghulu.GetComponent<Tanghulu>();

                if (tanghuluComponent != null)
                {
                    // payDelay�� price ���� ��������
                    payDelay = tanghuluComponent.payDelay; // ���ӹ�� ����
                    price = tanghuluComponent.price;

                    // Tanghulu ������Ʈ ��Ȱ��ȭ
                    tanghulu.SetActive(false);
                    isCustomer = false;
                }
                Debug.Log("����簡 ���ϴ� ���ķ縦 �����Խ��ϴ�.");
            }
            else if (tanghuluObjects.Count > 0)
            {
                // �����忡 ���ϴ� Tanghulu�� ���� ��� ������ Tanghulu ������Ʈ ������Ʈ ��������
                int randomTanghuluIndex = Random.Range(0, tanghuluObjects.Count);
                if (randomTanghuluIndex >= 0 && randomTanghuluIndex < tanghuluObjects.Count)
                {
                    Tanghulu randomTanghuluComponent = tanghuluObjects[randomTanghuluIndex].GetComponent<Tanghulu>();
                    if (randomTanghuluComponent != null)
                    {
                        payDelay = randomTanghuluComponent.payDelay; // ���ӹ�� ����
                        price = randomTanghuluComponent.price;
                    }
                    // ���� Tanghulu ������Ʈ ��Ȱ��ȭ
                    randomTanghuluComponent.gameObject.SetActive(false);
                    isCustomer = false;
                }
                Debug.Log("�����忡 ���ϴ� ���ķ簡 �����ϴ�. ������ ���ķ縦 �����Խ��ϴ�.");
            }
            else
            {
                // �����忡 �ƹ��͵� ���� ���
                Debug.Log("�����忡 �ƹ��͵� �����ϴ�.");
            }

            // ���� ���� �ִ밪 ����
            progress.maxValue = payDelay;
        }
    

        // ��� �ð� ����ȭ
        if (payDelay > 0)
        {
            payDelay -= Time.deltaTime;
            progress.value = payDelay;
        }

        //����� ���� ��
        if (payDelay < 0)
        {
            customer.SetActive(false);
            progress.value = 0;
            payDelay = 0;
            GameManager.instance.currentCoin += price;
            Debug.Log("���� �߰� : " + price + "����");
        }
    }

    // ī���Ϳ� �մ��� ����� ��
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Customer")
        {
            customer = other.gameObject;
            isCustomer = true;
        }
    }

    // ��� ���ӹ�ư
    public void Acceleration()
    {
        if (payDelay > 0)
        {
            payDelay -= acceleration;

            Debug.Log("���ð� " + acceleration + "�� ����");
        }
        else
        {
            Debug.Log("��� ���� �ƴմϴ�.");
        }
    }
}
