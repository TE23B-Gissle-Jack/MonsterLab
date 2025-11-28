using System;

namespace MonsterLab;

public class MonsterPart
{
    string name;
    int maxHp;

    int block = 0;
    int health;


    public int hp
    {
        get
        {
            return health;
        }
        set
        {
            health = Math.Max(value, 0);
        }
    }

    public PartAction[] actions;

    bool stunned;
    public bool broken
    {
        get
        {
            if (health>0)
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

    public void Block(int dmg)
    {
        
    }
}
