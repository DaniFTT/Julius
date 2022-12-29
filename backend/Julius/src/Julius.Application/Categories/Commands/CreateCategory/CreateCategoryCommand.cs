using Julius.Domain.CategoryAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Julius.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand
    {
        public string Name { get; set; }
        public CategoryType Type { get; set; }
    }
}
