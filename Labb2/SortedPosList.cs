using System;
using System.Collections.Generic;
using System.Linq;

namespace Labb2
{
    //en klass som skall fungera som en lista för just positioner
    public class SortedPosList
    {
        //instansvariabel. Den skall endast användas inuti klassen
        private List<Position> positions = new List<Position>();

        public SortedPosList()
        {

        }

        //Skall returnera antalet positioner vi har i vår lista
        public int Count()
        {
            return positions.Count;
        }

        //Skall lägga till en given position till vår lista
        public void Add(Position pos)
        {
            for (int i = 0; i < positions.Count; i++)
            {
                if (pos < positions[i])
                {
                    positions.Insert(i, pos);
                    return;
                }
            }
            positions.Add(pos);
        }
        
        //Skall ta bort positionen pos från listan. Returnerar true om pos fanns i listan och togs bort, och false annars.
        public bool Remove(Position pos)
        {
            for (int i = 0; i < positions.Count; i++)
            {
                if (pos.Equals(positions[i]))
                {
                    positions.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        //Skall returnera en ny instans av SortedPosList, som innehåller kopior av alla punkter som finns i den här listan
        public SortedPosList Clone()
        {
            var cloneList = new SortedPosList();
            for (int i = 0; i < positions.Count; i++)
            {
                cloneList.Add(positions[i].Clone());
            }
            return cloneList;
        }

        //returnera en ny lista(använd Clone), som innehåller alla positioner som befinner sig inom en given cirkel
        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            var circleList = Clone();
            circleList.positions = circleList.positions.Where(position => IsInCircle(position, centerPos, radius)).ToList();

            return circleList;
        }

        private bool IsInCircle(Position pos, Position centerPos, double radius)
        {
            return (Math.Pow(pos.X - centerPos.X, 2) + Math.Pow(pos.Y - centerPos.Y, 2)) < Math.Pow(radius, 2);
        }

        //returnera en ny lista (använd Clone), som är de två adderade listorna ihopslagna till en
        public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
        {
            var addList = sp1.Clone();
            for (int i = 0; i < sp2.Count(); i++)
            {
                addList.Add(sp2[i]);
            }
                return addList;
        }

        //Getter: ska hämta ett element på en given position i listan.
        public Position this[int i] => positions[i];

        public override string ToString()
        {
            return string.Join(", ", positions);
        }
    }
}

