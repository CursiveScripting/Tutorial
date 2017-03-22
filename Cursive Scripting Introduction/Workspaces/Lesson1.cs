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
    public class Lesson1 : Workspace
    {
        public static Lazy<Lesson1> Instance { get; } = new Lazy<Lesson1>(() => new Lesson1());
        public static string InitialTemplate { get; } = @"<Processes><Process name=""draw""><Description>Instructs a turtle to draw stuff</Description><Steps><Start ID=""1"" x=""71"" y=""64""><ReturnPath targetStepID=""3""/></Start><Stop ID=""2"" x=""864"" y=""302""/><Step process=""start drawing"" ID=""3"" x=""298"" y=""64.484375""><ReturnPath targetStepID=""4""/></Step><Step process=""move forward"" ID=""4"" x=""476"" y=""64.484375""><ReturnPath targetStepID=""5""/></Step><Step process=""move forward"" ID=""5"" x=""668"" y=""64.484375""><ReturnPath targetStepID=""6""/></Step><Step process=""turn right"" ID=""6"" x=""864"" y=""65.484375""><ReturnPath targetStepID=""7""/></Step><Step process=""move forward"" ID=""7"" x=""865"" y=""186.484375""><ReturnPath targetStepID=""8""/></Step><Step process=""turn right"" ID=""8"" x=""669"" y=""186.484375""><ReturnPath targetStepID=""9""/></Step><Step process=""move forward"" ID=""9"" x=""480"" y=""185.484375""><ReturnPath targetStepID=""10""/></Step><Step process=""move forward"" ID=""10"" x=""299"" y=""186.484375""><ReturnPath targetStepID=""11""/></Step><Step process=""turn left"" ID=""11"" x=""108"" y=""186.484375""><ReturnPath targetStepID=""14""/></Step><Step process=""move forward"" ID=""12"" x=""482"" y=""302.484375""><ReturnPath targetStepID=""13""/></Step><Step process=""move forward"" ID=""13"" x=""684"" y=""302.484375""><ReturnPath targetStepID=""2""/></Step><Step process=""move forward"" ID=""14"" x=""109"" y=""302.25""><ReturnPath targetStepID=""15""/></Step><Step process=""turn left"" ID=""15"" x=""290"" y=""302.25""><ReturnPath targetStepID=""12""/></Step></Steps></Process></Processes>";
        
        public static Turtle Turtle { get; set; }

        public Lesson1()
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
                            Turtle.Y++; break;
                        case Turtle.Direction.Right:
                            Turtle.X++; break;
                    }
                    return null;
                },
                "Advances the turtle one step in the direction that it is facing",
                null,
                null,
                null,
                null
            );
        }
    }
}