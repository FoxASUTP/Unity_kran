using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using static Cinemachine.AxisState;
using Vector3 = UnityEngine.Vector3;

public class MoveCatch : MonoBehaviour
{
    public float speed = 5.00f;

    public bool state = false;
    private float possition;
    public bool permisMin = true;
    public bool permisMax = true;
    public GameObject Obj;
    public Vector3 vector3;

    public float posMin;
    public float posMax;

    public BtnCatch BtnCatch;
    void Update()
    {
        //CheckPos(posMin, posMax, possition);  // проверка позиции
        //possition = Obj.transform.position.x;  // получаем позицию

    }
    public void Move()
    {
        state = !state;
        StartCoroutine(Corutin());
    }
    IEnumerator Corutin()// корутина крутим  и меняем позицию 
    {
        Debug.Log("Нажта");
        {

           if (!state) 
            {
                while (!state)
                {
                    Obj.transform.Translate(Vector3.right * speed * Time.deltaTime);
                    Debug.Log("позиция  в право = " + Obj.name + " " + Obj.transform.position.x);
                    if (Obj.transform.position.x >= posMax)
                    {
                        state = false;
                        break;
                    }
                    yield return null;
                }
            }
                
            if (state)
            {
                while (state)
                {
                    Obj.transform.Translate(Vector3.left * speed * Time.deltaTime);
                    Debug.Log("позиция в лево = " + Obj.name + " " + Obj.transform.position.x);
                    if (Obj.transform.position.x <= posMin)
                    {
                        state = true;
                        break;
                    }
                    yield return null;
                }
            }
        }
    }


    private void CheckPos(float min, float max, float poss)
    {
        // проверка Максимума
        if (poss >= max)
        {
            //Debug.Log("Достигнута максимальная позиция"+poss+"  "+max);
            permisMax = false;
        }
        else
        {
            permisMax = true;
        }
        //проверка Минимума   
        if (poss <= min)
        {
            //Debug.Log("Достигнута минимальная позиция");
            permisMin = false;
        }
        else
        {
            permisMin = true;
        }
    }


    private void OnEnable()// подписка на нажатие кнопки
    {
        if (BtnCatch != null)
        {
            BtnCatch.clickCatch += Move;
        }
        else
        {
            Debug.Log("Opps,no attach", this);
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
            Debug.Log("Opps,no attach", this);
        }
    }
}
