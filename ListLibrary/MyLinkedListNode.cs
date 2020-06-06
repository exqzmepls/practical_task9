namespace ListLibrary
{
    public class MyLinkedListNode<T>
    {
        // Поле для хранения данных
        internal T data;

        // Ссылка на следующий элемент
        internal MyLinkedListNode<T> next = null;

        // Ссылка на предыдущий эжлемент
        internal MyLinkedListNode<T> previous = null;

        // Список, к. принадлежит элемент
        internal MyLinkedList<T> owner = null;

        // Конструктор с заданным значением
        public MyLinkedListNode(T value = default)
        {
            data = value;
        }

        // Ссылка на следующий элемент
        public MyLinkedListNode<T> Next
        {
            get 
            {
                if (!(owner is null) && owner.Last.Equals(this)) return owner.First;
                return next; 
            }
        }

        // Ссылка на предыдущий эжлемент
        public MyLinkedListNode<T> Previous
        {
            get
            {
                if (!(owner is null) && owner.First.Equals(this)) return owner.Last;
                return previous;
            }
        }

        // Получение/изменение данных
        public T Value
        {
            get { return data; }
            set { data = value; }
        }

        /*public override bool Equals(object obj)
        {
            return obj is MyLinkedListNode<T> node && node.owner == owner && node.next == next && node.previous == previous && node.Value.Equals(Value);
        }*/

        // Преобразование в строку
        public override string ToString()
        {
            return data.ToString();
        }
    }
}