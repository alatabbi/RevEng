/*
The MIT License(MIT)

Copyright(c) 2016 Ali Alatabbi

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALATABBI.Algorithms
{

    public static class Extensions
    {
        /// <summary>
        /// Extension method to compute the lexicographically least string corresponding to a given prefix(feasible) graph.
        /// </summary>
        /// <param name="prefixArray"></param>
        /// <returns></returns>
        public static  Dictionary<int, List<int>> RevEng (this int[] prefixArray)
        {
            var p = new Dictionary<int, int>();
            var x = new Dictionary<int, List<int>>();
            var posE = new Dictionary<int, List<int>>();
            var negE = new Dictionary<int, List<int>>();

            try
            {
                // initialize x,  posE  and negE;
                List<int> alpha = new List<int>();
                for (int i = 1; i <= prefixArray.Length; i++)
                {
                    x.Add(i, new List<int>());
                    p.Add(i, prefixArray[i - 1]);
                    posE.Add(i, new List<int>());
                    negE.Add(i, new List<int>());
                }
                for (int i = 1; i <= p.Count; i++)
                {
                    if (p[i] == 0)
                    {
                        if (!negE[i].Contains(1) && i != 1)
                            negE[i].Add(1);
                        if (!negE[1].Contains(i))
                            negE[1].Add(i);
                    }
                    else
                    {
                        if (p[i] + i <= p.Count)
                        {
                            if (!negE[p[i] + 1].Contains(p[i] + i) && p[i] + i != p[i] + 1)
                                negE[p[i] + 1].Add(p[i] + i);
                            if (!negE[p[i] + i].Contains(p[i] + 1) && p[i] + i != p[i] + 1)
                                negE[p[i] + i].Add(p[i] + 1);
                        }
                    }

                    for (int j = 1; j <= p[i]; j++)
                    {
                        if (!posE[j].Contains(j + i - 1) && j != j + i - 1)
                            posE[j].Add(j + i - 1);
                        if (!posE[j + i - 1].Contains(j) && j != j + i - 1)
                            posE[j + i - 1].Add(j);
                    }
                }
                alpha.Add(alpha.Count + 1);

                // algorithm start
                for (int i = 1; i <= p.Count; i++)
                {
                    if (posE[i].Count != 0)
                    {
                        foreach (int j in posE[i])
                        {
                            List<int> cross1 = posE[i].Intersect(negE[j]).ToList();
                            List<int> cross2 = negE[i].Intersect(posE[j]).ToList();
                            int[] cross = cross1.Union(cross2).ToArray();
                            int[] ccc = negE[i].Union(negE[j]).Union(cross).ToArray();
                            if (ccc.Length == 0)
                            {
                                if (!x[i].Contains(alpha[alpha.Count - 1]))
                                    x[i].Add(alpha[alpha.Count - 1]);
                                if (!x[j].Contains(alpha[alpha.Count - 1]))
                                    x[j].Add(alpha[alpha.Count - 1]);
                            }
                            else
                            {
                                bool canUseA = true;
                                int A = 0;
                                foreach (int a in alpha)
                                {
                                    foreach (int c in ccc)
                                    {
                                        if (x[c].Contains(a))
                                        {
                                            canUseA = false;
                                            break;
                                        }
                                        else
                                        {
                                            A = a;
                                            canUseA = true;
                                        }
                                    }
                                    if (canUseA)
                                        break;
                                }

                                if (canUseA)
                                {
                                    if (!x[i].Contains(A))
                                        x[i].Add(A);
                                    if (!x[j].Contains(A))
                                        x[j].Add(A);
                                }
                                else
                                {
                                    alpha.Add(alpha.Count + 1);
                                    if (!x[i].Contains(alpha[alpha.Count - 1]))
                                        x[i].Add(alpha[alpha.Count - 1]);
                                    if (!x[j].Contains(alpha[alpha.Count - 1]))
                                        x[j].Add(alpha[alpha.Count - 1]);
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (int j in negE[i])
                        {
                            if (x[i].Count > 0)
                                break;
                            List<int> cross1 = posE[i].Intersect(negE[j]).ToList();
                            List<int> cross2 = negE[i].Intersect(posE[j]).ToList();
                            int[] cross = cross1.Union(cross2).ToArray();
                            int[] ccc = negE[i].Union(negE[j]).Union(cross).ToArray();
                            if (ccc.Length > 0)
                            {
                                bool canUseA = true;
                                int A = 0;
                                foreach (int a in alpha)
                                {
                                    foreach (int c in ccc)
                                    {
                                        if (x[c].Contains(a))
                                        {
                                            canUseA = false;
                                            break;
                                        }
                                        else
                                        {
                                            A = a;
                                            canUseA = true;
                                        }
                                    }
                                    if (canUseA)
                                        break;
                                }
                                if (canUseA)
                                {
                                    if (!x[i].Contains(A))
                                        x[i].Add(A);
                                }
                                else
                                {
                                    alpha.Add(alpha.Count + 1);
                                    if (!x[i].Contains(alpha[alpha.Count - 1]))
                                        x[i].Add(alpha[alpha.Count - 1]);
                                }
                            }
                        }
                    }
                }

                return x;
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                return x;
            }
        }
    }
}
