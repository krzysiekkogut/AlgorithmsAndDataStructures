namespace Implementations.DataStructures
{
    public class Stack<T>
    {
        private List<T> _data;

        public Stack()
        {
            _data = new List<T>();
        }

        public int Count => _data.Count;

        public void Push(T item)
        {
            _data.AddFirst(item);
        }

        public T Pop()
        {
            var result = _data.First;
            _data.RemoveFirst();
            return result.Value;
        }

        public void Clear()
        {
            _data.Clear();
        }
    }
}
