namespace P
{
    public class Consequence
    {
        public enum MEMBERS {A, B, O };
        private int n;
        private MEMBERS[] con;

        private bool CheckLen()
        {
            return n % 2 == 0 && n <=10;
        }
        private bool CheckABCount()
        {
            int aCount = 0, bCount = 0;
            for(int i = 0; i < n; i++)
            {
                if (con[i] == MEMBERS.A)
                    aCount++;
                if (con[i] == MEMBERS.B)
                    bCount++;
            }
            return aCount == bCount;
        }
        private bool CheckEmpty()
        {
            for(int i = 0; i<n; i++)
            {
                if (i == n-1)
                {
                    return false;
                }
                if (con[i] == MEMBERS.O && con[i + 1] == MEMBERS.O)
                    return true;
            }
            return false;
        }
        private bool CheckRules()
        {
            return CheckABCount() && CheckEmpty() && CheckLen();
        }

        private int Fact(int n)
        {
            int res = 1;
            for (int i = 2; i <= n; i++)
                res *= i;
            return res;
        }
        private int C(int n, int k)
        {
            return Fact(n) / (Fact(k) * Fact(n - k));
        }

        public Consequence(int[] arr)
        {
            this.n = arr.Length;
            this.con = new MEMBERS[n] ;
            for (int i = 0; i < arr.Length; i++)
            {
                switch (arr[i])
                {
                    case 1:
                        this.con[i] = MEMBERS.A;
                        break;
                    case 2:
                        this.con[i] = MEMBERS.B;
                        break;
                    default:
                        this.con[i] = MEMBERS.O;
                        break;
                }
            }
            if (!CheckRules())
                throw new ArgumentException("Input Consequence wasn't in correct format");
        }

        public Consequence(MEMBERS[] con)
        {
            this.n = con.Length;
            this.con = con;
            if (!CheckRules())
                throw new ArgumentException("Input Consequence wasn't in correct format");
        }

        public bool CheckIfWinState()
        {
            int As = (n >> 1) -1 ;
            foreach (MEMBERS elem in con)
            {
                if (elem != MEMBERS.O)
                {
                    As--;
                    if (elem == MEMBERS.B && As > 0)
                        return false;
                }

            }
            return true;

        }

        public (int[][], int[][]) GenAandB ()
        {
            int amountOfZeroPositions = n - 1;
            int amonuOfCombos = C(n - 2, n/2 - 1);
            int[][] A = new int[amountOfZeroPositions][];
            int[][] H = new int[amountOfZeroPositions][];

            for (int p = 0; p < amountOfZeroPositions; p++)
            {
                A[p] = new int[amountOfZeroPositions];
                H[p] = new int[amountOfZeroPositions];
                for (int k = 0; k < amonuOfCombos; k++)
                {
                    if()
                }
            }

            return (A, H);
        }

        public void Print()
        {
            foreach(MEMBERS elem in con)
            {
                Console.Write(elem.ToString() + " ");
            }
        }
    }

    class P
    {
        static void Main()
        {
            int[] myCon = {0,0,1,1,2,2 };
            Consequence con = new(myCon);
            con.Print();

        }
    }
}