namespace Implementations.DataStructures
{
    public class Queue<T>
    {
        private List<T> _data;

        public Queue()
        {
            _data = new List<T>();
        }

        public int Count { get { return _data.Count; } }

        public void Enqueue(T item)
        {
            _data.AddLast(item);
        }

        public T Dequeue()
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
