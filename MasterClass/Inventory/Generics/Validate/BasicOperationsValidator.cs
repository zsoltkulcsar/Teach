namespace Inventory.Generics.Validate
{
    public class BasicOperationsValidator<T>
    {
        public bool ValidateAdd(T element, ICollection<T> collection)
        {
            if (element == null)
            {
                Console.WriteLine("Validation failed: Element is null.");
                return false;
            }

            if (element is int && (int)(object)element <= 0)
            {
                Console.WriteLine("Validation failed: Element must be a positive integer.");
                return false;
            }

            if (collection.Contains(element))
            {
                Console.WriteLine($"Validation failed: Element '{element}' already exists in the collection.");
                return false;
            }

            return true;
        }

        public bool ValidateRemove(T element, ICollection<T> collection)
        {
            if (!collection.Contains(element))
            {
                Console.WriteLine($"Validation failed: Element '{element}' does not exist in the collection.");
                return false;
            }

            var protectedElements = new List<T> { (T)(object)10, (T)(object)20 };  // Just an example
            if (protectedElements.Contains(element))
            {
                Console.WriteLine($"Validation failed: Element '{element}' is protected and cannot be removed.");
                return false;
            }

            return true;
        }

        public bool ValidateContains(T element, ICollection<T> collection)
        {
            if (!collection.Contains(element))
            {
                Console.WriteLine($"Validation failed: Element '{element}' not found in the collection.");
                return false;
            }

            if (element is int && (int)(object)element % 2 != 0)
            {
                Console.WriteLine("Validation failed: Element must be an even number.");
                return false;
            }

            return true;
        }
    }
}
