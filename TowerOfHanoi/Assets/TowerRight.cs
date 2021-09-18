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
        //�ƹ��͵� ���� �ȵǾ����� ��.
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
                //ž�� ����ִٴ� �޽���
                gm.StartCoroutine("EmptyError");
            }
        }
        //�ڱ� �ڽ��� �ٽ� �������� ��.
        else if (gm.isCurrentCheck && gm.isRightCheck)
        {
            gm.isRightCheck = false;
            gm.isCurrentCheck = false;
            gm.boardCube[gm.stackRight.Peek() - 1].GetComponent<Renderer>().material.color = originRightColor;
        }
        //�ٸ� ž���� ������ ž���� ������ ��.
        else if (gm.isCurrentCheck && !gm.isRightCheck)
        {
            //���� ž���� ������ ��.
            if (gm.isLeftCheck)
            {
                //���� ž�� ������� ������ ����.
                if (gm.stackLeft.Count >= 1)
                {
                    //������ ž�� ��������� �׳� ������.
                    if (gm.stackRight.Count == 0)
                    {
                        gm.boardCube[gm.stackLeft.Peek() - 1].transform.position = new Vector3(10f, 4.5f, 0);
                        gm.stackRight.Push(gm.stackLeft.Pop());
                        gm.boardCube[gm.stackRight.Peek() - 1].GetComponent<Renderer>().material.color = left.originLeftColor;
                    }
                    //������ ž�� ���� �� ������ ����.
                    else if (gm.stackRight.Count != 0)
                    {
                        //������ ž�� �� ���Ǻ��� ���� ������ ������ �׳� ������.
                        if (gm.stackRight.Peek() > gm.stackLeft.Peek())
                        {
                            gm.boardCube[gm.stackLeft.Peek() - 1].transform.position = new Vector3(10f, 4.5f, 0);
                            gm.stackRight.Push(gm.stackLeft.Pop());
                            gm.boardCube[gm.stackRight.Peek() - 1].GetComponent<Renderer>().material.color = left.originLeftColor;
                        }
                        //�� ū ������ ������ ����ó��.
                        else if (gm.stackRight.Peek() < gm.stackLeft.Peek())
                        {
                            gm.boardCube[gm.stackLeft.Peek() - 1].GetComponent<Renderer>().material.color = left.originLeftColor;
                            gm.StartCoroutine("OverflowError");
                        }
                    }
                }
                //���� ž�� ��� ������ ����ó��.
                else if (gm.stackLeft.Count < 1)
                {
                    gm.StartCoroutine("EmptyError");
                }
            }

            //�߾� ž���� ������ ��.
            if (gm.isMidCheck)
            {
                //�߾� ž�� ������� ������ ����.
                if (gm.stackMid.Count >= 1)
                {
                    //������ ž�� ��������� �׳� ������.
                    if (gm.stackRight.Count == 0)
                    {
                        gm.boardCube[gm.stackMid.Peek() - 1].transform.position = new Vector3(10f, 4.5f, 0);
                        gm.stackRight.Push(gm.stackMid.Pop());
                        gm.boardCube[gm.stackRight.Peek() - 1].GetComponent<Renderer>().material.color = mid.originMidColor;
                    }
                    //������ ž�� ���� �� ������ ����.
                    else if (gm.stackRight.Count != 0)
                    {
                        // ž�� �� ���Ǻ��� ���� ������ ������ �׳� ������.
                        if (gm.stackRight.Peek() > gm.stackMid.Peek())
                        {
                            gm.boardCube[gm.stackMid.Peek() - 1].transform.position = new Vector3(10f, 4.5f, 0);
                            gm.stackRight.Push(gm.stackMid.Pop());
                            gm.boardCube[gm.stackRight.Peek() - 1].GetComponent<Renderer>().material.color = mid.originMidColor;
                        }
                        //�� ū ������ ������ ����ó��.
                        else if (gm.stackRight.Peek() < gm.stackMid.Peek())
                        {
                            gm.boardCube[gm.stackMid.Peek() - 1].GetComponent<Renderer>().material.color = mid.originMidColor;
                            gm.StartCoroutine("OverflowError");
                        }
                    }
                }
                //�߾� ž�� ��� ������ ����ó��.
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
