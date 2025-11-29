using System;

namespace MonsterLab;

public class PartAction : Something
{
    public string name;
    int damage=0;
    int heal=0;// could prob be done with -damage
    int cost;
    int block = 0;

    string[] tragetParts;

    public Monster self;
    public Monster oponent;

    public PartAction(string name, int[] properties, string[] targets)
    {
        this.name = name;
        this.cost = properties[0];
        this.damage = properties[1];
        this.heal = properties[2];
        this.block = properties[3];
        this.tragetParts = targets;
    }

    public override void Use()
    {
        self.energy-=cost;

        oponent.attacked(tragetParts,damage);
        if (block>0)
        {
            self.blocking = true;
            
        }

        //return damage;
    }
}
