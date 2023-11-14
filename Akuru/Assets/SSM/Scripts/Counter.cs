using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    // 탕후루 찾아서 리스트에 넣기
    public LayerMask tanghuluLayer; // "Tanghulu" 레이어를 지정
    public List<GameObject> tanghuluObjects = new List<GameObject>();

    // 카운터에 닿은 손님
    public GameObject customer;
    public Animator anim;

    // 손님이 카운터에 닿았을 경우
    public bool isCustomer;

    // 계산시간 관련
    public float payDelay;
    public Slider progress;

    // 탕후루 별 금액 변수
    public float price;

    // 수입 텍스트
    public GameObject incomeText;
    public Transform calculatorPos;

    // 각 아쿠루 별 원하는 탕후루를 구매한 횟수(호감도)
    public float[] salesCount;

    // 가속시간
    public float acceleration = 3f;

    // 루비 드롭관련
    public GameObject rubyPrefab;
    public bool isRuby = false;
    public float dropRate;
    public GameObject dropTable;
    public int likability;

    public void Update()
    {
        // 매 업데이트마다 "Tanghulu" 레이어에 속한 모든 게임 오브젝트를 찾아 리스트를 갱신
        tanghuluObjects.Clear(); // 기존 리스트를 초기화

        GameObject[] allObjects = FindObjectsOfType<GameObject>(); // 모든 게임 오브젝트를 찾기
        foreach (GameObject obj in allObjects)
        {
            if (((1 << obj.layer) & tanghuluLayer) != 0)
            {
                // "Tanghulu" 레이어에 해당하는 게임 오브젝트는 리스트에 추가
                tanghuluObjects.Add(obj);
            }
        }

        // 손님 계산 관련
        if (isCustomer)
        { // Customer 오브젝트의 이름에서 인덱스 추출
            string customerName = customer.name;
            int customerIndex = int.Parse(customerName.Substring(customerName.IndexOf('(') + 1, 1));

            // Customer와 매칭되는 Tanghulu 오브젝트 이름 구성
            string tanghuluName = "Tanghulu (" + customerIndex + ")(Clone)";

            anim = customer.GetComponent<Animator>();

            // Tanghulu 오브젝트 찾기
            GameObject tanghulu = tanghuluObjects.Find(obj => obj.name == tanghuluName);

            if (tanghulu != null)
            {
                // Tanghulu 컴포넌트 가져오기
                Tanghulu tanghuluComponent = tanghulu.GetComponent<Tanghulu>();

                if (tanghuluComponent != null)
                {
                    // payDelay와 price 변수 가져오기
                    payDelay = tanghuluComponent.payDelay;
                    price = tanghuluComponent.price;

                    // Tanghulu 오브젝트 비활성화
                    tanghulu.SetActive(false);
                    isCustomer = false;
                }
                // 판매수 1씩 증가
                salesCount[customerIndex - 1] += 1;

                // 판매된 탕후루의 개수만큼 감소
                GameManager.instance.standsNumList[tanghuluComponent.index]--;

                
                anim.SetBool("Success", true);

                // 계산이 끝난 후 루비 드랍
                isRuby = true;

                // 루비 드랍률 조정
                if (salesCount[customerIndex - 1] < 100)
                {
                    likability = 0;
                }
                else if (salesCount[customerIndex - 1] < 200)
                {
                    likability = 1;
                }
                else if (salesCount[customerIndex - 1] < 300)
                {
                    likability = 2;
                }
                else
                {
                    likability = 3;
                }
                // 루비 드롭률 셋팅
                dropTable = GameObject.Find("Customer List Manager");
                dropRate = dropTable.GetComponent<CustomerList>().dropValues[customerIndex - 1][likability];
                Debug.Log("아쿠루가 원하는 탕후루를 가져왔습니다.");
            }
            else if (tanghuluObjects.Count > 0)
            {
                // 진열장에 원하는 Tanghulu가 없는 경우 랜덤한 Tanghulu 오브젝트 컴포넌트 가져오기
                int randomTanghuluIndex = Random.Range(0, tanghuluObjects.Count);
                if (randomTanghuluIndex >= 0 && randomTanghuluIndex < tanghuluObjects.Count)
                {
                    Tanghulu randomTanghuluComponent = tanghuluObjects[randomTanghuluIndex].GetComponent<Tanghulu>();
                    if (randomTanghuluComponent != null)
                    {
                        payDelay = randomTanghuluComponent.payDelay;
                        price = randomTanghuluComponent.price;
                    }
                    // 랜덤 Tanghulu 오브젝트 비활성화
                    randomTanghuluComponent.gameObject.SetActive(false);
                    isCustomer = false;
                    GameManager.instance.standsNumList[randomTanghuluComponent.index]--;
                }
                Debug.Log("진열장에 원하는 탕후루가 없습니다. 랜덤한 탕후루를 가져왔습니다.");
            }
            else
            {
                // 진열장에 아무것도 없는 경우
                Debug.Log("진열장에 아무것도 없습니다.");
            }

            // 진행 바의 최대값 설정
            progress.maxValue = payDelay;
        }
    

        // 계산 시간 동기화
        if (payDelay > 0)
        {
            payDelay -= Time.deltaTime;
            progress.value = payDelay;
            progress.gameObject.SetActive(true);
        }

        //계산이 끝날 시
        if (payDelay < 0)
        {
            customer.GetComponent<Customer>().customerRB.velocity = new Vector3(1, 0, 0);
            progress.value = 0;
            payDelay = 0;
            GameManager.instance.currentCoin += price;

            // 수입 텍스트 출력
            GameObject income = Instantiate(incomeText);
            income.transform.position = calculatorPos.position;
            income.GetComponent<Income>().income = price;

            // 계산이 끝난 후 드랍률에 따라 루비 드롭
            if (isRuby)
            {
                if (Random.Range(0, 100) < dropRate) // 드롭 확률
                {
                    DropRuby();
                }
                isRuby = false;
            }
            progress.gameObject.SetActive(false);
            Debug.Log("코인 추가 : " + price + "코인");
        }
    }

    // 카운터에 손님이 닿았을 때
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Customer")
        {
            customer = other.gameObject;
            isCustomer = true;
        }
    }

    // 계산 가속버튼
    public void Acceleration()
    {
        if (payDelay > 0)
        {
            payDelay -= acceleration;

            Debug.Log("계산시간 " + acceleration + "초 감소");
        }
        else
        {
            Debug.Log("계산 중이 아닙니다.");
        }
    }

    // 루비 드롭
    public void DropRuby()
    {
        GameObject newItem = Instantiate(rubyPrefab, transform.position, Quaternion.identity);

        Ruby itemMovement = newItem.GetComponent<Ruby>();
        if (itemMovement != null)
        {
            itemMovement.enabled = true;
        }
    }
}
