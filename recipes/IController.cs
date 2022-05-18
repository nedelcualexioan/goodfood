using System;

namespace recipes
{
    public interface IController
    {

        int Count
        {
            get;
        }
        void Add(Object obj);

        Object GetItem(int index);

        String ToString();

        void Read();

        void Save();
    }
}