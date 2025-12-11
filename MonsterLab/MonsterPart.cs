using System;
using System.Numerics;
using Raylib_cs;

namespace MonsterLab;

public class MonsterPart
{
    string name;
    float maxHp;

    public float block = 0;
    float health;

    bool stunned;

    public PartAction[] actions;
    public List<Button> actionsButtons = new List<Button>();


    Monster parent;
    public Monster owner
    {
        private get { return parent; }
        set
        {
            parent = value;
            foreach (PartAction action in actions)
            {
                action.owningMonster = parent;
                action.parent = this;
            }
        }
    }


    public float hp
    {
        get
        {
            return health;
        }
        set
        {
            health = Math.Max(value, 0);
            //Console.WriteLine(health +" : "+ value);
        }
    }

    public bool broken
    {
        get
        {
            if (health > 0)
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
            //Console.WriteLine(health/maxHp);
            if (broken)
            {
                return Color.DarkGray;
            }

            //Green at higer HP, red at lower. Becomes a trasition
            float green = health / maxHp;
            float red = 1 - green;
            return new Color((byte)(255 * red), (byte)(255 * green), (byte)0);
        }
        private set
        {

        }
    }

    //Constructor
    public MonsterPart(string name, int hp, PartAction[] actions)
    {
        this.name = name;

        this.maxHp = hp;
        this.hp = hp;

        this.actions = actions;

        for (int i = 0; i < actions.Length; i++)
        {
            actionsButtons.Add(new Button(new Vector2(500 * (i + 1), 500), new(150, 70), Color.Blue, Color.White, this.actions[i].name, this.actions[i]));
        }

    }


    public void SetTarget(Monster enemy)
    {
        foreach (PartAction action in actions)
        {
            action.oponent = enemy;
        }
    }
    public void Block(int dmg, MonsterPart badie)//who tf knows
    {
        hp -= dmg * (block / 100);
        badie.hp -= dmg * (1 - block / 100);
    }
}
