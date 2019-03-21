using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadStatus
{
    public int Prefab_Num = -1;

    public int To_A = -1; // x - 1 0 막힘 1 횡단보도 2 직진도로
    public int To_D = -1; // x + 1 0 막힘 1 횡단보도 2 직진도로
    public int To_W = -1; // z + 1 0 막힘 1 횡단보도 2 직진도로
    public int To_S = -1; // z - 1 0 막힘 1 횡단보도 2 직진도로

    public bool Is_Make_Prefab = false;
    public bool bool_City = false;

    public RoadStatus()
    {

    }
    public RoadStatus(int Prefab_Num)
    {
        this.Prefab_Num = Prefab_Num;
        Compute_To_Num();
    }
    public RoadStatus(int To_A, int To_D, int To_W, int To_S)
    {
        this.To_A = To_A;
        this.To_D = To_D;
        this.To_W = To_W;
        this.To_S = To_S;
    }
    public void Set(int A, int D, int W, int S)
    {
        To_A = A;
        To_D = D;
        To_W = W;
        To_S = S;
    }
    public bool Is_City()
    {
        if(Prefab_Num == 0)
            return true;
        return false;
    }
    public bool Is_Road()
    {
        if (Prefab_Num != 0 && Prefab_Num / 10 == 0)
            return true;
        return false;
    }
    public bool Is_CrossRoad()
    {
        if (Prefab_Num / 10 >= 1)
            return true;
        return false;
    }
    public int Type_Prefab()
    {
        if (Is_City())
            return 0;
        if (Is_Road())
            return 1;
        if (Is_CrossRoad())
            return 2;
        return -1;
    }
    void Compute_To_Num()
    {
        if (Prefab_Num == -1)
            Debug.Log("Prefab Number Loss! Error : Compute_To_Num");
        switch (Prefab_Num)
        {
            case 0:
                To_A = 0;
                To_D = 0;
                To_W = 0;
                To_S = 0;
                break;
            case 1:
                To_A = 0;
                To_D = 0;
                To_W = 1;
                To_S = 1;
                break;
            case 2:
                To_A = 1;
                To_D = 1;
                To_W = 0;
                To_S = 0;
                break;
            case 3:
                To_A = 0;
                To_D = 0;
                To_W = 2;
                To_S = 2;
                break;
            case 4:
                To_A = 2;
                To_D = 2;
                To_W = 0;
                To_S = 0;
                break;
            case 5:
                To_A = 0;
                To_D = 0;
                To_W = 1;
                To_S = 2;
                break;
            case 6:
                To_A = 2;
                To_D = 1;
                To_W = 0;
                To_S = 0;
                break;
            case 7:
                To_A = 0;
                To_D = 0;
                To_W = 2;
                To_S = 1;
                break;
            case 8:
                To_A = 1;
                To_D = 2;
                To_W = 0;
                To_S = 0;
                break;
            case 11:
                To_A = 1;
                To_D = 1;
                To_W = 1;
                To_S = 1;
                break;
            case 12:
                To_A = 1;
                To_D = 0;
                To_W = 1;
                To_S = 1;
                break;
            case 13:
                To_A = 1;
                To_D = 1;
                To_W = 1;
                To_S = 0;
                break;
            case 14:
                To_A = 0;
                To_D = 1;
                To_W = 1;
                To_S = 1;
                break;
            case 15:
                To_A = 1;
                To_D = 1;
                To_W = 0;
                To_S = 1;
                break;
            case 16:
                To_A = 0;
                To_D = 0;
                To_W = 2;
                To_S = 2;
                break;
            case 17:
                To_A = 2;
                To_D = 2;
                To_W = 0;
                To_S = 0;
                break;
            case 18:
                To_A = 2;
                To_D = 0;
                To_W = 2;
                To_S = 0;
                break;
            case 19:
                To_A = 0;
                To_D = 2;
                To_W = 2;
                To_S = 0;
                break;
            case 20:
                To_A = 0;
                To_D = 2;
                To_W = 0;
                To_S = 2;
                break;
            case 21:
                To_A = 2;
                To_D = 0;
                To_W = 0;
                To_S = 2;
                break;
        }
    }
    public static int Compute_CrossRoad_Num(RoadStatus CrossRoad_A, RoadStatus CrossRoad_D, RoadStatus CrossRoad_W, RoadStatus CrossRoad_S,
                                            RoadStatus A, RoadStatus D, RoadStatus W, RoadStatus S)
    {
        List<int> Able_Number = new List<int>();
        for (int i = 11; i < 22; i++)
            Able_Number.Add(i);

        RoadStatus[] CrossRoads = new RoadStatus[11];
        for (int i = 0; i < 11; i++)
            CrossRoads[i] = new RoadStatus(i + 11);

        if(CrossRoad_A != null && CrossRoad_A.To_D == 0)
        {
            for (int i = 0; i < 11; i++) {
                if(CrossRoads[i].To_A != 0)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }
        else if(CrossRoad_A != null && CrossRoad_A.To_D != 0)
        {
            for (int i = 0; i < 11; i++)
            {
                if (CrossRoads[i].To_A == 0)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }

        if(CrossRoad_D != null && CrossRoad_D.To_A == 0)
        {
            for (int i = 0; i < 11; i++)
            {
                if (CrossRoads[i].To_D != 0)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }
        else if(CrossRoad_D != null && CrossRoad_D.To_A != 0)
        {
            for (int i = 0; i < 11; i++)
            {
                if (CrossRoads[i].To_D == 0)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }

        if(CrossRoad_W != null && CrossRoad_W.To_S == 0)
        {
            for (int i = 0; i < 11; i++)
            {
                if (CrossRoads[i].To_W != 0)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }
        else if(CrossRoad_W != null && CrossRoad_W.To_S != 0)
        {
            for (int i = 0; i < 11; i++)
            {
                if (CrossRoads[i].To_W == 0)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }

        if(CrossRoad_S != null && CrossRoad_S.To_W == 0)
        {
            for (int i = 0; i < 11; i++)
            {
                if (CrossRoads[i].To_S != 0)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }
        else if(CrossRoad_S != null && CrossRoad_S.To_W != 0)
        {
            for (int i = 0; i < 11; i++)
            {
                if (CrossRoads[i].To_S == 0)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }
        
        if(A != null && A.To_D == 0)
        {
            for (int i = 0; i < 11; i++)
            {
                if (CrossRoads[i].To_A != 0)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }
        else if(A != null && A.To_D == 1)
        {
            for (int i = 0; i < 11; i++)
            {
                if (CrossRoads[i].To_A != 1)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }
        else if (A != null && A.To_D == 2)
        {
            for (int i = 0; i < 11; i++)
            {
                if (CrossRoads[i].To_A != 2)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }

        if(D != null && D.To_A == 0)
        {
            for (int i = 0; i < 11; i++)
            {
                if (CrossRoads[i].To_D != 0)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }
        else if(D != null && D.To_A == 1)
        {
            for (int i = 0; i < 11; i++)
            {
                if (CrossRoads[i].To_D != 1)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }
        else if (D != null && D.To_A == 2)
        {
            for (int i = 0; i < 11; i++)
            {
                if (CrossRoads[i].To_D != 2)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }

        if(W != null && W.To_S == 0)
        {
            for (int i = 0; i < 11; i++)
            {
                if (CrossRoads[i].To_W != 0)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }
        else if(W != null && W.To_S == 1)
        {
            for (int i = 0; i < 11; i++)
            {
                if (CrossRoads[i].To_W != 1)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }
        else if (W != null && W.To_S == 2)
        {
            for (int i = 0; i < 11; i++)
            {
                if (CrossRoads[i].To_W != 2)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }

        if(S != null && S.To_W == 0)
        {
            for (int i = 0; i < 11; i++)
            {
                if (CrossRoads[i].To_S != 0)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }
        else if(S != null && S.To_W == 1)
        {
            for (int i = 0; i < 11; i++)
            {
                if (CrossRoads[i].To_S != 1)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }
        else if (S != null && S.To_W == 2)
        {
            for (int i = 0; i < 11; i++)
            {
                if (CrossRoads[i].To_S != 2)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }

        if (Able_Number.Count == 0)
            return -1;
        if (Able_Number.Count == 1)
            return Able_Number[0];
        return Able_Number[Random.Range(0, Able_Number.Count - 1)];
    }
    public static int Compute_Road_Num(RoadStatus A, RoadStatus D, RoadStatus W, RoadStatus S)
    {
        List<int> Able_Number = new List<int>();
        for (int i = 1; i < 9; i++)
            Able_Number.Add(i);

        RoadStatus[] CrossRoads = new RoadStatus[8];
        for (int i = 0; i < 8; i++)
            CrossRoads[i] = new RoadStatus(i + 1);


        if (A != null && A.To_D == 0)
        {
            for (int i = 0; i < 8; i++)
            {
                if (CrossRoads[i].To_A != 0)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }
        else if (A != null && A.To_D == 1)
        {
            for (int i = 0; i < 8; i++)
            {
                if (CrossRoads[i].To_A != 1)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }
        else if (A != null && A.To_D == 2)
        {
            for (int i = 0; i < 8; i++)
            {
                if (CrossRoads[i].To_A != 2)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }

        if (D != null && D.To_A == 0)
        {
            for (int i = 0; i < 8; i++)
            {
                if (CrossRoads[i].To_D != 0)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }
        else if (D != null && D.To_A == 1)
        {
            for (int i = 0; i < 8; i++)
            {
                if (CrossRoads[i].To_D != 1)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }
        else if (D != null && D.To_A == 2)
        {
            for (int i = 0; i < 8; i++)
            {
                if (CrossRoads[i].To_D != 2)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }

        if (W != null && W.To_S == 0)
        {
            for (int i = 0; i < 8; i++)
            {
                if (CrossRoads[i].To_W != 0)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }
        else if (W != null && W.To_S == 1)
        {
            for (int i = 0; i < 8; i++)
            {
                if (CrossRoads[i].To_W != 1)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }
        else if (W != null && W.To_S == 2)
        {
            for (int i = 0; i < 8; i++)
            {
                if (CrossRoads[i].To_W != 2)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }

        if (S != null && S.To_W == 0)
        {
            for (int i = 0; i < 8; i++)
            {
                if (CrossRoads[i].To_S != 0)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }
        else if (S != null && S.To_W == 1)
        {
            for (int i = 0; i < 8; i++)
            {
                if (CrossRoads[i].To_S != 1)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }
        else if (S != null && S.To_W == 2)
        {
            for (int i = 0; i < 8; i++)
            {
                if (CrossRoads[i].To_S != 2)
                {
                    Able_Number.Remove(CrossRoads[i].Prefab_Num);
                }
            }
        }

        if (Able_Number.Count == 0)
            return 0;
        if (Able_Number.Count == 1)
            return Able_Number[0];
        return Able_Number[Random.Range(0, Able_Number.Count - 1)];
    }
}

public class RoadCreater
{
    public RoadStatus[,] Array_Road;
    // 0 City 0도 90도 180도 270도 A:0/D:0/W:0/S:0

    // 1 Road3 0도 180도 A:0/D:0/W:1/S:1
    // 2 Road3 90도 270도 A:1/D:1/W:0/S:0
    // 3 Road2 0도 180도 A:0/D:0/W:2/S:2
    // 4 Road2 90도 270도 A:2/D:2/W:0/S:0
    // 5 Road1 0도 A:0/D:0/W:1/S:2
    // 6 Road1 90도 A:2/D:1/W:0/S:0
    // 7 Road1 180도 A:0/D:0/W:2/S:1 
    // 8 Road1 270도 A:1/D:2/W:0/S:0

    // 11 CrossRoad1 0도 90도 180도 270도 A:1/D:1/W:1/S:1
    // 12 CrossRoad2 0도 A:1/D:0/W:1/S:1
    // 13 CrossRoad2 90도 A:1/D:1/W:1/S:0
    // 14 CrossRoad2 180도 A:0/D:1/W:1/S:1
    // 15 CrossRoad2 270도 A:1/D:1/W:0/S:1
    // 16 CrossRoad3 0도 180도 A:0/D:0/W:2/S:2
    // 17 CrossRoad3 90도 270도 A:2/D:2/W:0/S:0
    // 18 CorssRoad4 0도 A:2/D:0/W:2/S:0
    // 19 CrossRoad4 90도 A:0/D:2/W:2/S:0
    // 20 CrossRoad4 180도 A:0/D:2/W:0/S:2
    // 21 CrossRoad4 270도 A:2/D:0/W:0/S:2
    public int Road_Size;
    public RoadCreater(int Road_Size)
    {
        this.Road_Size = Road_Size;
        Array_Road = new RoadStatus[Road_Size, Road_Size];

        for (int i = 0; i < Road_Size; i++)
            for (int j = 0; j < Road_Size; j++)
                Array_Road[i, j] = null;
    }
    public void Init_Road()
    {
        int Center_Size = Road_Size / 2;
        int Road = Random.Range(0, 2);
        int Angle = Random.Range(0, 3) * 90;
        switch (Road)
        {
            case 0:
                if (Angle == 0)
                {
                    Array_Road[Center_Size, Center_Size] = new RoadStatus(5);
                }
                else if (Angle == 90)
                {
                    Array_Road[Center_Size, Center_Size] = new RoadStatus(6);
                }
                else if (Angle == 180)
                {
                    Array_Road[Center_Size, Center_Size] = new RoadStatus(7);
                }
                else if (Angle == 270)
                {
                    Array_Road[Center_Size, Center_Size] = new RoadStatus(8);
                }
                break;
            case 1:
                if (Angle == 0 || Angle == 180)
                {
                    Array_Road[Center_Size, Center_Size] = new RoadStatus(3);
                }
                else if (Angle == 90 || Angle == 270)
                {
                    Array_Road[Center_Size, Center_Size] = new RoadStatus(4);
                }
                break;
            case 2:
                if (Angle == 0 || Angle == 180)
                {
                    Array_Road[Center_Size, Center_Size] = new RoadStatus(1);
                }
                else if (Angle == 90 || Angle == 270)
                {
                    Array_Road[Center_Size, Center_Size] = new RoadStatus(2);
                }
                break;
        }

        Init_Fill_City(Angle);
        Init_Fill_CrossRoad(Angle);
        Init_Fill_Road();
    }

    void Init_Fill_City(int Angle)
    {
        int I_Start = 0;
        int J_Start = 0;
        if (Angle == 0 || Angle == 180)
            J_Start = 1;
        else
            I_Start = 1;
        for (int i = I_Start; i < Road_Size; i += 2)
        {
            for (int j = J_Start; j < Road_Size; j += 2)
            {
                Array_Road[i, j] = new RoadStatus(0);
                Array_Road[i, j].bool_City = true;
            }
        }
    }

    void Init_Fill_CrossRoad(int Angle)
    {
        int I_Start = 0;
        int J_Start = 0;
        if (Angle == 0 || Angle == 180)
            I_Start = 1;
        else
            J_Start = 1;
        for (int i = I_Start; i < Road_Size; i += 2)
        {
            for (int j = J_Start; j < Road_Size; j += 2)
            {
                RoadStatus[] crossroads = { null, null, null, null };

                if (j - 2 >= 0)
                {
                    crossroads[0] = Array_Road[i, j - 2]; // A
                }

                if (j + 2 < Road_Size)
                {
                    crossroads[1] = Array_Road[i, j + 2];
                }

                if (i - 2 >= 0)
                {
                    crossroads[2] = Array_Road[i - 2, j];
                }

                if (i + 2 < Road_Size)
                {
                    crossroads[3] = Array_Road[i + 2, j];
                }

                RoadStatus[] roads = { null, null, null, null };

                if (j - 1 >= 0)
                {
                    roads[0] = Array_Road[i, j - 1]; // A
                }

                if (j + 1 < Road_Size)
                {
                    roads[1] = Array_Road[i, j + 1];
                }

                if (i - 1 >= 0)
                {
                    roads[2] = Array_Road[i - 1, j];
                }

                if (i + 1 < Road_Size)
                {
                    roads[3] = Array_Road[i + 1, j];
                }

                int Prefab_Number = RoadStatus.Compute_CrossRoad_Num(crossroads[0], crossroads[1], crossroads[2], crossroads[3],
                                                                     roads[0], roads[1], roads[2], roads[3]);
                if (Prefab_Number == -1)
                {
                    Debug.Log("Compute Prefab Number Loss! Error : Init_Fill_CrossRoad");
                }
                else
                {
                    Array_Road[i, j] = new RoadStatus(Prefab_Number);
                }
            }
        }
    }

    void Init_Fill_Road()
    {
        for (int i = 0; i < Road_Size; i++)
        {
            for (int j = i % 2; j < Road_Size; j += 2)
            {
                RoadStatus[] roads = { null, null, null, null };

                if (j - 1 >= 0)
                {
                    roads[0] = Array_Road[i, j - 1]; // A
                }

                if (j + 1 < Road_Size)
                {
                    roads[1] = Array_Road[i, j + 1];
                }

                if (i - 1 >= 0)
                {
                    roads[2] = Array_Road[i - 1, j];
                }

                if (i + 1 < Road_Size)
                {
                    roads[3] = Array_Road[i + 1, j];
                }

                int Prefab_Number = RoadStatus.Compute_Road_Num(roads[0], roads[1], roads[2], roads[3]);
                if (Prefab_Number == -1)
                {
                    Debug.Log("Compute Prefab Number Loss! Error : Init_Fill_CrossRoad");
                }
                else
                {
                    Array_Road[i, j] = new RoadStatus(Prefab_Number);
                }
            }
        }
    }

    public void Make_Prefab()
    {
        for (int i = 0; i < Road_Size; i++)
        {
            for (int j = 0; j < Road_Size; j++)
            {
                if (Array_Road[i, j] == null)
                {
                    RoadStatus[] roads = { null, null, null, null }; // ADWS
                    if (j - 1 >= 0)
                    {
                        roads[0] = Array_Road[i, j - 1];
                    }
                    if (j + 1 < Road_Size)
                    {
                        roads[1] = Array_Road[i, j + 1];
                    }
                    if (i - 1 >= 0)
                    {
                        roads[2] = Array_Road[i - 1, j];
                    }
                    if (i + 1 < Road_Size)
                    {
                        roads[3] = Array_Road[i + 1, j];
                    }

                    int index = -1;
                    for (int k = 0; k < 4; k++)
                    {
                        if (roads[k] != null)
                        {
                            if (roads[k].Is_Road() || (roads[k].Is_City() && !roads[k].bool_City))
                                index = 1;
                            else if (roads[k].Is_City())
                                index = 0;
                            else if (roads[k].Is_CrossRoad())
                                index = 2;
                        }
                    }

                    if (index == -1)
                    {
                        Debug.Log("From A From D From W From S All NULL! Error : Make_Prefab");
                    }

                    if (index == 1)
                    {
                        RoadStatus[] crossroads = { null, null, null, null };

                        if (j - 2 >= 0)
                        {
                            crossroads[0] = Array_Road[i, j - 2]; // A
                        }

                        if (j + 2 < Road_Size)
                        {
                            crossroads[1] = Array_Road[i, j + 2];
                        }

                        if (i - 2 >= 0)
                        {
                            crossroads[2] = Array_Road[i - 2, j];
                        }

                        if (i + 2 < Road_Size)
                        {
                            crossroads[3] = Array_Road[i + 2, j];
                        }

                        int cross_Index = -1;
                        for (int k = 0; k < 4; k++)
                        {
                            if (crossroads[k] != null)
                            {
                                if (crossroads[k].Is_Road() || (crossroads[k].Is_City() && !crossroads[k].bool_City))
                                    cross_Index = 1;
                                else if (crossroads[k].Is_City())
                                    cross_Index = 0;
                                else if (crossroads[k].Is_CrossRoad())
                                    cross_Index = 2;
                            }
                        }

                        if (cross_Index == -1)
                        {
                            Debug.Log("From A From D From W From S All NULL! Error : Make_Prefab");
                        }
                        else if (cross_Index == 0)
                        {
                            Array_Road[i, j] = new RoadStatus(0);
                            Array_Road[i, j].bool_City = true;
                        }
                        else if (cross_Index == 2)
                        {
                            int Prefab_Number = RoadStatus.Compute_CrossRoad_Num(crossroads[0], crossroads[1], crossroads[2], crossroads[3],
                                                                     roads[0], roads[1], roads[2], roads[3]);
                            if (Prefab_Number == -1)
                            {
                                Debug.Log("Compute Prefab Number Loss! Error : Init_Fill_CrossRoad");
                            }
                            else
                            {
                                Array_Road[i, j] = new RoadStatus(Prefab_Number);
                            }
                        }
                    }
                }
            }
        }

        for (int i = 0; i < Road_Size; i++)
        {
            for (int j = 0; j < Road_Size; j++)
            {
                if (Array_Road[i, j] == null)
                {
                    RoadStatus[] roads = { null, null, null, null }; // ADWS
                    if (j - 1 >= 0)
                    {
                        roads[0] = Array_Road[i, j - 1];
                    }
                    if (j + 1 < Road_Size)
                    {
                        roads[1] = Array_Road[i, j + 1];
                    }
                    if (i - 1 >= 0)
                    {
                        roads[2] = Array_Road[i - 1, j];
                    }
                    if (i + 1 < Road_Size)
                    {
                        roads[3] = Array_Road[i + 1, j];
                    }

                    int index = -1;
                    for (int k = 0; k < 4; k++)
                    {
                        if (roads[k] != null)
                        {
                            if (roads[k].Is_Road() || (roads[k].Is_City() && !roads[k].bool_City))
                                index = 1;
                            else if (roads[k].Is_City())
                                index = 0;
                            else if (roads[k].Is_CrossRoad())
                                index = 2;
                        }
                    }

                    if (index == -1)
                    {
                        Debug.Log("From A From D From W From S All NULL! Error : Make_Prefab");
                    }

                    if (index == 0 || index == 2)
                    {
                        int Prefab_Number = RoadStatus.Compute_Road_Num(roads[0], roads[1], roads[2], roads[3]);
                        if (Prefab_Number == -1)
                        {
                            Debug.Log("Compute Prefab Number Loss! Error : Init_Fill_CrossRoad");
                        }
                        else
                        {
                            Array_Road[i, j] = new RoadStatus(Prefab_Number);
                        }
                    }
                }
            }
        }
    }
}

public class RoadManager : MonoBehaviour {
    public GameObject[] Road;
    public GameObject[] CrossRoad;
    public GameObject building;
    public GameObject car;

    public GameObject[,] List_Road;

    private RoadCreater roadCreater;

    private float Start_X = 0, Start_Z = 0;
    private bool Is_Destroy = false;

    public int Road_Size = 11;

    void Init_Setup()
    {
        List_Road = new GameObject[Road_Size, Road_Size];
        gameObject.transform.localScale = new Vector3(Road_Size * 27, 100, Road_Size * 27);
        roadCreater = new RoadCreater(Road_Size);

        roadCreater.Init_Road();
        for(int i = 0; i < Road_Size; i++)
        {
            for(int j = 0; j < Road_Size; j++)
            {
                if (roadCreater.Array_Road[i, j] != null && roadCreater.Array_Road[i, j].Is_Make_Prefab == false)
                {
                    Make_Prefab(roadCreater.Array_Road[i, j].Prefab_Num, i, j, -(27 * (int)(Road_Size / 2)) + (j * 27) + Start_X,
                        27 * (int)(Road_Size / 2) - (i * 27) + Start_Z);

                    roadCreater.Array_Road[i, j].Is_Make_Prefab = true;
                }
            }
        }
    }

	// Use this for initialization
	void Start () {
        Start_X = 0;
        Start_Z = 0;
        Init_Setup();
	}
	
	// Update is called once per frame
	void Update () {
        if (Is_Destroy)
        {
            Check_Null();
            StartCoroutine("Make_Prefabe_at_Null");
        }
        //this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.transform.rotation = Quaternion.identity;
        this.transform.position = car.transform.position;
    }

    void Check_Null()
    {
        if (List_Road[0, (int)(Road_Size / 2)] == null)
        {
            //Debug.Log("위쪽 prefab 파괴");
            for (int i = 0; i < Road_Size - 1; i++)
            {
                for (int j = 0; j < Road_Size; j++)
                {
                    List_Road[i, j] = List_Road[i + 1, j];
                    roadCreater.Array_Road[i, j] = roadCreater.Array_Road[i + 1, j];
                }
            }

            for (int i = 0; i < Road_Size; i++)
            {
                List_Road[Road_Size - 1, i] = null;
                roadCreater.Array_Road[Road_Size - 1, i] = null;
            }
            Start_Z -= 27;
        }
        else if(List_Road[Road_Size - 1, (int)(Road_Size / 2)] == null)
        {
            //Debug.Log("아래쪽 prefab 파괴");
            for (int i = Road_Size - 1; i > 0; i--)
            {
                for (int j = 0; j < Road_Size; j++)
                {
                    List_Road[i, j] = List_Road[i - 1, j];
                    roadCreater.Array_Road[i, j] = roadCreater.Array_Road[i - 1, j];
                }
            }

            for (int i = 0; i < Road_Size; i++)
            {
                List_Road[0, i] = null;
                roadCreater.Array_Road[0, i] = null;
            }
            Start_Z += 27;
        }

        if(List_Road[(int)(Road_Size / 2), 0] == null)
        {
            //Debug.Log("왼쪽 prefab 파괴");
            for (int i = 0; i < Road_Size; i++)
            {
                for (int j = 0; j < Road_Size - 1; j++)
                {
                    List_Road[i, j] = List_Road[i, j + 1];
                    roadCreater.Array_Road[i, j] = roadCreater.Array_Road[i, j + 1];
                }
            }

            for (int i = 0; i < Road_Size; i++)
            {
                List_Road[i, Road_Size - 1] = null;
                roadCreater.Array_Road[i, Road_Size - 1] = null;
            }

            Start_X += 27;
        }else if(List_Road[(int)(Road_Size / 2), Road_Size - 1] == null)
        {
            //Debug.Log("오른쪽 prefab 파괴");
            for (int i = 0; i < Road_Size; i++)
            {
                for (int j = Road_Size - 1; j > 0; j--)
                {
                    List_Road[i, j] = List_Road[i, j - 1];
                    roadCreater.Array_Road[i, j] = roadCreater.Array_Road[i, j - 1];
                }
            }

            for (int i = 0; i < Road_Size; i++)
            {
                List_Road[i, 0] = null;
                roadCreater.Array_Road[i, 0] = null;
            }
            Start_X -= 27;
        }
    }

    IEnumerator Make_Prefabe_at_Null()
    {
        roadCreater.Make_Prefab();

        for(int i = 0; i < Road_Size; i++)
        {
            for(int j = 0; j < Road_Size; j++)
            {
                if(roadCreater.Array_Road[i, j] != null && !roadCreater.Array_Road[i, j].Is_Make_Prefab)
                {
                    Make_Prefab(roadCreater.Array_Road[i, j].Prefab_Num, i, j, -(27 * (int)(Road_Size / 2)) + (j * 27) + Start_X,
                        27 * (int)(Road_Size / 2) - (i * 27) + Start_Z);

                    roadCreater.Array_Road[i, j].Is_Make_Prefab = true;
                }
            }
        }
        yield return null;
    }

    void Make_Prefab(int Prefab_Num, int i, int j, float x, float z)
    {
        switch (Prefab_Num)
        {
            case 0:
                List_Road[i, j] = Instantiate(building, new Vector3(x, 0, z), Quaternion.Euler(new Vector3(0, Random.Range(0, 3) * 90, 0)));
                break;
            case 1:
                List_Road[i, j] = Instantiate(Road[2], new Vector3(x, -0.5f, z), Quaternion.identity);
                break;
            case 2:
                List_Road[i, j] = Instantiate(Road[2], new Vector3(x, -0.5f, z), Quaternion.Euler(new Vector3(0, 90, 0)));
                break;
            case 3:
                List_Road[i, j] = Instantiate(Road[1], new Vector3(x, -0.5f, z), Quaternion.identity);
                break;
            case 4:
                List_Road[i, j] = Instantiate(Road[1], new Vector3(x, -0.5f, z), Quaternion.Euler(new Vector3(0, 90, 0)));
                break;
            case 5:
                List_Road[i, j] = Instantiate(Road[0], new Vector3(x, -0.5f, z), Quaternion.identity);
                break;
            case 6:
                List_Road[i, j] = Instantiate(Road[0], new Vector3(x, -0.5f, z), Quaternion.Euler(new Vector3(0, 90, 0)));
                break;
            case 7:
                List_Road[i, j] = Instantiate(Road[0], new Vector3(x, -0.5f, z), Quaternion.Euler(new Vector3(0, 180, 0)));
                break;
            case 8:
                List_Road[i, j] = Instantiate(Road[0], new Vector3(x, -0.5f, z), Quaternion.Euler(new Vector3(0, 270, 0)));
                break;
            case 11:
                List_Road[i, j] = Instantiate(CrossRoad[0], new Vector3(x, -0.5f, z), Quaternion.identity);
                break;
            case 12:
                List_Road[i, j] = Instantiate(CrossRoad[1], new Vector3(x, -0.5f, z), Quaternion.identity);
                break;
            case 13:
                List_Road[i, j] = Instantiate(CrossRoad[1], new Vector3(x, -0.5f, z), Quaternion.Euler(new Vector3(0, 90, 0)));
                break;
            case 14:
                List_Road[i, j] = Instantiate(CrossRoad[1], new Vector3(x, -0.5f, z), Quaternion.Euler(new Vector3(0, 180, 0)));
                break;
            case 15:
                List_Road[i, j] = Instantiate(CrossRoad[1], new Vector3(x, -0.5f, z), Quaternion.Euler(new Vector3(0, 270, 0)));
                break;
            case 16:
                List_Road[i, j] = Instantiate(CrossRoad[2], new Vector3(x, -0.5f, z), Quaternion.identity);
                break;
            case 17:
                List_Road[i, j] = Instantiate(CrossRoad[2], new Vector3(x, -0.5f, z), Quaternion.Euler(new Vector3(0, 90, 0)));
                break;
            case 18:
                List_Road[i, j] = Instantiate(CrossRoad[3], new Vector3(x, -0.5f, z), Quaternion.identity);
                break;
            case 19:
                List_Road[i, j] = Instantiate(CrossRoad[3], new Vector3(x, -0.5f, z), Quaternion.Euler(new Vector3(0, 90, 0)));
                break;
            case 20:
                List_Road[i, j] = Instantiate(CrossRoad[3], new Vector3(x, -0.5f, z), Quaternion.Euler(new Vector3(0, 180, 0)));
                break;
            case 21:
                List_Road[i, j] = Instantiate(CrossRoad[3], new Vector3(x, -0.5f, z), Quaternion.Euler(new Vector3(0, 270, 0)));
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("Road") || other.gameObject.tag.Equals("city") || other.gameObject.tag.Equals("CrossRoad"))
        {
            Destroy(other.gameObject);
            Is_Destroy = true;
        }
    }
}