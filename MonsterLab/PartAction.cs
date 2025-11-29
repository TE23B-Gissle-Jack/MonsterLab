using System;

namespace MonsterLab;

public class PartAction
{
    public string name;
    int damage=0;
    int heal=0;// could prob be done with -damage
    int cost;
    int block = 0;

    string[] tragetParts;

    public PartAction(string name, int[] properties, string[] targets)
    {
        this.name = name;
        this.cost = properties[0];
        this.damage = properties[1];
        this.heal = properties[2];
        this.block = properties[3];
        this.tragetParts = targets;
    }

    public void Use(Monster self, Monster traget)
    {
        self.energy-=cost;

        traget.attacked(tragetParts,damage,heal);
        if (block>0)
        {
            self.blocking = true;
            
        }

        //return damage;
    }
}
