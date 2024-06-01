using Microsoft.VisualBasic.CompilerServices;

namespace FullStackBootcamp.App2
{
    internal class Pen
    {
        //field=>

        private int _height;

        public int Height
        {
            //get
            //{

            //    return _height;
            //}
            get => _height;
            //set => _height = value;
            set
            {
                if (value > 500) throw new Exception("500'den büyük olamaz");
                _height = value;
            }
        }

        public int Width { get; set; }
        public string Color { get; set; }


        public const int Tax = 20;


        //methods
        public void Write(int a, int b)
        {
            var c = a + b;


            var d = 2 + 5;


            dynamic e = a + b;


            c = c * 200;
        }


        public string Write(string a, string b) => a + b;
        //{
        //    return a + b;
        //}

        public void Write2(int a, int b, int c)
        {
        }

        public void Write(int a, int b, int c)
        {
        }
    }
}