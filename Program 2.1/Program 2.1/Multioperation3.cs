using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program_2._1
{
    public class Multioperation3
    {
        int[] _val;
        public int arity
        {
            get
            {
                return Arity(this);
            }
        }
        public Multioperation3(int[] arr)
        {
            _val = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
            {
                _val[i] = arr[i];
            }
        }
        public Multioperation3(string s)
        {
            _val = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                _val[i] = s[i] - '0';
            }
        }

        public static Multioperation3 operator *(Multioperation3 f, Multioperation3 g)
        {
            int n = f.arity, m = g.arity;
            int[] p = new int[(int)Math.Pow(3, n * m)];
            int x = 0, a, b, c;
            if (n == 1 && (m == 1 || m == 2 || m == 3))
            {
                for (int i = 0; i < g._val.Length; i++)
                {
                    if (g[i] == 0)
                        p[i] = 0;
                    else
                    {
                        if ((g[i] & 1) != 0)
                            p[i] |= f[0];
                        if ((g[i] & 2) != 0)
                            p[i] |= f[1];
                        if ((g[i] & 4) != 0)
                            p[i] |= f[2];
                    }
                }
            }
            if (n == 2 && (m == 1 || m == 2 || m == 3))
            {
                for (int i = 0; i < g._val.Length; i++)
                {
                    for (int j = 0; j < g._val.Length; j++)
                    {
                        a = g[i];
                        b = g[j];
                        for (int r = 0; r < 3; r++)
                        {
                            for (int s = 0; s < 3; s++)
                            {
                                if (((a >> r) & (b >> s) & 1) != 0)
                                {
                                    p[x] |= f[r * 3 + s];
                                }
                            }
                        }
                        x++;
                    }
                }
            }
            if (n == 3 && (m == 1 || m == 2 || m == 3))
            {
                for (int i = 0; i < g._val.Length; i++)
                {
                for (int j = 0; j < g._val.Length; j++)
                    {
                        for (int k = 0; k < g._val.Length; k++)
                        {
                            a = g[i];
                            b = g[j];
                            c = g[k];
                            for (int r = 0; r < 3; r++)
                            {
                                for (int s = 0; s < 3; s++)
                                {
                                    for (int t = 0; t < 3; t++)
                                    {
                                        if (((a >> r) & (b >> s) & (c >> t) & 1) != 0)
                                        {
                                            p[x] |= f[r * 9 + s * 3 + t]; ;
                                        }
                                    }
                                }
                            }
                            x++;
                        }
                    }
                }
            }
            return new Multioperation3(p);
        }
        public static bool operator <(Multioperation3 p, Multioperation3 t)
        {
            for (int i = 0; i < t._val.Length; i++)
            {
                if ((p[i] == 1) && (t[i] == 0 || t[i] == 2 || t[i] == 4 || t[i] == 6))
                {
                    return false;
                }
                if ((p[i] == 2) && (t[i] <= 1 || t[i] == 4 || t[i] == 5))
                {
                    return false;
                }
                if ((p[i] == 3) && (t[i] <= 2 || t[i] == 4 || t[i] == 5 || t[i] == 6))
                {
                    return false;
                }
                if ((p[i] == 4) && (t[i] <= 2 || t[i] == 3))
                {
                    return false;
                }
                if ((p[i] == 5) && (t[i] <= 4 || t[i] == 6))
                {
                    return false;
                }
                if ((p[i] == 6) && (t[i] <= 5))
                {
                    return false;
                }
                if ((p[i] == 7) && (t[i] <= 6))
                {
                    return false;
                }
            }
            return true;
        }
 public static bool operator >(Multioperation3 p, Multioperation3 t)
        {
            return false;
        }
        public static int Arity(Multioperation3 op)
        {
            switch (op._val.Length)
            {
                case 3:
                    return 1;
                case 9:
                    return 2;
                case 27:
                    return 3;
                default:
                    return 0;
            }
        }
        public int this[int i] { get { return _val[i]; } }
        public override string ToString()
        {
            string res = "(";
            for (int i = 0; i < _val.Length; i++)
            {
                res += _val[i].ToString();
            }
            res += ")";
            return res;
        }
    }
}