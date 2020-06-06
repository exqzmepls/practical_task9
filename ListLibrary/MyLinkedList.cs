using System;

namespace ListLibrary
{
    public class MyLinkedList<T>
    {
        // Поле для ссылки на первый и последний элементы
        MyLinkedListNode<T> beg = null;
        MyLinkedListNode<T> end = null;
        // Кол-во элементов в списке
        int count = 0;

        // Конструктор без параметров (создаёт пустой список) 
        public MyLinkedList() { }

        // Конструктор с заданным начальным размером списка (создаёт список со стандартными значениями эелемнтов)
        public MyLinkedList(int size)
        {
            if (size < 0) throw new Exception("Invalid value!");
            for (int i = 0; i < size; i++) AddLast(new MyLinkedListNode<T>());
        }

        // Конструктор с заданными значениями для элементов списка
        public MyLinkedList(T[] values, bool reverse = false)
        {
            if (values == null) throw new Exception("Null reference!");
            if (reverse) for (int i = 0; i < values.Length; i++) AddFirst(values[i]);
            else for (int i = 0; i < values.Length; i++) AddLast(values[i]);
        }

        // Кол-во элементов в списке
        public int Count
        {
            get { return count; }
        }

        // Ссылка на первый элемент
        public MyLinkedListNode<T> First
        {
            get { return beg; }
        }

        // Ссылка на последний элемент
        public MyLinkedListNode<T> Last
        {
            get { return end; }
        }

        // Проверка на пустоту списка
        public bool IsEmpty
        {
            get { return beg == null; }
        }

        // Получение списка с элементами в обратном порядке (без рекурсии)
        public MyLinkedList<T> Reverse()
        {
            MyLinkedList<T> result = new MyLinkedList<T>();
            MyLinkedListNode<T> tmp = Last;
            while(tmp != null) 
            {
                result.AddLast(tmp.Value);
                tmp = tmp.previous;
            }
            return result;
        }

        // Получение списка с элементами в обратном порядке (с рекурсией)
        public static MyLinkedList<T> Reverse(MyLinkedList<T> list)
        {
            MyLinkedList<T> result = new MyLinkedList<T>();
            result.ReverseFill(list.Last);
            return result;
        }

        // Добавление в список элементов из другого списка в обратном порядке, начиная с заданного элемента
        private void ReverseFill(MyLinkedListNode<T> sourceNode)
        {
            if (sourceNode == null) return;
            AddLast(sourceNode.Value);
            ReverseFill(sourceNode.previous);
        }

        // Удаление элемента
        public void Remove(MyLinkedListNode<T> existingNode)
        {
            if (existingNode == null) throw new Exception("Null argument!");
            if (existingNode.owner != this) throw new Exception("The node does not belong to this list!");
            existingNode.owner = null;
            if (existingNode.previous == null)
            {
                beg = beg.next;
                existingNode.next.previous = existingNode.previous;
            }
            else
            {
                if (existingNode.next == null) 
                {
                    end = end.previous;
                    existingNode.previous.next = existingNode.next;
                }
                else
                {
                    existingNode.next.previous = existingNode.previous;
                    existingNode.previous.next = existingNode.next;
                }
            }
            count--;
        }

        // Удаление элемента с соответствующим значением
        public bool Remove(T value)
        {
            MyLinkedListNode<T> tmp = First;
            while (tmp != null)
            {
                if (tmp.Value.Equals(value))
                {
                    Remove(tmp);
                    return true;
                }
                tmp = tmp.next;
            }
            return false;
        }

        // Добавление нового значения после какого-либо элемента
        public void AddAfter(MyLinkedListNode<T> existingNode, T value)
        {
            AddAfter(existingNode, new MyLinkedListNode<T>(value));
        }

