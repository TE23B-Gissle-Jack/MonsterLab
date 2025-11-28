using System;
using System.Diagnostics.CodeAnalysis;

namespace MonsterLab;

public class Monster
{

    public bool blocking = false;
    public MonsterPart blockingPart;

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


    Dictionary<string, MonsterPart> parts = new Dictionary<string, MonsterPart>();



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
            Console.WriteLine(parts["Head"].hp);
            if (parts["Torso"].broken || count>=5)
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

        maxEnergy = torso.energy;
        energy = torso.energy;
    }

    public void attacked(string[] targetedParts, int damage, int heal)
    {
        if (!blocking)
        {
            foreach (string part in targetedParts)
            {
                if (parts.ContainsKey(part))
                {
                    parts[part].hp-=damage;
                    Console.WriteLine("Boom! on the "+ part);
                }
            }
        }

    }
}
