using System.Collections.Generic;
using System.Linq;
using UnityEngine;

///<summary>Compare to see if the checked number is between two others.</summary>
public class HCompare
{
    ///<summary> Returns true if "c" >= "a" and < "b" </summary>
    public static bool Inside(
    ///<summary> The float that needs comparing </summary>
    float c,
    ///<summary> The smaller float, above the comparator ( c >= a) </summary> 
    float a,
    ///<summary> The higher float, below the comparator ( c < b ) </summary>
    float b)
    {
        if (a <= c && c < b)
            return true;
        else
            return false;
    }

    ///<summary> Returns true if "c" <= "a" or > "b" </summary>
    public static bool Outside(
    ///<summary> The float that needs comparing </summary>  
    float c,
    ///<summary> The smaller float, below the comparator ( c <= a) </summary> 
    float a,
    ///<summary> The higher float, above the comparator ( c > b ) </summary>
    float b)
    {
        if (a >= c && c > b)
            return true;
        else
            return false;
    }
}

///<summary>A clas that holds a bunch of list unilities.</summary>
public class HListUtils
{
    ///<summary>Smallest posible number to the middle (in case its an odd number of elements).</summary>
    public static float Middle_Min(List<float> list)
    {
        float o = list[Mathf.FloorToInt(list.Count / 2)];
        return o;
    }

    ///<summary>Largest posible number to the middle (in case its an odd number of elements).</summary>
    public static float Middle_Max(List<float> list)
    {
        float o = list[Mathf.CeilToInt(list.Count / 2)];
        return o;
    }

    ///<summary>Returns the median sum of the elements in the list.</summary>
    public static float AverageFloat(List<float> list)
    {
        return list.Sum() / list.Count;
    }

    ///<summary>Returns the closest number in the list to the recieved number.</summary>
    public static Vector2 ClosestToNum(List<float> list, float number)
    {

        float closest = -1;
        float index = -1;
        for (int i = 0; i < list.Count; i++)
        {
            if (Mathf.Abs(list[i] - number) < Mathf.Abs(closest - number))
                closest = list[i];
            else
                continue;
        }

        return new Vector2(closest, index);
    }
}

///<summary>HUtils (Hidden Utils) is a library of pre built constructors that facilitate the process of coding large blocks of code.</summary>
public class HUtils
{
    ///<summary> Returns 1 if the bool is NOT true.</summary>
    public static byte WaitForBool(bool comparator)
    {
        byte time = 1;
        if (comparator == false)
            time = 1;
        else
            time = 0;
        return time;
    }

    ///<summary> Returns 1 if the Vector2 is NOT equal to the equalizer.</summary>
    public static byte WaintForVector2(Vector2 comparator, Vector2 equalizer)
    {
        byte time = 1;
        if (comparator == equalizer)
            time = 1;
        else
            time = 0;

        return time;
    }

    ///<summary> Returns 1 if the Vector3 is NOT equal to the equalizer.</summary>
    public static byte WaintForVector3(Vector3 comparator, Vector3 equalizer)
    {
        byte time = 1;
        if (comparator == equalizer)
            time = 1;
        else
            time = 0;

        return time;
    }

    ///<summary> Returns 1 if the float is NOT equal to the equalizer.</summary>
    public static byte WaitForFloat(float comparator, float equalizer)
    {
        byte time = 1;
        if (comparator < equalizer)
            time = 1;
        else if(comparator >= equalizer)
            time = 0;

        return time;
    }

    ///<summary> Returns 1 if the int is NOT equal to the equalizer.</summary>
    public static byte WaitForInt(int comparator, int equalizer)
    {
        byte time = 1;
        if (comparator < equalizer)
            time = 1;
        else if (comparator >= equalizer)
            time = 0;

        return time;
    }

    ///<summary> Returns 1 if the byte is NOT equal to the equalizer.</summary>
    public static byte WaitForByte(byte comparator, byte equalizer)
    {
        byte time = 1;
        if (comparator < equalizer)
            time = 1;
        else if (comparator >= equalizer)
            time = 0;

        return time;
    }


}