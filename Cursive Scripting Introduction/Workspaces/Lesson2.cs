using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Cursive;
using Cursive_Scripting_Introduction.Models;

namespace Cursive_Scripting_Introduction.Workspaces
{
    public class Lesson2 : Workspace
    {
        public static Lazy<Lesson2> Instance { get; } = new Lazy<Lesson2>(() => new Lesson2());
        public static string InitialTemplate { get; } = @"";
        
        public static Turtle Turtle { get; set; }

        public Lesson2()
        {
            AddSystemProcess("start drawing", StartDrawing());
            AddSystemProcess("stop drawing", StopDrawing());
            AddSystemProcess("turn left", TurnLeft());
            AddSystemProcess("turn right", TurnRight());
            AddSystemProcess("move forward", MoveForward());

            AddRequiredProcess("draw", ProcessFile());
        }
        
        private static RequiredProcess ProcessFile()
        {
            return new RequiredProcess("Instructs a turtle to draw stuff",
                null,
                null,
                null
            );
        }

        private static SystemProcess StartDrawing()
        {
            return new SystemProcess(
                (ValueSet inputs, out ValueSet outputs) =>
                {
                    outputs = null;
                    Turtle.Drawing = true;
                    return null;
                },
                "Instructs the turtle to start drawing",
                null,
                null,
                null,
                null
            );
        }

        private static SystemProcess StopDrawing()
        {
            return new SystemProcess(
                (ValueSet inputs, out ValueSet outputs) =>
                {
                    outputs = null;
                    Turtle.Drawing = false;
                    return null;
                },
                "Instructs the turtle to stop drawing",
                null,
                null,
                null,
                null
            );
        }

        private static SystemProcess TurnLeft()
        {
            return new SystemProcess(
                (ValueSet inputs, out ValueSet outputs) =>
                {
                    outputs = null;
                    switch (Turtle.Facing)
                    {
                        case Turtle.Direction.Up:
                            Turtle.Facing = Turtle.Direction.Left; break;
                        case Turtle.Direction.Left:
                            Turtle.Facing = Turtle.Direction.Down; break;
                        case Turtle.Direction.Down:
                            Turtle.Facing = Turtle.Direction.Right; break;
                        case Turtle.Direction.Right:
                            Turtle.Facing = Turtle.Direction.Up; break;
                    }
                    return null;
                },
                "Turns the turtle left 90 degrees",
                null,
                null,
                null,
                null
            );
        }

        private static SystemProcess TurnRight()
        {
            return new SystemProcess(
                (ValueSet inputs, out ValueSet outputs) =>
                {
                    outputs = null;
                    switch (Turtle.Facing)
                    {
                        case Turtle.Direction.Up:
                            Turtle.Facing = Turtle.Direction.Right; break;
                        case Turtle.Direction.Left:
                            Turtle.Facing = Turtle.Direction.Up; break;
                        case Turtle.Direction.Down:
                            Turtle.Facing = Turtle.Direction.Left; break;
                        case Turtle.Direction.Right:
                            Turtle.Facing = Turtle.Direction.Down; break;
                    }
                    return null;
                },
                "Turns the turtle right 90 degrees",
                null,
                null,
                null,
                null
            );
        }

        private static SystemProcess MoveForward()
        {
            return new SystemProcess(
                (ValueSet inputs, out ValueSet outputs) =>
                {
                    outputs = null;
                    switch (Turtle.Facing)
                    {
                        case Turtle.Direction.Up:
                            Turtle.Y--; break;
                        case Turtle.Direction.Left:
                            Turtle.X--; break;
                        case Turtle.Direction.Down:
                            return "blocked";//Turtle.Y++; break;
                        case Turtle.Direction.Right:
                            Turtle.X++; break;
                    }
                    return "ok";
                },
                "If there is space, advances the turtle one step in the direction that it is facing and returns \"ok\". If there is no space, return \"blocked\".",
                null,
                null,
                new string[] { "ok", "blocked" },
                null
            );
        }
    }
}