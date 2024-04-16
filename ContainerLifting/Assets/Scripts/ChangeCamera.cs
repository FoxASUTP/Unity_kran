using UnityEngine;
using Cinemachine; // ���������� ���������� ���������

public class chengCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] GameObjects;// ������ ����������� �����
    private int currentCameraIndex;  // �����
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
            if (GameObjects[i].active == true) // ���� ������ �������� �������
            {
                currentCameraIndex = i;
                index = i+1; // ���������� ������ ��������� ������ 
                break;
            }
        }

            foreach (var obj in GameObjects)
            {
                obj.SetActive(false); // ��������� ��� ������
            }

            if (index == GameObjects.Length) // ���� ����� �� ���������� �������� �� ����������� � ������ �������
            {
                index = 0;
            }
            GameObjects[index].SetActive(true);
        
    }
    
    public void CameraInLeft()
    {
        for (int i = 0; i <= GameObjects.Length - 1; i++)
        {
            if (GameObjects[i].active == true) // ���� ������ �������� �������
            {
                currentCameraIndex = i;
                index = i - 1; // ���������� ������ ��������� ������ 
                break;
            }
        }

        foreach (var obj in GameObjects)
        {
            obj.SetActive(false); // ��������� ��� ������
        }

        if (index < 0) 
        {
            index = GameObjects.Length-1; // ���� ����� �� ���������� �������� �� ����������� � ������ �������
        }
        GameObjects[index].SetActive(true);
    }
}
