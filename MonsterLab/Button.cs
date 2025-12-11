using System;
using System.Numerics;
using Raylib_cs;

namespace MonsterLab;

public class Button
{
    Vector2 position;

    Vector2 size;

    Color color;

    string text;
    Color textColor;

    int fontSize = 40;

    bool hover = false;

    Trigger theThing;

    public Button(Vector2 location, Vector2 size, Color buttonColor, Color textColor, string text, Trigger theThing)
    {
        this.position = location;
        this.size = size;
        this.color = buttonColor;
        this.textColor = textColor;
        this.text = text;
        this.theThing = theThing;
    }

    public void draw()
    {

        while (Raylib.MeasureText(text, fontSize) > size.X - 20)
        {
            fontSize--;
            if (text =="")
            {
                break;
            }
        }

        int thingie = Raylib.MeasureText(text, fontSize);
        int middleX = ((int)size.X - thingie)/2;
        int middleY = (int)position.Y + ((int)size.X / 8);

        if (hover) Raylib.DrawRectangleV(position - new Vector2(2, 2), size+new Vector2(4,4), Color.White);
        Raylib.DrawRectangleV(position, size, color);
        Raylib.DrawText(text, (int)position.X+middleX, middleY, fontSize, textColor);
    }

    public void draw(Vector2 location)
    {

        while (Raylib.MeasureText(text, fontSize) > size.X - 20)
        {
            fontSize--;
            if (text =="")
            {
                break;
            }
        }

        int thingie = Raylib.MeasureText(text, fontSize);
        int middleX = ((int)size.X - thingie)/2;
        int middleY = (int)location.Y + ((int)size.X / 8);

        if (hover) Raylib.DrawRectangleV(location - new Vector2(2, 2), size+new Vector2(4,4), Color.White);
        Raylib.DrawRectangleV(location, size, color);
        Raylib.DrawText(text, (int)location.X+middleX, middleY, fontSize, textColor);
    }


    public void Update()
    {
        bool isMouseOver = Raylib.GetMouseX() > position.X &&Raylib.GetMouseX() < position.X + size.X &&Raylib.GetMouseY() > position.Y &&Raylib.GetMouseY() < position.Y + size.Y;
        if (isMouseOver)
        {
            hover = true;
            if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                Use();
            }
        }
        else hover = false;
    }
    public void Update(Vector2 location)
    {
        bool isMouseOver = Raylib.GetMouseX() > location.X &&Raylib.GetMouseX() < location.X + size.X &&Raylib.GetMouseY() > location.Y &&Raylib.GetMouseY() < location.Y + size.Y;
        if (isMouseOver)
        {
            hover = true;
            if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                Use();
            }
        }
        else hover = false;
    }
    void Use()
    {
        theThing.Use();
        Console.WriteLine("use");
    }
}
