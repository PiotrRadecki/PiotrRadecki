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
        public string catDominateColor { get; set; }
        public string catSize { get; set; }

        public Cats()
        {

        }

        public Cats(string catName, string catBreed, string catDominateColor, string catSize)
        {
            this.catName = catName;
            this.catBreed = catBreed;
            this.catDominateColor = catDominateColor;
            this.catSize = catSize;
        }

        public Cats(Cats cats)
        {
            this.catName=cats.catName;
            this.catBreed=cats.catBreed;
            this.catDominateColor=cats.catDominateColor;
            this.catSize=cats.catSize;
        }


    }
}
