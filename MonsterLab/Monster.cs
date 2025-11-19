using System;
using System.Diagnostics.CodeAnalysis;

namespace MonsterLab;

public class Monster
{

    bool blocking = false;
    MonsterPart blockingPart;

    int maxEnergy;
    public int energy
    {
        get
        {
            return energy;
        }
        set
        {
            energy = Math.Max(value, 0);
            energy = Math.Min(value, maxEnergy);
        }
    }

    public Head head;

    public Arm leftArm;
    public Arm rightArm;

    public Torso torso;

    public Leg leftLeg;
    public Leg rightLeg;



    public bool alive
    {
        get
        {
            bool condition2 = leftArm.broken && rightArm.broken && leftLeg.broken && rightLeg.broken && head.broken;
            if (torso.broken || condition2)
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
        this.head = head;
        this.leftArm = leftArm;
        this.rightArm = rightArm;
        this.leftLeg = leftLeg;
        this.rightLeg = rightLeg;
        this.torso = torso;

        maxEnergy = torso.energy;
        energy = torso.energy;
    }

    public void attacked(string[] parts, int damage, int heal)
    {
        if (!blocking)
        {
            if (parts.Contains("Head"))
            {
                head.hp -= damage;
                head.hp += heal;
            }
            if (parts.Contains("LeftLeg"))
            {
                leftLeg.hp -= damage;
                leftLeg.hp += heal;
            }
            if (parts.Contains("RightLeg"))
            {
                rightLeg.hp -= damage;
                rightLeg.hp += heal;
            }
            if (parts.Contains("LeftArm"))
            {
                leftArm.hp -= damage;
                leftArm.hp += heal;
            }
            if (parts.Contains("RightArm"))
            {
                rightArm.hp -= damage;
                rightArm.hp += heal;
            }
            if (parts.Contains("Torso"))
            {
                torso.hp -= damage;
                torso.hp += heal;
            }
        }

    }
}
