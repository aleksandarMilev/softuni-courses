namespace _07Tuple
{
    public class CustomTuple<T1, T2>
    {
        private T1 _firstElement;
        private T2 _secondElement;


        public CustomTuple(T1 firstElement, T2 secondElement)
        {
            _firstElement = firstElement;
            _secondElement = secondElement;
        }


        public T1 Item1 
        {
            get
            {
                return _firstElement; 
            }
            set
            {
                _firstElement = value;
            }
        }

        public T2 Item2
        {
            get
            {
                return _secondElement;
            }
            set
            {
                _secondElement = value;
            }
        }

        public override string ToString()
        {
            return $"{Item1} -> {Item2}";
        }
    }
}
