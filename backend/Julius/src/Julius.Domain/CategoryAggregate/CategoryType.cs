
using Ardalis.SmartEnum;

namespace Julius.Domain.CategoryAggregate
{
    public class CategoryType : SmartEnum<CategoryType>
    {
        public static readonly CategoryType Expense = new(nameof(Expense), 0);
        public static readonly CategoryType Income = new(nameof(Income), 1);

        protected CategoryType(string name, int value) : base(name, value) { }
    }
}
