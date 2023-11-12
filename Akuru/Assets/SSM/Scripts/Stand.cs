using UnityEngine;


public class Stand : MonoBehaviour
{

    [SerializeField] private Vector3 leftBias = new Vector3(-0.5f, 0, 0);
    Vector3 rightBias = new Vector3(0.5f, 0, 0);

    public int SpawnTanghuluGameObjects(GameObject tanghuluObject, int count)
    {
        int countNotInstaintiated = count;
        for (int i = 0; i < count; i++)
        {
            var tobj = Instantiate(tanghuluObject);
            SetTanghuluPosition(this, tobj.transform, i);
            countNotInstaintiated--;
        }

        return countNotInstaintiated;
    }

    public void SetTanghuluPosition(Stand standTr, Transform tanghuluTr, int index)
    {
        if (index == 1)
        {
            tanghuluTr.position = standTr.transform.position + leftBias;
        }
        else if (index == 2)
        {
            tanghuluTr.position = standTr.transform.position + rightBias;
        }
        else if (index == 3)
        {
            tanghuluTr.position = standTr.transform.position;
        }
    }
}