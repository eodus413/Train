using System.Collections.Generic;

namespace ProjectCatMan
{
    public interface IInventory
    {
        List<IItem> items { get; }
        int size { get; }
        bool isFull { get; }

        IItem GetItem(int index);   //아이템 가져감
        void AddItem(IItem item);   //아이템을 가져옴
    }

    public class Box : IInventory   //필드맵 상에 존재할 박스
    {
        public Box(int size)
        {
            this._size = size;
            items = new List<IItem>();
        }

        public List<IItem> items { get; private set; }
        public readonly int _size;
        public int size { get { return _size; } }
        public bool isFull { get { return items.Count == size; } }


        public IItem GetItem(int index)
        {
            if (index < 0) return null;
            if (index >= size) return null;
            return items[index];
        }
        public void AddItem(IItem item)
        {
            if (isFull) return;    //꽉찼으면 return

            items.Add(item);
        }

    }
    public class UnitInventory : IInventory //유닛의 인벤토리
    {
        public UnitInventory(int size)
        {
            this._size = size;
            items = new List<IItem>();
        }

        public List<IItem> items { get; private set; }
        public readonly int _size;
        public int size { get { return _size; } }
        public bool isFull { get { return items.Count == size; } }


        public IItem GetItem(int index)
        {
            if (index < 0) return null;
            if (index >= size) return null;
            return items[index];
        }
        public void AddItem(IItem item)
        {
            if (isFull) return;    //꽉찼으면 return

            items.Add(item);
        }

    }
}