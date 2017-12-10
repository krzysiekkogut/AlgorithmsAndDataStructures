using System;
using System.Collections.Generic;
using Implementations.Helpers;

namespace Implementations.DataStructures
{
    public class List<T>
    {
        public List() { }

        public List(IEnumerable<T> collection)
        {
            if (!collection.Empty())
            {
                ConvertCollectionToList(collection);
            }
        }

        private void ConvertCollectionToList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                AddLast(item);
            }
        }

        public IEnumerable<T> ToEnumerable()
        {
            var current = First;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public int Count { get; set; }

        public ListNode<T> First { get; set; }

        public ListNode<T> Last { get; set; }

        public void AddFirst(T item)
        {
            if (First == null)
            {
                First = Last = new ListNode<T>(item, this);
            }
            else
            {
                First.Previous = new ListNode<T>(item, this);
                First.Previous.Next = First;
                First = First.Previous;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            if (Last == null)
            {
                First = Last = new ListNode<T>(item, this);
            }
            else
            {
                Last.Next = new ListNode<T>(item, this);
                Last.Next.Previous = Last;
                Last = Last.Next;
            }

            Count++;
        }

        public void AddAfter(ListNode<T> node, T item)
        {
            if (node == null)
            {
                throw new ArgumentException("Nodes cannot be null.");
            }

            if (Last.Equals(node))
            {
                AddLast(item);
            }
            else
            {
                var newNode = new ListNode<T>(item, this);
                newNode.Previous = node;
                newNode.Next = node.Next;
                node.Next.Previous = newNode;
                node.Next = newNode;

                Count++;
            }
        }

        public void AddBefore(ListNode<T> node, T item)
        {
            if (node == null)
            {
                throw new ArgumentException("Nodes cannot be null.");
            }

            if (First.Equals(node))
            {
                AddFirst(item);
            }
            else
            {
                var newNode = new ListNode<T>(item, this);
                newNode.Previous = node.Previous;
                newNode.Next = node;
                node.Previous.Next = newNode;
                node.Previous = newNode;

                Count++;
            }
        }

        public void Clear()
        {
            while (Count != 0)
            {
                RemoveLast();
            }
        }

        public bool Remove(T item)
        {
            var node = Find(item);
            if (node == null)
            {
                return false;
            }

            Remove(node);
            return true;
        }

        public void Remove(ListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentException("Node to delete cannot be null.");
            }

            if (!this.Equals(node.List))
            {
                throw new ArgumentException("Node to delete must be from the list, on which operation was invoked.");
            }

            if (First.Equals(node))
            {
                RemoveFirst();
            }
            else if (Last.Equals(node))
            {
                RemoveLast();
            }
            else
            {
                RemoveElement(node);
            }
        }

        public void RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            if (Count == 1)
            {
                RemoveOnlyElement();
            }
            else
            {
                RemoveFirstElement();
            }
        }

        public void RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            if (Count == 1)
            {
                RemoveOnlyElement();
            }
            else
            {
                RemoveLastElement();
            }
        }

        private void RemoveElement(ListNode<T> node)
        {
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
            Count--;
        }

        private void RemoveOnlyElement()
        {
            First = Last = null;
            Count--;
        }

        private void RemoveFirstElement()
        {
            First.Next.Previous = null;
            First = First.Next;
            Count--;
        }

        private void RemoveLastElement()
        {
            Last.Previous.Next = null;
            Last = Last.Previous;
            Count--;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public ListNode<T> Find(T item)
        {
            var current = First;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    break;
                }

                current = current.Next;
            }

            return current;
        }
    }
}
