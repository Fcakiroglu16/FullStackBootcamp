using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAndDelegate.App
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoryRepository
    {
        public event EventHandler<int>? ThresholdCategoryCountEvent;

        private readonly List<Category> _categoryList = [new Category() { Id = 1, Name = "kalem 1" }];


        private int thresholdCategoryCount = 10;

        public void SetThresholdCategoryCount(int count)
        {
            this.thresholdCategoryCount = count;
        }

        public void Add(Category category)
        {
            _categoryList.Add(category);

            if (_categoryList.Count > thresholdCategoryCount)
            {
                ThresholdCategoryCountEvent?.Invoke(this, _categoryList.Count);
            }
        }

        public int GetCount() => _categoryList.Count;
    }
}