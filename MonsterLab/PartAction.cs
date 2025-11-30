using System;

namespace MonsterLab;

public class PartAction : Something
{
    public string name;

    public Dictionary<string, int> properties = new Dictionary<string, int>();

    string[] tragetParts;

    public Monster owningMonster;
    public MonsterPart parent;
    public Monster oponent;

    public PartAction(string name, int[] properties, string[] targets)
    {
        this.name = name;
        this.properties.Add("EnergyCost", properties[0]);
        this.properties.Add("Damage", properties[1]);
        this.properties.Add("Heal", properties[2]);
        this.properties.Add("Block", properties[3]);
        this.tragetParts = targets;
    }
    public PartAction(PartAction refrance)
    {
        this.name = refrance.name;
        this.properties = refrance.properties;
        this.tragetParts = refrance.tragetParts;
    }

    public override void Use()
    {
        owningMonster.energy -= properties["EnergyCost"];

        oponent.Attacked(tragetParts, properties["Damage"], parent);
        if (properties["Block"] > 0)
        {
            owningMonster.blockingPart = parent;
            parent.block = properties["Block"];
        }

        //return damage;
    }
}
