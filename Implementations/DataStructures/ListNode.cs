namespace Implementations.DataStructures
{
    public class ListNode<T>
    {
        public ListNode(T item, List<T> list)
        {
            Value = item;
            List = list;
        }

        public List<T> List { get; set; }

        public T Value { get; set; }

        public ListNode<T> Next { get; set; }

        public ListNode<T> Previous { get; set; }
    }
}
