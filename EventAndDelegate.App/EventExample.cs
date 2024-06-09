using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndDelegate.App.Event
{
    public class Person
    {
        public delegate void ProfilePictureChangedDelegate(string pictureUrl);

        public event ProfilePictureChangedDelegate? ProfilePictureChanged;


        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;


        private string? _profilePictureUrl;

        public string? ProfilePictureUrl
        {
            get => _profilePictureUrl;
            set
            {
                if (value is not null)
                {
                    _profilePictureUrl = value;
                    ProfilePictureChanged?.Invoke(value);
                }
            }
        }
    }


    public class Product
    {
        public delegate void StockCountDelegate(int stock);

        public event StockCountDelegate StockCountEvent;
        public int StockCount { get; set; } = 20;
        private int _stock;

        public int Stock
        {
            get { return _stock; }
            set
            {
                if (value > StockCount)
                {
                    //fire
                    StockCountEvent.Invoke(value);
                    //throw new Exception("Stock is not enough");
                }

                _stock = value;
            }
        }
    }
}