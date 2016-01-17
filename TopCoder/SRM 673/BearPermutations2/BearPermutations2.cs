using System.Numerics;

namespace BearPermutations2
{
    public class BearPermutations2
    {
        private BigInteger[] sum;
        private BigInteger[] p;
        private BigInteger[,] c;

        public int GetSum(int n, int mod)
        {
            PrecomputePermutations(n, mod);
            PrecomputeCombinations(n);
            ComputeSums(n);

            return (int)(sum[n] % mod);
        }

        private void PrecomputePermutations(int n, int mod)
        {
            p = new BigInteger[n + 1];

            p[0] = 1;
            for (var i = 1; i <= n; i++)
            {
                p[i] = (p[i - 1] * i) % mod;
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
                result += GetSumWithFixedMin(n, minIndex);
            }

            return result;
        }

        private BigInteger GetSumWithFixedMin(int n, int minIndex)
        {
            return c[n - 1, minIndex] * GetSumWithFixedMinAndPartition(n, minIndex);
        }

        private BigInteger GetSumWithFixedMinAndPartition(int n, int minIndex)
        {
            return GetSumForLeftSubtrees(n, minIndex) + 
                   GetSumForRightSubtrees(n, minIndex) +
                   GetSumForRoot(n, minIndex);
        }

        private BigInteger GetSumForLeftSubtrees(int n, int minIndex)
        {
            return sum[minIndex] * p[n - 1 - minIndex];
        }

        private BigInteger GetSumForRightSubtrees(int n, int minIndex)
        {
            return sum[n - 1 - minIndex] * p[minIndex];
        }

        private BigInteger GetSumForRoot(int n, int minIndex)
        {
            BigInteger result = 0;

            for (var leftMinIndex = 0; leftMinIndex < minIndex; leftMinIndex++)
            {
                for (var rightMinIndex = minIndex + 1; rightMinIndex < n; rightMinIndex++)
                {
                    result += GetSumForRootWithFixedChildren(n, minIndex, leftMinIndex, rightMinIndex);
                }
            }

            return result;
        }

        private BigInteger GetSumForRootWithFixedChildren(int n, int minIndex, int leftMinIndex, int rightMinIndex)
        {
            var rootScore = rightMinIndex - leftMinIndex;

            var leftPermutations = (minIndex - 1 >= 0) ? p[minIndex - 1] : 1;
            var rightPermutations = (n - minIndex - 2 >= 0) ? p[n - minIndex - 2] : 1;

            var totalPermutations = leftPermutations * rightPermutations;

            return rootScore * totalPermutations;
        }
    }
}