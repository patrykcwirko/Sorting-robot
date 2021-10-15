using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Component")]
    [SerializeField] private ObjectPooler pooler;
    [SerializeField] private RobotController robot;
    [SerializeField] private Timer timer;
    [SerializeField] private SortingMenager sortingMenager;
    [SerializeField] private GameObject option;

    [Header("Sorting variable")]
    public AlgorithmData algorithData;
    [SerializeField] private int minimumValue = 0;
    [SerializeField] private int maximumValue = 100;
    [SerializeField] private GameObject spherePrefab;
    [SerializeField] private GameObject platform;

    private int[] _arrayOfNumber;
    private List<GameObject> _gameObjectsList;
    private bool _prepared = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        pooler.CreateObjects(spherePrefab, algorithData.ballAmount);
        PreperScene();
    }

    public int[] GetArrayOfNumber() { return _arrayOfNumber; }
    public List<GameObject> GetObjectList() { return _gameObjectsList; }
    public RobotController GetRobot() { return robot; }
    public Timer GetTimer() { return timer; }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    public void AddSortStep()
    {
        sortingMenager.AddStep();
    }

    public void OpenMenu()
    {
        option.SetActive(true);
    }
    
    public void CloseMenu()
    {
        option.SetActive(false);
    }

    public void PreperScene()
    {
        GameObject newObject;
        _gameObjectsList = new List<GameObject>();
        _arrayOfNumber = GenerateArray(algorithData.ballAmount, minimumValue, maximumValue);
        float positionX = 0 - (algorithData.ballAmount / 2);
        platform.transform.localScale = new Vector3(algorithData.ballAmount, platform.transform.localScale.y, platform.transform.localScale.z);
        if(_prepared)
        {
            for (int i = 0; i < algorithData.ballAmount; i++)
            {
                pooler.ReturnGameObject(spherePrefab);
            }
        }
        for (int i = 0; i < algorithData.ballAmount; i++)
        {
            newObject = pooler.GetObject(spherePrefab);
            Debug.Log(newObject.transform.position);
            newObject.transform.position = new Vector3(positionX + .5f + i, 1, 0);
            newObject.GetComponent<BallController>().text.text = _arrayOfNumber[i].ToString();
            _gameObjectsList.Add(newObject);
        }
        robot.PrepareRobot(algorithData.ballAmount);
        _prepared = true;
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
