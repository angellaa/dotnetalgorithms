using System.Numerics;

namespace BearPermutations2
{
    public class BearPermutations2
    {
        private BigInteger[] sum;
        private BigInteger[] f;
        private BigInteger[,] c;

        public int GetSum(int n, int mod)
        {
            PrecomputeFactorials(n, mod);
            PrecomputeCombinations(n);
            ComputeSums(n);

            return (int)(sum[n] % mod);
        }

        private void PrecomputeFactorials(int n, int mod)
        {
            f = new BigInteger[n + 1];

            f[0] = 1;
            for (var i = 1; i <= n; i++)
            {
                f[i] = (f[i - 1] * i) % mod;
            }
        }

        private void PrecomputeCombinations(int n)
        {
            c = new BigInteger[n + 1, n + 1];

            for (var i = 0; i <= n; i++)
            {
                c[i, 0] = 1;
                for (var j = 1; j <= i; j++)
                {
                    c[i, j] = c[i - 1, j - 1] + c[i - 1, j];
                }
            }
        }

        private void ComputeSums(int n)
        {
            sum = new BigInteger[n + 1];

            for (var i = 0; i <= n; i++)
            {
                sum[i] = GetSumInternal(i);
            }
        }

        private BigInteger GetSumInternal(int n)
        {
            BigInteger result = 0;
            for (var minIndex = 0; minIndex < n; minIndex++)
            {
                result += c[n - 1, minIndex] * GetSumWithFixedMin(n, minIndex);
            }

            return result;
        }

        private BigInteger GetSumWithFixedMin(int n, int minIndex)
        {
            return GetSumForLeftSubtrees(n, minIndex) + 
                   GetSumForRightSubtrees(n, minIndex) +
                   GetSumForRoot(n, minIndex);
        }

        private BigInteger GetSumForLeftSubtrees(int n, int minIndex)
        {
            return sum[minIndex] * f[n - 1 - minIndex];
        }

        private BigInteger GetSumForRightSubtrees(int n, int minIndex)
        {
            return sum[n - 1 - minIndex] * f[minIndex];
        }

        private BigInteger GetSumForRoot(int n, int minIndex)
        {
            BigInteger result = 0;

            for (var i = 0; i < minIndex; i++)
            {
                for (var j = minIndex + 1; j < n; j++)
                {
                    var rootScore = j - i;
                    var leftCombs = (minIndex - 1 >= 0) ? f[minIndex - 1] : 1;
                    var rightCombs = (n - minIndex - 2 >= 0) ? f[n - minIndex - 2] : 1;

                    result += rootScore * leftCombs * rightCombs;
                }
            }

            return result;
        }
    }
}