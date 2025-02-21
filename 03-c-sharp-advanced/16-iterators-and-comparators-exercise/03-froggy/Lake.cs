using System.Collections;

namespace _04Froggy
{
    public class Lake : IEnumerable<int>
    {
        private int[] _stones;


        public Lake(params int[] stones)
        {
            _stones = stones;   
        }


        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < _stones.Length; i++)
            {
                if (i % 2 == 0)
                {
                    yield return _stones[i];
                }
            }

            for (int i = _stones.Length - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return _stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
