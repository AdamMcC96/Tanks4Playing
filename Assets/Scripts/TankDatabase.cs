using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TankDatabase : ScriptableObject
{
    public Tank[] tank;
    public int TankCount
    {
        get
        {
            return tank.Length;
        }
    }

    public Tank GetTank(int index)
    {
        return tank[index];
    }
}
