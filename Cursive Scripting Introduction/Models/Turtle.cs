using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cursive_Scripting_Introduction.Models
{
    public class Turtle
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool Drawing { get; set; }
        public Direction Facing { get; set; }

        public enum Direction
        {
            Up,
            Left,
            Down,
            Right,
        }
    }
}