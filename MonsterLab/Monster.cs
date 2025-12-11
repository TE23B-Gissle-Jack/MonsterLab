using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Reflection.Metadata;
using Raylib_cs;

namespace MonsterLab;

public class Monster
{
    string[] posibleNames = ["Jeff", "Mongore", "Lizard", "Pizard", "Sizard", "Tizard", "Mizard", "Glopy", "Slopy", "Dropy", "Devron", "Quiche", "<kuraam Bat"];
    string name;

    public bool blocking
    {
        get
        {
            if (blockingPart != null)
            {
                return true;
            }
            return false;
        }
        set
        {

        }
    }
    public MonsterPart blockingPart;

    public Dictionary<string, MonsterPart> parts = new Dictionary<string, MonsterPart>();

    string selectedBodypart = "Head";
    public List<Button> ActionsButtons
    {
        get
        {
            return parts[selectedBodypart].actionsButtons;
        }
    }

    

    Monster oponent;
    public Monster Enemy
    {
        get
        {
            return oponent;
        }
        set
        {
            oponent = value;
            foreach (var part in parts.Values)
            {
                part.SetTarget(value);
            }
        }
    }

    int maxEnergy;
    int power;
    public int Energy
    {
        get
        {
            return power;
        }
        set
        {
            power = Math.Max(value, 0);
            power = Math.Min(value, maxEnergy);
        }
    }

    public bool Alive
    {
        get
        {
            int count = 0;
            foreach (var item in parts.Values)
            {
                if (item.broken)
                {
                    count++;
                }
            }
            if (parts["Torso"].broken || count >= 5)
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
        parts.Add("Head", head);
        parts.Add("LeftArm", leftArm);
        parts.Add("RightArm", rightArm);
        parts.Add("RightLeg", rightLeg);
        parts.Add("LeftLeg", leftLeg);
        parts.Add("Torso", torso);

        foreach (var part in parts.Values)
        {
            part.owner = this;
        }
        //assigne Random Name, for resons
        name = posibleNames[Random.Shared.Next(posibleNames.Length)];

        maxEnergy = torso.energy;
        Energy = torso.energy;
    }

    public void Attacked(string[] targetedParts, int damage, MonsterPart attakingPart)
    {
        if (!blocking)
        {
            foreach (string part in targetedParts)
            {
                if (parts.ContainsKey(part))
                {
                    //Console.WriteLine("DMG : "+damage);
                    parts[part].hp = parts[part].hp - damage;
                    //Console.WriteLine("Boom! on the "+ part);
                }
            }
        }
        else
        {
            Console.WriteLine(name + " B-B-B-Bloked");
            blockingPart.Block(damage, attakingPart);
            //do thing then
            blockingPart = null;
        }

    }
    // for retaliaton throug block
    public void Attacked(MonsterPart target, int damage)
    {
        target.hp -= damage;
    }

    public void DisplayCondition(Vector2 topLeft, float scale)//base height 210, base width 80
    {
        //using AI to write the simmilar/repetavive lines, might look od in comits.
        //+5 are gaps
        //head
        Vector2 headPos = topLeft + new Vector2(25, 0) * scale;
        Vector2 headSize = new Vector2(50, 50) * scale;
        Button head = new Button(headPos, headSize, parts["Head"].color, Color.Red, "", new SelectBodypart("Head", this));
        head.Update();
        head.draw();

        //torso
        Vector2 torsoPos = topLeft + new Vector2(25, 50 + 5) * scale;
        Vector2 torsoSize = new Vector2(50, 75) * scale;
        Button torso = new Button(torsoPos, torsoSize, parts["Torso"].color, Color.Red, "", new SelectBodypart("Torso", this));
        torso.Update();
        torso.draw();

        //left arm
        Vector2 leftArmPos = topLeft + new Vector2(0, 50 + 5) * scale;
        Vector2 leftArmSize = new Vector2(20, 75) * scale;
        Button leftArm = new Button(leftArmPos, leftArmSize, parts["LeftArm"].color, Color.Red, "", new SelectBodypart("LeftArm", this));
        leftArm.Update();
        leftArm.draw();

        //right arm
        Vector2 rightArmPos = topLeft + new Vector2(75 + 5, 50 + 5) * scale;
        Vector2 rightArmSize = new Vector2(20, 75) * scale;
        Button rightArm = new Button(rightArmPos, rightArmSize, parts["RightArm"].color, Color.Red, "", new SelectBodypart("RightArm", this));
        rightArm.Update();
        rightArm.draw();

        //left leg
        Vector2 leftLegPos = topLeft + new Vector2(20 + 5, 130 + 5) * scale;
        Vector2 leftLegSize = new Vector2(20, 75) * scale;
        Button leftLeg = new Button(leftLegPos, leftLegSize, parts["LeftLeg"].color, Color.Red, "", new SelectBodypart("LeftLeg", this));
        leftLeg.Update();
        leftLeg.draw();

        //right leg
        Vector2 rightLegPos = topLeft + new Vector2(50 + 5, 130 + 5) * scale;
        Vector2 rightLegSize = new Vector2(20, 75) * scale;
        Button rightLeg = new Button(rightLegPos, rightLegSize, parts["RightLeg"].color, Color.Red, "", new SelectBodypart("RightLeg", this));
        rightLeg.Update();
        rightLeg.draw();


        Raylib.DrawText(name, (int)topLeft.X, (int)topLeft.Y, 20, Color.White);
    }
    public class SelectBodypart : Trigger
    {
        string part;
        Monster target;
        public SelectBodypart(string part, Monster target)
        {
            this.part = part;
            this.target = target;
        }

        public override void Use()
        {
            target.selectedBodypart = part;
            Console.WriteLine("Select");
        }
    }
}
