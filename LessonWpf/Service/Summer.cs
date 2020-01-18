namespace LessonWpf.Service
{
    public class Summer
    {
        public Summer()
        {
        }
        public int Sum(params int[] a)
        {
            int res = 0;
            foreach (int b in a) {
                res += b;
            }

            return res;
        }
    }
}