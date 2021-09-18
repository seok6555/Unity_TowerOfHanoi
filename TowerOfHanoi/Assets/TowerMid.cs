//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class TowerMid : MonoBehaviour
{
    public GameManager gm;
    public TowerLeft left;
    public TowerRight right;
    public Color originMidColor;

    private void OnMouseDown()
    {
        //�ƹ��͵� ���� �ȵǾ����� ��.
        if (!gm.isCurrentCheck)
        {
            if (gm.stackMid.Count >= 1)
            {
                gm.isMidCheck = true;
                gm.isCurrentCheck = true;
                originMidColor = gm.boardCube[gm.stackMid.Peek() - 1].GetComponent<Renderer>().material.color;
                gm.boardCube[gm.stackMid.Peek() - 1].GetComponent<Renderer>().material.color = Color.gray;
            }
            else if (gm.stackMid.Count < 1)
            {
                //ž�� ����ִٴ� �޽���
                gm.StartCoroutine("EmptyError");
            }
        }
        //�ڱ� �ڽ��� �ٽ� �������� ��.
        else if (gm.isCurrentCheck && gm.isMidCheck)
        {
            gm.isMidCheck = false;
            gm.isCurrentCheck = false;
            gm.boardCube[gm.stackMid.Peek() - 1].GetComponent<Renderer>().material.color = originMidColor;
        }
        //�ٸ� ž���� �߰� ž���� ������ ��.
        else if (gm.isCurrentCheck && !gm.isMidCheck)
        {
            //���� ž���� ������ ��.
            if (gm.isLeftCheck)
            {
                //���� ž�� ������� ������ ����.
                if (gm.stackLeft.Count >= 1)
                {
                    //�߰� ž�� ��������� �׳� ������.
                    if (gm.stackMid.Count == 0)
                    {
                        gm.boardCube[gm.stackLeft.Peek() - 1].transform.position = new Vector3(0, 4.5f, 0);
                        gm.stackMid.Push(gm.stackLeft.Pop());
                        gm.boardCube[gm.stackMid.Peek() - 1].GetComponent<Renderer>().material.color = left.originLeftColor;
                    }
                    //�߰� ž�� ���� �� ������ ����.
                    else if (gm.stackMid.Count != 0)
                    {
                        //�߰� ž�� �� ���Ǻ��� ���� ������ ������ �׳� ������.
                        if (gm.stackMid.Peek() > gm.stackLeft.Peek())
                        {
                            gm.boardCube[gm.stackLeft.Peek() - 1].transform.position = new Vector3(0, 4.5f, 0);
                            gm.stackMid.Push(gm.stackLeft.Pop());
                            gm.boardCube[gm.stackMid.Peek() - 1].GetComponent<Renderer>().material.color = left.originLeftColor;
                        }
                        //�� ū ������ ������ ����ó��.
                        else if (gm.stackMid.Peek() < gm.stackLeft.Peek())
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

            //������ ž���� ������ ��.
            if (gm.isRightCheck)
            {
                //������ ž�� ������� ������ ����.
                if (gm.stackRight.Count >= 1)
                {
                    //�߰� ž�� ��������� �׳� ������.
                    if (gm.stackMid.Count == 0)
                    {
                        gm.boardCube[gm.stackRight.Peek() - 1].transform.position = new Vector3(0, 4.5f, 0);
                        gm.stackMid.Push(gm.stackRight.Pop());
                        gm.boardCube[gm.stackMid.Peek() - 1].GetComponent<Renderer>().material.color = right.originRightColor;
                    }
                    //�߰� ž�� ���� �� ������ ����.
                    else if (gm.stackMid.Count != 0)
                    {
                        //�߰� ž�� �� ���Ǻ��� ���� ������ ������ �׳� ������.
                        if (gm.stackMid.Peek() > gm.stackRight.Peek())
                        {
                            gm.boardCube[gm.stackRight.Peek() - 1].transform.position = new Vector3(0, 4.5f, 0);
                            gm.stackMid.Push(gm.stackRight.Pop());
                            gm.boardCube[gm.stackMid.Peek() - 1].GetComponent<Renderer>().material.color = right.originRightColor;
                        }
                        //�� ū ������ ������ ����ó��.
                        else if (gm.stackMid.Peek() < gm.stackRight.Peek())
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