        // Добавление нового элемента в список после какого-либо элемента
        public void AddAfter(MyLinkedListNode<T> existingNode, MyLinkedListNode<T> newNode)
        {
            if (existingNode == null || newNode == null) throw new Exception("Null argument!");
            if (existingNode.owner != this) throw new Exception("The node does not belong to this list!");
            if (newNode.owner != null) throw new Exception("Adding node already belongs to some list!");
            newNode.owner = this;
            newNode.next = existingNode.next;
            newNode.previous = existingNode;
            existingNode.next = newNode;
            if (existingNode == end) end = newNode;
            else existingNode.next.previous = newNode;
            count++;
        }

        // Добавление нового значения перед каким-либо элементом
        public void AddBefore(MyLinkedListNode<T> existingNode, T value)
        {
            AddBefore(existingNode, new MyLinkedListNode<T>(value));
        }

        // Добавление нового элемента в список перед каким-либо элементом
        public void AddBefore(MyLinkedListNode<T> existingNode, MyLinkedListNode<T> newNode)
        {
            if (existingNode == null || newNode == null) throw new Exception("Null argument!");
            if (existingNode.owner != this) throw new Exception("The node does not belong to this list!");
            if (newNode.owner != null) throw new Exception("Adding node already belongs to some list!");
            newNode.owner = this;
            newNode.next = existingNode;
            newNode.previous = existingNode.previous;
            if (existingNode == beg) beg = newNode;
            else existingNode.previous.next = newNode;
            existingNode.previous = newNode;
            count++;
        }

        // Удаление последнего элемента
        public void RemoveLast()
        {
            Remove(Last);
        }

        // Добавление значения в конец списка
        public void AddLast(T value)
        {
            AddLast(new MyLinkedListNode<T>(value));
        }

        // Добавление элемента в конец списка
        public void AddLast(MyLinkedListNode<T> newNode)
        {
            if (IsEmpty) AddStartNode(newNode);
            else AddAfter(Last, newNode);
        }

        // Удаление первого элемента
        public void RemoveFirst()
        {
            Remove(First);
        }

        // Добавление значения в начало списка
        public void AddFirst(T value)
        {
            AddFirst(new MyLinkedListNode<T>(value));
        }

        // Добавление элемента в начало списка
        public void AddFirst(MyLinkedListNode<T> newNode)
        {
            if (IsEmpty) AddStartNode(newNode);
            else AddBefore(First, newNode);
        }

        // Проверка содержит ли список заданное значение
        public bool Contains(T value)
        {
            MyLinkedListNode<T> tmp = First;
            while (tmp != null)
            {
                if (tmp.Value.Equals(value)) return true;
                tmp = tmp.next;
            }
            return false;
        }

        // Поиск первого элемента с заданным значением
        public MyLinkedListNode<T> Find(T value)
        {
            MyLinkedListNode<T> tmp = First;
            while (tmp != null)
            {
                if (tmp.Value.Equals(value)) return tmp;
                tmp = tmp.next;
            }
            return null;
        }

        // Поиск последнего элемента с заданным значением
        public MyLinkedListNode<T> FindLast(T value)
        {
            MyLinkedListNode<T> tmp = Last;
            while (tmp != null)
            {
                if (tmp.Value.Equals(value)) return tmp;
                tmp = tmp.previous;
            }
            return null;
        }

        // Добавление элемента в пустой список
        private void AddStartNode(MyLinkedListNode<T> node)
        {
            if (node == null) throw new Exception("Null argument!");
            if (node.owner != null) throw new Exception("Adding node already belongs to some list!");
            node.owner = this;
            beg = end = node;
            count++;
        }

        // Печать списка
        public void Print(string sep = " ", string end = "\n")
        {
            if (IsEmpty)
            {
                Console.WriteLine("This list is empty.");
                return;
            }
            MyLinkedListNode<T> tmp = beg;
            while (tmp != this.end)
            {
                Console.Write(tmp.ToString() + sep);
                tmp = tmp.next;
            }
            Console.Write(tmp.ToString() + end);
        }
    }
}