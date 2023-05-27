using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Julius.Domain.CategoryAggregate.Specifications
{
    // Criar um builder de Spec para cada propriedade
    public class CategoryByNameSpec : SingleResultSpecification<Category>
    {
        public CategoryByNameSpec(string name)
        {
            if(!string.IsNullOrEmpty(name))
                Query.Where(cat => cat.Name == name);
        }
    }

    public class CategoryByIdSpec : SingleResultSpecification<Category>
    {
        public CategoryByIdSpec(Guid id)
        {
            if (id != default)
                Query.Where(cat => cat.Id == id);
        }
    }
}
