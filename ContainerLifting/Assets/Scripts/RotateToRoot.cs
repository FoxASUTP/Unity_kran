using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

public class RotateToRoot : MonoBehaviour
{

    //���� Root ��������� �� ������ ���������
    public GameObject Root;
    [SerializeField] float Speed=5;
    private float PosAfte, PosBefo;  
    
    // Start is called before the first frame update
    void Start()
    {
      PosBefo=Root.GetComponent<Transform>().position.z;
        
        if (Root == null)  // ���� ���� ������
        {
            Debug.Log("��� ������");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (Root.GetComponent<Transform>() != null)  // ���� ���� ������
        {
            PosAfte= Root.GetComponent<Transform>().position.z;               // ������� ����� �����������
            if (PosBefo>PosAfte)
            {
            transform.Rotate(.0f, -Speed, 0, Space.Self);                    // �������� � ���� �������
            }
            if (PosBefo < PosAfte)
            {
            transform.Rotate(.0f, Speed, 0, Space.Self);                    //  �������� � ������ �������
            }
            PosBefo = Root.GetComponent<Transform>().position.z;           // ������� �� �������������
        }

    }
}
