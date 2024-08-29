using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6to8
{
    public class MyList<T>
    {
        private T[] _buffer;
        private int _size;
        private int _count;
        public MyList()
        {
            _size = 100;
            _buffer = new T[_size];
            _count = 0;
        }

        public MyList(int capacity)
        {
            _size = capacity;
            _buffer = new T[_size];
            _count = 0;
        }
        public T this[int index] 
        { 
            get => index < _count && index >= 0 ? _buffer[index] : throw new IndexOutOfRangeException();
            set 
            {
                if (index < _count && index >= 0) _buffer[index] = value;
                else throw new IndexOutOfRangeException(); 
            }
        }

        public int Count => _count;

        public void Add(T item)
        {
            if (_count >= _size)
            {
                _size *= 2;
                T[] temp = new T[_size];
                Array.Copy(_buffer, temp, _count);
                _buffer = temp;
                _buffer[_count] = item;
            }
            _buffer[_count++] = item;
        }

        public void Clear()
        {
            _size = 100;
            _buffer = new T[_size];
            _count = 0;
        }

        public bool Contains(T item)
        {
            return _buffer.Contains(item);
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(_buffer, item);
        }

        public void Insert(int index, T item)
        {
            _count++;
            if (_size <= _count)
            {
                _size *= 2;
                T[] temp = new T[_size];
                Array.Copy(_buffer, temp, _count);
                _buffer = temp;
            }
            for (int i = _count; i > index; i--)
            {
                _buffer[i] = _buffer[i - 1];
            }
            _buffer[index] = item;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1) return false;
            RemoveAt(index);
            return true;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < _count; i++)
            {
                _buffer[i] = _buffer[i + 1];
            }
            _count--;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append("[");
            for (int i = 0; i < _count; i++)
            {
                sb.Append(_buffer[i] + " ");
            }
            sb.Append(']');
            return sb.ToString() ;
        }
    }
}
