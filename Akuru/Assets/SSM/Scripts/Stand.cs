using UnityEngine;

public class Stand : MonoBehaviour
{
    // 좌우로 이동시킬 위치의 보정값
    Vector3 leftBias = new Vector3(-0.4f, 0, 0);
    Vector3 rightBias = new Vector3(0.4f, 0, 0);

    // 탕후루를 생성하고 위치를 설정하는 메서드
    public void SpawnTanghuluGameObjects(GameObject tanghuluObject, int count)
    {
        // 주어진 개수만큼 탕후루 생성하고 위치 설정
        for (int i = 0; i < count; i++)
        {
            var tobj = Instantiate(tanghuluObject);
            SetTanghuluPosition(tobj.transform, i);
        }
    }

    // 탕후루의 위치를 설정하는 메서드
    private void SetTanghuluPosition(Transform tanghuluTr, int index)
    {
        // 인덱스에 따라 좌우 위치 조정
        if (index == 0)
        {
            tanghuluTr.position = transform.position + leftBias;
        }
        else if (index == 1)
        {
            tanghuluTr.position = transform.position + rightBias;
        }
        else if (index == 2)
        {
            tanghuluTr.position = transform.position;
        }
    }
}
