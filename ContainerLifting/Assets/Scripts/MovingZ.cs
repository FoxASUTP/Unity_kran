using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovingZ : MonoBehaviour
{

    public float speed = 5.00f;

    private int pressed = 0;
    private float possition;
    public bool permisMin = true;
    public bool permisMax = true;


    public float posMin;
    public float posMax;


    void Update()
    {
        CheckPos(posMin, posMax, possition);  // �������� �������


        possition = transform.position.z;  // �������� �������



        switch (pressed)
        {
            case 1:
                if (!permisMax) break;
                Fwd();
                break;
            case 2:
                if (!permisMin) break;
                Bkd();
                break;
            case 0:
                break;
        }

    }
    public void PressFwd()
    {
        pressed = 1;
    }
    public void PressBkw()
    {
        pressed = 2;
    }
    public void Spare()
    {
        pressed = 0;
    }

    private void Fwd()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void Bkd()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
    private void CheckPos(float min, float max, float poss)
    {
        // �������� ���������
        if (poss >= max)
        {
            //Debug.Log("���������� ������������ �������"+poss+"  "+max);
            permisMax = false;
        }
        else
        {
            permisMax = true;
        }
        //�������� ��������   
        if (poss <= min)
        {
            //Debug.Log("���������� ����������� �������");
            permisMin = false;
        }
        else
        {
            permisMin = true;
        }
    }
}
