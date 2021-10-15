using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{

    enum ActionType
    { 
        Grab,
        Put,
        GrabPut
    }

    [SerializeField] private Transform leftHand;
    [SerializeField] private Transform rightHand;
    [SerializeField] private GameObject pooler;
    [SerializeField] private float movePerFrame = 0.01f;

    private int _ballCount;
    private int _currentPosition;
    private bool _leftHandFull = false;

    public void PrepareRobot(int ballCount)
    {
        _ballCount = ballCount;
        _currentPosition = ballCount / 2;
    }

    public IEnumerator SwapBall(int firstPosition, int secondPosition)
    {
        int firstNumber = GameManager.instance.GetArrayOfNumber()[firstPosition];
        int secondNumber = GameManager.instance.GetArrayOfNumber()[secondPosition];
        Debug.Log($"first: {firstNumber}, second: {secondNumber}");
        if (Mathf.Abs(_currentPosition - firstPosition) > Mathf.Abs(_currentPosition - secondPosition))
        {
            yield return MoveRobot(secondPosition, firstPosition, ActionType.Grab);

            yield return MoveRobot(firstPosition, secondPosition, ActionType.GrabPut);

            yield return MoveRobot(secondPosition, secondPosition, ActionType.Put);

        }
        else
        {
            yield return MoveRobot(firstPosition, secondPosition, ActionType.Grab);

            yield return MoveRobot(secondPosition, firstPosition, ActionType.GrabPut);

            yield return MoveRobot(firstPosition, firstPosition, ActionType.Put);
        }
    }

    private IEnumerator MoveRobot(int newPoint, int secondBall, ActionType action)
    {
        Vector3 newPosition = new Vector3(newPoint - .5f - _ballCount/2, transform.position.y, transform.position.z);
        while (Vector3.Distance(transform.position, newPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, movePerFrame);
            yield return new WaitForFixedUpdate();
        }
        switch (action)
        {
            case ActionType.Grab:
                GrabBall(newPoint);
                break;
            case ActionType.Put:
                PutBall(secondBall, newPoint);
                break;
            case ActionType.GrabPut:
                GrabBall(newPoint);
                PutBall(secondBall, newPoint);
                break;
        }
    }

    private void GrabBall(int position)
    {
        string number = GameManager.instance.GetObjectList()[position].GetComponent<BallController>().text.text;
        Debug.Log(number);
        if (_leftHandFull)
        {
            GameManager.instance.GetObjectList()[position].transform.parent = rightHand.transform;
        }
        else
        {
            GameManager.instance.GetObjectList()[position].transform.parent = leftHand.transform;
            _leftHandFull = true;
        }
    }

    private void PutBall(int ball, int position)
    {
        if (_leftHandFull) _leftHandFull = false;
        GameManager.instance.GetObjectList()[ball].transform.parent = pooler.transform;
        GameManager.instance.GetObjectList()[ball].transform.position = new Vector3(position + .5f - _ballCount / 2, 1, 0);
        swap(GameManager.instance.GetObjectList(), ball, position);
    }

    private void swap(List<GameObject> data, int m, int n)
    {
        GameObject tmp;

        tmp = data[m];
        data[m] = data[n];
        data[n] = tmp;
    }

}
