using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackBootcamp.App
{
    internal class Loop
    {
        // loop example
        public void LoopExample(int type)
        {
            int ii = 10;


            while (ii < 10)
            {
                ii++;
            }

            // do while
            do
            {
                ii++;
            } while (ii < 10);


            for (int i = 0; i < 10; i++)
            {
                if (type == 1)
                {
                    Console.WriteLine(i);
                    continue;
                }

                if (type == 2)
                {
                    Console.WriteLine(i);
                    continue;
                }

                if (type == 3)
                {
                    Console.WriteLine(i);
                    continue;
                }

                Console.WriteLine(i);

                //if (type == 1)
                //{

                //}
                //else if (type == 2)
                //{

                //}
                //else
                //{

                //}
            }


            //foreach
        }
    }
}