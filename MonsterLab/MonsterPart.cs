using System;

namespace MonsterLab;

public class MonsterPart
{
    int maxHp;
    public int hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = Math.Max(value, 0);
        }
    }
    int maxEnergy;
    int energy
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

    bool stunned;

    public MonsterPart(int hp, int energy)
    {
        this.maxHp = hp;
        this.hp = hp;

        this.maxEnergy = energy;
        this.energy = energy;
    }

    public virtual void action1(MonsterPart[] targets)
    {
        foreach (var part in targets)
        {
            part.hp -= 0;
        }
    }
}
