using System;
using Raylib_cs;

namespace MonsterLab;

public class MonsterPart
{
    string name;
    float maxHp;

    int block = 0;
    float health;

    bool stunned;

    public PartAction[] actions;


    public float hp
    {
        get
        {
            return health;
        }
        set
        {
            health = Math.Max(value, 0);
            Console.WriteLine(health +" : "+ value);
        }
    }

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
    public Color color
    {
        get
        {
            Console.WriteLine(health/maxHp);
            if (broken)
            {
                return Color.DarkGray;
            }

            //Green at higer HP, red at lower. Becomes a trasition
            float green = health/maxHp;
            float red = 1-green;
            return new Color((byte)(255*red),(byte)(255*green),(byte)0);
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

    

    public void Block(int dmg)//who tf knows
    {
        
    }
}
