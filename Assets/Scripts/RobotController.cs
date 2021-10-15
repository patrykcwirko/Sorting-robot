using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    [SerializeField] private float movePerFrame = 0.01f;

    private int _ballCount;
    private int _currentPosition;

    public void PrepareRobot(int ballCount)
    {
        _ballCount = ballCount;
        _currentPosition = ballCount / 2;
    }

    public IEnumerator SwapBall(int firstPosition, int secondPosition)
    {
        if(Mathf.Abs( _currentPosition - firstPosition) > Mathf.Abs(_currentPosition - secondPosition))
        {
            yield return MoveRobot(secondPosition);
            GrabBall();
            yield return MoveRobot(firstPosition);
            GrabBall();
            PutBall();
            yield return MoveRobot(secondPosition);
            PutBall();
        }else
        {
            yield return MoveRobot(firstPosition);
            GrabBall();
            yield return MoveRobot(secondPosition);
            GrabBall();
            PutBall();
            yield return MoveRobot(firstPosition);
            PutBall();
        }
    }

    private IEnumerator MoveRobot(int newPoint)
    {
        Vector3 newPosition = new Vector3(newPoint - .5f - _ballCount/2, transform.position.y, transform.position.z);
        while (Vector3.Distance(transform.position, newPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, movePerFrame);
            yield return new WaitForFixedUpdate();
        }
    }

    private void GrabBall()
    {

    }

    private void PutBall()
    {

    }

}
