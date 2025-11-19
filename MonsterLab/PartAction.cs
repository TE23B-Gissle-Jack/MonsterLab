using System;

namespace MonsterLab;

public class PartAction
{
    string name;
    int damage=0;
    int heal=0;
    int cost=0;
    int block = 0;

    string[] tragetParts;

    public PartAction(string name, int cost, string[] targets)
    {
        this.name = name;
        this.cost = cost;
        this.tragetParts = targets;
    }

    public void Use(Monster self, Monster traget)
    {
        self.energy-=cost;

        

        //return damage;
    }
}
