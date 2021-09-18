//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class TowerLeft : MonoBehaviour
{
    public GameManager gm;
    public TowerMid mid;
    public TowerRight right;
    public Color originLeftColor;

    private void OnMouseDown()
    {
        //�ƹ��͵� ���� �ȵǾ����� ��.
        if (!gm.isCurrentCheck)
        {
            if (gm.stackLeft.Count >= 1)
            {
                gm.isLeftCheck = true;
                gm.isCurrentCheck = true;
                originLeftColor = gm.boardCube[gm.stackLeft.Peek() - 1].GetComponent<Renderer>().material.color;
                gm.boardCube[gm.stackLeft.Peek() - 1].GetComponent<Renderer>().material.color = Color.gray;
            }
            else if (gm.stackLeft.Count < 1)
            {
                //ž�� ����ִٴ� �޽���
                gm.StartCoroutine("EmptyError");
            }
        }
        //�ڱ� �ڽ��� �ٽ� �������� ��.
        else if (gm.isCurrentCheck && gm.isLeftCheck)
        {
            gm.isLeftCheck = false;
            gm.isCurrentCheck = false;
            gm.boardCube[gm.stackLeft.Peek() - 1].GetComponent<Renderer>().material.color = originLeftColor;
        }
        //�ٸ� ž���� ���� ž���� ������ ��.
        else if (gm.isCurrentCheck && !gm.isLeftCheck)
        {
            //�߰� ž���� ������ ��.
            if (gm.isMidCheck)
            {
                //�߰� ž�� ������� ������ ����.
                if (gm.stackMid.Count >= 1)
                {
                    //���� ž�� ��������� �׳� ������.
                    if (gm.stackLeft.Count == 0)
                    {
                        gm.boardCube[gm.stackMid.Peek() - 1].transform.position = new Vector3(-10f, 4.5f, 0);
                        gm.stackLeft.Push(gm.stackMid.Pop());
                        gm.boardCube[gm.stackLeft.Peek() - 1].GetComponent<Renderer>().material.color = mid.originMidColor;
                    }
                    //���� ž�� ���� �� ������ ����.
                    else if (gm.stackLeft.Count != 0)
                    {
                        //���� ž�� �� ���Ǻ��� ���� ������ ������ �׳� ������.
                        if (gm.stackLeft.Peek() > gm.stackMid.Peek())
                        {
                            gm.boardCube[gm.stackMid.Peek() - 1].transform.position = new Vector3(-10f, 4.5f, 0);
                            gm.stackLeft.Push(gm.stackMid.Pop());
                            gm.boardCube[gm.stackLeft.Peek() - 1].GetComponent<Renderer>().material.color = mid.originMidColor;
                        }
                        //�� ū ������ ������ ����ó��.
                        else if (gm.stackLeft.Peek() < gm.stackMid.Peek())
                        {
                            gm.boardCube[gm.stackMid.Peek() - 1].GetComponent<Renderer>().material.color = mid.originMidColor;
                            gm.StartCoroutine("OverflowError");
                        }
                    }
                }
                //�߰� ž�� ��� ������ ����ó��.
                else if (gm.stackMid.Count < 1)
                {
                    gm.StartCoroutine("EmptyError");
                }
            }

            //������ ž���� ������ ��.
            if (gm.isRightCheck)
            {
                //������ ž�� ������� ������ ����.
                if (gm.stackRight.Count >= 1)
                {
                    //���� ž�� ��������� �׳� ������.
                    if (gm.stackLeft.Count == 0)
                    {
                        gm.boardCube[gm.stackRight.Peek() - 1].transform.position = new Vector3(-10f, 4.5f, 0);
                        gm.stackLeft.Push(gm.stackRight.Pop());
                        gm.boardCube[gm.stackLeft.Peek() - 1].GetComponent<Renderer>().material.color = right.originRightColor;
                    }
                    //���� ž�� ���� �� ������ ����.
                    else if (gm.stackLeft.Count != 0)
                    {
                        //���� ž�� �� ���Ǻ��� ���� ������ ������ �׳� ������.
                        if (gm.stackLeft.Peek() > gm.stackRight.Peek())
                        {
                            gm.boardCube[gm.stackRight.Peek() - 1].transform.position = new Vector3(-10f, 4.5f, 0);
                            gm.stackLeft.Push(gm.stackRight.Pop());
                            gm.boardCube[gm.stackLeft.Peek() - 1].GetComponent<Renderer>().material.color = right.originRightColor;
                        }
                        //�� ū ������ ������ ����ó��.
                        else if (gm.stackLeft.Peek() < gm.stackRight.Peek())
                        {
                            gm.boardCube[gm.stackRight.Peek() - 1].GetComponent<Renderer>().material.color = right.originRightColor;
                            gm.StartCoroutine("OverflowError");
                        }
                    }
                }
                //������ ž�� ��� ������ ����ó��.
                else if (gm.stackRight.Count < 1)
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
