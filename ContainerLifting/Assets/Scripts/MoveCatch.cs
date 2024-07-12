using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UIElements;
using static Cinemachine.AxisState;
using Vector3 = UnityEngine.Vector3;

public class MoveCatch : MonoBehaviour
{
    public float speed = 5.00f;

    public bool state = false;

    public GameObject Obj;

    private Vector3 vector3;
    private bool stopMove=false;

    public int vector1,vector2;

    public int m_threshold = 1;

    public GameObject m_target;
    public GameObject base_target;

    private GameObject m_zahvacheniyObgect;


    public BtnCatch BtnCatch;

    public string Tag = "Items";

    void Update()
    {

    }

    public void Move()
    {
        //state = !state;
        StartCoroutine(Corutin());
    }
    IEnumerator Corutin()// �������� ������  � ������ ������� 
    {
        print("�����");

        if (!state)
        {
            while (!state)
            {
                Obj.transform.Translate(new Vector3(vector1, 0) * speed * Time.deltaTime);

                //float distance1=GetDistance(Obj.transform.position,m_target.transform.position);

                //Obj.transform.Translate(new Vector3(k,0) * speed * Time.deltaTime);

                print("�������  ������ = " + Obj.name + " " + Obj.transform.position.x);
                if ((GetDistance(Obj.transform.position, m_target.transform.position) < m_threshold)|| stopMove)
                {
                    print("��������");
                    state = true;
                    stopMove = false;
                    break;
                }
                
                yield return null;
            }
        } else
        {
            while (state)
            {
                Obj.transform.Translate(new Vector3(vector2, 0) * speed * Time.deltaTime);
                gameObject.transform.DetachChildren();
                //float distance1=GetDistance(Obj.transform.position,m_target.transform.position);

                //Obj.transform.Translate(new Vector3(k,0) * speed * Time.deltaTime);

                //Debug.Log("�������  ����� = " + Obj.name + " " + Obj.transform.position.x);
                
                if (GetDistance(Obj.transform.position, base_target.transform.position) < m_threshold)
                {
                   // Debug.Log("���������");
                    //Debug.Log(GetDistance(Obj.transform.position, base_target.transform.position));
                    state = false;
                    break;
                }
                yield return null;
            }
        }
    }

    private void OnEnable()// �������� �� ������� ������
    {
        if (BtnCatch != null)
        {
            BtnCatch.clickCatch += Move;
        }
        else
        {
            //("Opps,no attach", this);
        }
    }
    private void OnDisable()
    {
        if (BtnCatch != null)
        {
            BtnCatch.clickCatch -= Move;
        }
        else
        {
            //Debug.Log("Opps,no attach", this);
        }
    }
    
    //����� ���������� ��������� ����� ����� �������
    float GetDistance(Vector3 _point1, Vector3 _poin2)
    {

        return Vector3.Distance(_point1, _poin2);
    }
    private void OnCollisionEnter(Collision collision) // ����� ����������� ��������
    {
        print(collision.gameObject.name);
        if (collision.gameObject.CompareTag(Tag))
        {
            stopMove = true; // ���� ����������� � �������� ���� Items �� ������������� ������ � ��������
            collision.transform.SetParent(gameObject.transform);
            collision.rigidbody.useGravity = false;
            m_zahvacheniyObgect = collision.gameObject;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.CompareTag(Tag))
        {
            collision.rigidbody.useGravity = true;
            collision.transform.DetachChildren();
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        
    }
}
