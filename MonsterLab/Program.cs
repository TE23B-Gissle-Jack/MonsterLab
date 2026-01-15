using System.Numerics;
using MonsterLab;
using Raylib_cs;

//makes the window called "Slap" with a target fps of 60
Raylib.InitWindow(1500, 1000, "Frank");
Raylib.SetTargetFPS(60);
Raylib.SetExitKey(KeyboardKey.Null); //Disable ESC as exit key

// Example actions just so the constructor works
PartAction[] exampleActions = new PartAction[]
{
    new PartAction("Punch", [20,10,0,0],["Head","LeftArm","RightLeg"]),
    new PartAction("Leg Sweep", [12,20,0,0],["RightLeg","LeftLeg"]),
    new PartAction("Bite",[15,45,0,0],["Head","Torso"]),
    new PartAction("Tail Whip",[10,20,0,0],["Torso","LeftLeg"]),
    new PartAction("Body Slam",[30,65,0,0],["Torso"]),
    new PartAction("Kick",[18,35,0,0],["LeftLeg","RightLeg"]),
    new PartAction("Headbutt",[25,50,0,0],["Head"]),
    new PartAction("Claw Strike",[12,25,0,0],["LeftArm","RightArm"]),
    new PartAction("First Aid",[10,0,30,0],["Torso"]),
    new PartAction("Shield Bash",[20,25,0,20],["Head","Torso"]),
    new PartAction("Guard",[5,0,0,40],["Torso","Head"])
};

//temp
PartAction[] RandomActions()
{
    PartAction[] something = new PartAction[]{
    new PartAction(exampleActions[Random.Shared.Next(exampleActions.Length)]),
    new PartAction(exampleActions[Random.Shared.Next(exampleActions.Length)])};
    return something;
}

//makes a random monster
Monster CreateMonster()
{
    Arm rightArm = new Arm("Arm", 50, RandomActions());
    Arm leftArm = new Arm("Arm", 50, RandomActions());
    Head head = new Head("Head", 900, RandomActions());
    Leg rightLeg = new Leg("Leg", 60, RandomActions());
    Leg leftLeg = new Leg("Leg", 60, RandomActions());
    Torso torso = new Torso("Torso", 120, RandomActions(), 100);
    return new Monster(head, leftArm, rightArm, leftLeg, rightLeg, torso);
}

//temp
Monster wow = CreateMonster();

Monster en = CreateMonster();

wow.Enemy = en;
en.Enemy = wow;
//////
Monster currentMonstersTurn = wow;


//the loop 👌
while (!Raylib.WindowShouldClose())
{
    Raylib.ClearBackground(Color.Black);
    Raylib.BeginDrawing();

    wow.DisplayCondition(new(100, 100), 0.7f);

    en.DisplayCondition(new(500, 100), 0.7f);

    //yup    fint
    currentMonstersTurn = currentMonstersTurn.MyTurn(currentMonstersTurn);

    Raylib.EndDrawing();
}
Console.ReadLine();