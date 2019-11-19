using System;

namespace Labb2
{
    //Denna klass skall representera en position i ett tvådimensionellt koordinatsystem, alltså ett par av en x•koordinat och en y•koordinat
    public class Position
    {
        private int x;
        private int y;

        //En position skall ha två stycken properties: X•värdet, Y•värdet. Bägge dessa properties ska kunna förändras, men får aldrig bli negativa.
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value >= 0 ? value : value * -1;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value >= 0 ? value : value * -1;
            }
        }

        //returnera avståndet från origo (koordinaten (0, 0)) till den här punkten
        public double Length()
        {
            var distanceFromOrigo = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            return distanceFromOrigo;
        }

        //konstruktor som tar emot ett x-värde och ett y-värde och lagrar dem sedan i lämpliga properties
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        //returnera true om den givna positionen är samma som den här ■ Annars skall den returnera false. Två punkter räknas som lika om både X•koordinaten och Y•koordinaten är lika
        public bool Equals(Position p)
        {
            if (p.X.Equals(X) && p.Y.Equals(Y))
            {
                return true;
            }
            return false;
        }

        //returnera en ny instans av Position, som har samma X och Y•värden som den nuvarande punkten
        public Position Clone()
        {
            var clone = new Position(x, y);
            return clone;
        }

        //returnera en string i följande format: (X, Y)
        public override string ToString()
        {
            return $"({x},{y})";
        }

        //Skall jämföra 2 positioners avstånd från origo. p1.length>p2.length. Returnerar true om p1 ligger längst ifrånorigoReturnerar false annarsOm positionerna har samma längd från origo:Skall x•variablen jämföras istället
        public static bool operator >(Position p1, Position p2)
        {

            if (p1.Length() > p2.Length())
            {
                return true;
            }

            if (p1.Length().Equals(p2.Length()))
            { 
                if (p1.X > p2.X)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator <(Position p1, Position p2)
        {
            if (p1.Length() < p2.Length())
            {
                return true;
            }

            if (p1.Length().Equals(p2.Length()))
            {
                if (p1.X < p2.X)
                {
                    return true;
                }
            }
            return false;
        }

        //Addera 2 punkter med varandra och returnerar en ny position
        public static Position operator +(Position p1, Position p2)
        {
            return new Position(p1.X + p2.X, p1.Y + p2.Y);
        }

        //Subtrahera 2 punkter med varandra och returnerar en ny position
        public static Position operator -(Position p1, Position p2)
        {
            return new Position(p1.X - p2.X, p1.Y - p2.Y);
        }

        //Räkna ut avståndet mellan två punkter och returnera double
        public static double operator %(Position p1, Position p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }      
    }
}