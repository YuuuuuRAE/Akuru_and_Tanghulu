using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

//Add using
using UnityEngine.Events;

public class Roulette : MonoBehaviour
{
    [SerializeField]
    private Transform piecePrefab; // �귿�� ǥ�õǴ� ���� ������
    [SerializeField]
    private Transform linePrefab; // ���� ���� �� ������
    [SerializeField]
    private Transform pieceParent; //�������� ��ġ�Ǵ� �θ� Transform
    [SerializeField]
    private Transform lineParent; // ������ ��ġ�Ǵ� �θ� Transform
    [SerializeField]
    private RoulettePieceData[] roulettePieceData; // �귿�� ǥ�õǴ� ���� �迭

    [SerializeField]
    private int spinDuration; //ȸ�� �ð�
    [SerializeField]
    private Transform spinningRoulette; // ���� ȸ���ϴ� ȸ������ Transform
    [SerializeField]
    private AnimationCurve spinningCurve; // ȸ�� �ӵ� ��� ���� �׷���

    private float pieceAngle; //���� �ϳ��� ��ġ�� ����
    private float halfPieceAngle; //pieceAngle / 2
    private float halfPieceAngleWithPaddings; // ���� ���⸦ ����� Padding�� ���Ե� ���� ũ��

    private int accumlatedWeight; // ����ġ ����� ���� ����
    private bool isSpinning = false; //���� ȸ��������
    private int selectedIndex = 0; //�귿���� ���õ� ������

    private void Awake()
    {
        pieceAngle = 360 / roulettePieceData.Length;
        halfPieceAngle = pieceAngle * 0.5f;
        halfPieceAngleWithPaddings = halfPieceAngle - (halfPieceAngle * 0.25f);

        SpawnPiecesAndLines();
        CalculateWeightsAndIndices();

        //Debug
        //Debug.Log($"Index : {GetRandomIndex()}");
    }

    // ȸ���� ���� Function
    private void SpawnPiecesAndLines()
    {
        for (int i = 0; i < roulettePieceData.Length; i++)
        {
            Transform piece = Instantiate(piecePrefab, pieceParent.position, Quaternion.identity, pieceParent);
            // ������ �귿 ������ ���� ���� (Icon, ����)
            piece.GetComponent<RoulettePiece>().Setup(roulettePieceData[i]);
            // ������ �귿 ���� ȸ��
            piece.RotateAround(pieceParent.position, Vector3.back, (pieceAngle * i));

            Transform line = Instantiate(linePrefab, lineParent.position, Quaternion.identity, lineParent);
            //������ �� ȸ��
            line.RotateAround(lineParent.position, Vector3.back, (pieceAngle * i) + halfPieceAngle);
        }
    }

    //����ġ ��� �Լ� => �� ����ġ�� ��ø�Ǿ� ������
    private void CalculateWeightsAndIndices()
    {
        for (int i = 0; i <roulettePieceData.Length; i++)
        {
            roulettePieceData[i].index = i;

            //����ó��, Ȥ�ö� chance���� 0 ������ ��� 1�� ����
            if (roulettePieceData[i].chance <= 0)
            {
                roulettePieceData[i].chance = 1;
            }

            accumlatedWeight += roulettePieceData[i].chance;
            roulettePieceData[i].weight = accumlatedWeight;

            Debug.Log($"({roulettePieceData[i].index}){roulettePieceData[i].description}:{roulettePieceData[i].weight}");
        }


    }

    // ����ġ�� ���� �������� �������� Select�� �Լ�
    private int GetRandomIndex()
    {
        int weight = Random.Range(0, accumlatedWeight);

        for (int i = 0; i < roulettePieceData.Length; i++)
        {
            if (roulettePieceData[i].weight > weight)
            {
                return i;
            }
        }

        return 0;
    }

    //Spin 
    public void Spin(UnityAction<RoulettePieceData> action = null)
    {
        if (isSpinning == true) return;

        //�귿 ��� �� ����
        selectedIndex = GetRandomIndex();
        //���õ� ����� �߽� ����
        float angle = pieceAngle * selectedIndex;
        // ��Ȯ�� �߽��� �ƴ� ��� �� ���� ���� ������ ���� ����
        float leftOffset = (angle - halfPieceAngleWithPaddings) % 360;
        float rightOffset = (angle - halfPieceAngleWithPaddings) % 360;
        float randomAngle = Random.RandomRange(leftOffset, rightOffset);

        //��ǥ ���� (target Angle) = ������� + 360 * ȸ�� �ð� * ȸ�� �ӵ�
        int rotateSpeed = 2;
        float targetAngle = (randomAngle + 360 * spinDuration * rotateSpeed);

        isSpinning = true;
        StartCoroutine(OnSpin(targetAngle, action));
    }

    private IEnumerator OnSpin (float end, UnityAction<RoulettePieceData> action)
    {
        float current = 0;
        float percent = 0;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / spinDuration;

            float z = Mathf.Lerp(0, end, spinningCurve.Evaluate(percent));
            spinningRoulette.rotation = Quaternion.Euler(0, 0, z);

            yield return null;
        }

        isSpinning = false;

        if (action != null) action.Invoke(roulettePieceData[selectedIndex]);
    }
}
