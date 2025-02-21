namespace _08Threeuple
{
    public class CustomThreeuple<T1, T2, T3>
    {
        private T1 _firstElement;
        private T2 _secondElement;
        private T3 _thirdElement;


        public CustomThreeuple(T1 firstElement, T2 secondElement, T3 thirdElement)
        {
            _firstElement = firstElement;
            _secondElement = secondElement;
            _thirdElement = thirdElement;
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

        public T3 Item3
        {
            get
            {
                return _thirdElement;
            }
            set
            {
                _thirdElement = value;
            }
        }

        public override string ToString()
        {
            return $"{Item1} -> {Item2} -> {Item3}";
        }
    }
}
