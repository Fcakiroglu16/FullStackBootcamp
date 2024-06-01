namespace FullStackBootcamp.App.OOPConcepts.Encapsulation
{
    internal class Tax
    {
        private List<int> Numbers { get; set; } = new List<int>() { 1, 2, 3, 4, 5 };

        public List<int> GetNumbers()
        {
            //return Numbers;
            var numbers = new int[Numbers.Count];
            Numbers.CopyTo(numbers.ToArray());
            return numbers.ToList();
        }

        public void WriteToConsole()
        {
            foreach (var item in Numbers)
            {
                Console.WriteLine(item);
            }
        }


        public string BarcodeCode { get; private set; } = "Abc";
        public string BarcodeCode2 => "DEF";

        private string TaxName { get; set; } = "Tax1";


        public string GetTaxName()
        {
            return TaxName.ToLower();
        }

        public void SetTaxName(string taxName)
        {
            if (TaxName.Length > 5)
            {
                throw new Exception("");
            }

            TaxName = taxName;
        }


        private int _taxRate;

        public int TaxRate
        {
            get => _taxRate;

            set
            {
                if (value <= 1 || value >= 10)
                {
                    throw new Exception("Tax rate must be between 1 and 10");
                }

                _taxRate = value;
            }
        }

        public void SaveToDatabase()
        {
            BarcodeCode = "dsfdsf";

            //save to database
        }

        public void Method1()
        {
            _taxRate = 20;
        }

        public void Method2()
        {
            Method3();
        }

        private void Method3()
        {
        }
    }
}