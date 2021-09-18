//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class TowerRight : MonoBehaviour
{
    public GameManager gm;
    public TowerLeft left;
    public TowerMid mid;
    public Color originRightColor;

    private void OnMouseDown()
    {
        //아무것도 선택 안되어있을 때.
        if (!gm.isCurrentCheck)
        {
            if (gm.stackRight.Count >= 1)
            {
                gm.isRightCheck = true;
                gm.isCurrentCheck = true;
                originRightColor = gm.boardCube[gm.stackRight.Peek() - 1].GetComponent<Renderer>().material.color;
                gm.boardCube[gm.stackRight.Peek() - 1].GetComponent<Renderer>().material.color = Color.gray;
            }
            else if (gm.stackRight.Count < 1)
            {
                //탑이 비어있다는 메시지
                gm.StartCoroutine("EmptyError");
            }
        }
        //자기 자신을 다시 선택했을 때.
        else if (gm.isCurrentCheck && gm.isRightCheck)
        {
            gm.isRightCheck = false;
            gm.isCurrentCheck = false;
            gm.boardCube[gm.stackRight.Peek() - 1].GetComponent<Renderer>().material.color = originRightColor;
        }
        //다른 탑에서 오른쪽 탑으로 가져올 때.
        else if (gm.isCurrentCheck && !gm.isRightCheck)
        {
            //왼쪽 탑에서 가져올 때.
            if (gm.isLeftCheck)
            {
                //왼쪽 탑이 비어있지 않으면 실행.
                if (gm.stackLeft.Count >= 1)
                {
                    //오른쪽 탑이 비어있으면 그냥 가져옴.
                    if (gm.stackRight.Count == 0)
                    {
                        gm.boardCube[gm.stackLeft.Peek() - 1].transform.position = new Vector3(10f, 4.5f, 0);
                        gm.stackRight.Push(gm.stackLeft.Pop());
                        gm.boardCube[gm.stackRight.Peek() - 1].GetComponent<Renderer>().material.color = left.originLeftColor;
                    }
                    //오른쪽 탑이 무언가 차 있으면 실행.
                    else if (gm.stackRight.Count != 0)
                    {
                        //오른쪽 탑의 끝 원판보다 작은 원판이 들어오면 그냥 가져옴.
                        if (gm.stackRight.Peek() > gm.stackLeft.Peek())
                        {
                            gm.boardCube[gm.stackLeft.Peek() - 1].transform.position = new Vector3(10f, 4.5f, 0);
                            gm.stackRight.Push(gm.stackLeft.Pop());
                            gm.boardCube[gm.stackRight.Peek() - 1].GetComponent<Renderer>().material.color = left.originLeftColor;
                        }
                        //더 큰 원판이 들어오면 예외처리.
                        else if (gm.stackRight.Peek() < gm.stackLeft.Peek())
                        {
                            gm.boardCube[gm.stackLeft.Peek() - 1].GetComponent<Renderer>().material.color = left.originLeftColor;
                            gm.StartCoroutine("OverflowError");
                        }
                    }
                }
                //왼쪽 탑이 비어 있으면 예외처리.
                else if (gm.stackLeft.Count < 1)
                {
                    gm.StartCoroutine("EmptyError");
                }
            }

            //중앙 탑에서 가져올 때.
            if (gm.isMidCheck)
            {
                //중앙 탑이 비어있지 않으면 실행.
                if (gm.stackMid.Count >= 1)
                {
                    //오른쪽 탑이 비어있으면 그냥 가져옴.
                    if (gm.stackRight.Count == 0)
                    {
                        gm.boardCube[gm.stackMid.Peek() - 1].transform.position = new Vector3(10f, 4.5f, 0);
                        gm.stackRight.Push(gm.stackMid.Pop());
                        gm.boardCube[gm.stackRight.Peek() - 1].GetComponent<Renderer>().material.color = mid.originMidColor;
                    }
                    //오른쪽 탑이 무언가 차 있으면 실행.
                    else if (gm.stackRight.Count != 0)
                    {
                        // 탑의 끝 원판보다 작은 원판이 들어오면 그냥 가져옴.
                        if (gm.stackRight.Peek() > gm.stackMid.Peek())
                        {
                            gm.boardCube[gm.stackMid.Peek() - 1].transform.position = new Vector3(10f, 4.5f, 0);
                            gm.stackRight.Push(gm.stackMid.Pop());
                            gm.boardCube[gm.stackRight.Peek() - 1].GetComponent<Renderer>().material.color = mid.originMidColor;
                        }
                        //더 큰 원판이 들어오면 예외처리.
                        else if (gm.stackRight.Peek() < gm.stackMid.Peek())
                        {
                            gm.boardCube[gm.stackMid.Peek() - 1].GetComponent<Renderer>().material.color = mid.originMidColor;
                            gm.StartCoroutine("OverflowError");
                        }
                    }
                }
                //중앙 탑이 비어 있으면 예외처리.
                else if (gm.stackMid.Count < 1)
                {
                    gm.StartCoroutine("EmptyError");
                }
            }

            gm.isCurrentCheck = false;
            gm.isLeftCheck = false;
            gm.isMidCheck = false;
            gm.isRightCheck = false;
        }
    }
}
