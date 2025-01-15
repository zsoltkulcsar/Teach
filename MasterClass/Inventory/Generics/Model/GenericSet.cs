namespace Inventory.Generics.Model
{
    public class GenericSet<T>
    {
        private readonly ICollection<T> _collection;
        private readonly ISetOperationValidator<T> _validator;

        public GenericSet(ISetOperationValidator<T> validator)
        {
            _collection = new HashSet<T>();  // You can choose the underlying collection type (HashSet, List, etc.)
            _validator = validator;
        }

        public bool Add(T element)
        {
            if (_validator.ValidateAdd(element, _collection))
            {
                _collection.Add(element);
                return true;
            }
            return false;
        }

        public bool Remove(T element)
        {
            if (_validator.ValidateRemove(element, _collection))
            {
                _collection.Remove(element);
                return true;
            }
            return false;
        }

        public bool Contains(T element)
        {
            return _validator.ValidateContains(element, _collection);
        }

        public void Display()
        {
            Console.WriteLine("Elements in the collection:");
            foreach (var item in _collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
