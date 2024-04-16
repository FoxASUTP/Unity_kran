using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

public class RotateToRoot : MonoBehaviour
{

    //если Root двигаетс€ то обьект крутитьс€
    public GameObject Root;
    [SerializeField] float Speed=5;
    private float PosAfte, PosBefo;  
    
    // Start is called before the first frame update
    void Start()
    {
      PosBefo=Root.GetComponent<Transform>().position.z;
        
        if (Root == null)  // если есть обьект
        {
            Debug.Log("Ќет ссылки");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
       if (Root.GetComponent<Transform>() != null)  // если есть обьект
        {
            PosAfte= Root.GetComponent<Transform>().position.z;               // позици€ после перемещени€
            if (PosBefo>PosAfte)
            {
            transform.Rotate(.0f, -Speed, 0, Space.Self);                    // вращение в одну сторону
            }
            if (PosBefo < PosAfte)
            {
            transform.Rotate(.0f, Speed, 0, Space.Self);                    //  вращение в другую сторону
            }
            PosBefo = Root.GetComponent<Transform>().position.z;           // позици€ до переремещени€
        }

    }
}
