using System;

namespace MonsterLab;

public class MonsterPart
{
    string name;
    int maxHp;

    int block = 0;

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

    PartAction[] actions;

    bool stunned;
    public bool broken
    {
        get
        {
            if (hp>0)
            {
                return false;
            }
            return true;
        }
        private set
        {
           
        }
    }

    public MonsterPart(string name, int hp, PartAction[] actions)
    {
        this.name = name;

        this.maxHp = hp;
        this.hp = hp;

        this.actions = actions;
    }
}
