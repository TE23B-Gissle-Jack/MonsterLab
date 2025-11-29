using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using Raylib_cs;

namespace MonsterLab;

public class Monster
{

    public bool blocking = false;
    public MonsterPart blockingPart;

    public Dictionary<string, MonsterPart> parts = new Dictionary<string, MonsterPart>();

    Monster oponent;
    public Monster enemy
    {
        get
        {
            return oponent;
        }
        set
        {
            oponent = value;
            foreach (var part in parts.Values)
            {
                part.SetTarget(value);
            }
        }
    }

    int maxEnergy;
    int power;
    public int energy
    {
        get
        {
            return power;
        }
        set
        {
            power = Math.Max(value, 0);
            power = Math.Min(value, maxEnergy);
        }
    }

    public bool alive
    {
        get
        {
            int count = 0;
            foreach (var item in parts.Values)
            {
                if (item.broken)
                {
                    count++;
                }
            }
            if (parts["Torso"].broken || count >= 5)
            {
                return false;
            }
            return true;
        }
        private set
        {

        }
    }

    public Monster(Head head, Arm leftArm, Arm rightArm, Leg leftLeg, Leg rightLeg, Torso torso)
    {
        parts.Add("Head", head);
        parts.Add("LeftArm", leftArm);
        parts.Add("RightArm", rightArm);
        parts.Add("RightLeg", rightLeg);
        parts.Add("LeftLeg", leftLeg);
        parts.Add("Torso", torso);

        foreach (var part in parts.Values)
        {
            part.owner = this;
        }

        maxEnergy = torso.energy;
        energy = torso.energy;
    }

    public void attacked(string[] targetedParts, int damage)
    {
        if (!blocking)
        {
            foreach (string part in targetedParts)
            {
                if (parts.ContainsKey(part))
                {
                    //Console.WriteLine("DMG : "+damage);
                    parts[part].hp = parts[part].hp - damage;
                    //Console.WriteLine("Boom! on the "+ part);
                }
            }
        }

    }

    public void DisplayCondition(Vector2 topLeft, float scale)//base height 210, base width 80
    {
        //+5 are gaps
        //head
        Raylib.DrawRectangleV(topLeft + new Vector2(25, 0) * scale, new Vector2(50, 50) * scale, parts["Head"].color);
        //torso
        Raylib.DrawRectangleV(topLeft + new Vector2(25, 50 + 5) * scale, new Vector2(50, 75) * scale, parts["Torso"].color);

        //arms
        Raylib.DrawRectangleV(topLeft + new Vector2(0, 50 + 5) * scale, new Vector2(20, 75) * scale, parts["LeftArm"].color);
        Raylib.DrawRectangleV(topLeft + new Vector2(75 + 5, 50 + 5) * scale, new Vector2(20, 75) * scale, parts["RightArm"].color);

        //legs
        Raylib.DrawRectangleV(topLeft + new Vector2(20 + 5, 130 + 5) * scale, new Vector2(20, 75) * scale, parts["LeftLeg"].color);
        Raylib.DrawRectangleV(topLeft + new Vector2(50 + 5, 130 + 5) * scale, new Vector2(20, 75) * scale, parts["RightLeg"].color);

    }

}
