using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelter
{
    public class Cats
    {
        public string catName { get; set; }
        public string catBreed { get; set; }
        public string catAge { get; set; }
        public string catDominateColor { get; set; }
        public string catSize { get; set; }

        public Cats()
        {

        }

        public Cats(string catName, string catBreed, string catAge, string catDominateColor, string catSize)
        {
            this.catName = catName;
            this.catBreed = catBreed;
            this.catAge = catAge;
            this.catDominateColor = catDominateColor;
            this.catSize = catSize;
        }

        public Cats(Cats cats)
        {
            this.catName=cats.catName;
            this.catBreed=cats.catBreed;
            this.catAge=cats.catAge;
            this.catDominateColor=cats.catDominateColor;
            this.catSize=cats.catSize;
        }
    }
}
