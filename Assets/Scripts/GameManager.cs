using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private RobotController robot;
    [SerializeField] private Timer timer;
    [SerializeField] private int arraySortSize = 10;
    [SerializeField] private int minimumValue = 0;
    [SerializeField] private int maximumValue = 100;
    [SerializeField] private GameObject spherePrefab;
    [SerializeField] private int spherInPooler = 20;
    [SerializeField] private GameObject platform;
    [SerializeField] private float ballOffset = 0.5f;

    private int[] _arrayOfNumber;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _arrayOfNumber = GenerateArray(arraySortSize, minimumValue, maximumValue);
        ObjectPooler.instance.CreateObjects(spherePrefab, spherInPooler);
        PreperScene();
    }

    public int[] GetArrayOfNumber() { return _arrayOfNumber; }
    public RobotController GetRobot() { return robot; }
    public Timer GetTimer() { return timer; }

    private void PreperScene()
    {
        GameObject newObject;
        float positionX = 0 - (arraySortSize / 2);
        platform.transform.localScale = new Vector3(arraySortSize, platform.transform.localScale.y, platform.transform.localScale.z);
        for (int i = 0; i < arraySortSize; i++)
        {
            newObject = ObjectPooler.instance.GetObject(spherePrefab);
            newObject.transform.position = new Vector3(positionX + ballOffset + i, 1, 0);
            newObject.GetComponent<BallController>().text.text = _arrayOfNumber[i].ToString();
        }
        robot.PrepareRobot(arraySortSize);
    }

    private int[] GenerateArray(int length, int minValue, int maxValue)
    {
        List<int> tmp = new List<int>();

        for (int i = 0; i < length; i++)
        {
            tmp.Add(UnityEngine.Random.Range(minValue, maxValue));
        }

        return tmp.ToArray();
    }
}
