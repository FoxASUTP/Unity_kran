using UnityEngine;
using Cinemachine; // подключаем библиотеку синимашин

public class chengCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] GameObjects;// массив виртуальных камер
    private int currentCameraIndex;  // число
    public float timerValue = 90;
    private int index;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     

    }
    public void CameraInRight()
    {

        for (int i = 0; i <= GameObjects.Length-1; i++) 
        {
            if (GameObjects[i].active == true) // ищем первую активную каменру
            {
                currentCameraIndex = i;
                index = i+1; // определяем индекс следующей камеры 
                break;
            }
        }

            foreach (var obj in GameObjects)
            {
                obj.SetActive(false); // выключаем все камеры
            }

            if (index == GameObjects.Length) // если дошли до последнего элемента то переключаем в начала массива
            {
                index = 0;
            }
            GameObjects[index].SetActive(true);
        
    }
    
    public void CameraInLeft()
    {
        for (int i = 0; i <= GameObjects.Length - 1; i++)
        {
            if (GameObjects[i].active == true) // ищем первую активную каменру
            {
                currentCameraIndex = i;
                index = i - 1; // определяем индекс следующей камеры 
                break;
            }
        }

        foreach (var obj in GameObjects)
        {
            obj.SetActive(false); // выключаем все камеры
        }

        if (index < 0) 
        {
            index = GameObjects.Length-1; // если дошли до последнего элемента то переключаем в начала массива
        }
        GameObjects[index].SetActive(true);
    }
}
