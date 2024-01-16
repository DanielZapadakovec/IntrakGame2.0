using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardIdentity : MonoBehaviour
{
    public int ID;
    public string Name;
    public string Description;



    public CardIdentity()
    {

    }

    public CardIdentity (int iD, string name, string description)
    {
        ID = iD;
        Name = name;
        Description = description;
    }
}
