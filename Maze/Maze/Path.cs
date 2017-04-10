using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Path
    {
        /*private int xcor;
        private int ycor;
         */

        public queueitem qi;
        private bool traversed;
        private char cellvalue;

        /*
        public int Xcor
        {
            get
            {
                return xcor;
            }
            set
            {
                xcor = value;
            }
        }
        public int Ycor
        {
            get
            {
                return ycor;
            }
            set
            {
                ycor = value;
            }
        }
         */
          
        public bool Traversed
        {
            get
            {
                return traversed;
            }
            set
            {
                traversed = value;
            }
        }
        public char Cellvalue
        {
            get
            {
                return cellvalue;
            }
            set
            {
                cellvalue = value;
            }
        }
    }
}
