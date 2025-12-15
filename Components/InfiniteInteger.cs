using System;
using System.Collections.Generic;
using System.Text;

namespace DusanRodina.SimStudio.Components {
	public class InfiniteInteger
    {
        private bool positive = true;

        // Poradie dat
        // Priklad: cislo = 123 104 401 401 891 193 104 131
        // Poradie v data: 193 104 139, 401 401 891, 123 104
        private List<int> data = null;        

        private String stringValue = null;

        public static readonly int maxDataValue = 999999999;
        public static readonly int offset = 1000000000;
        public static readonly InfiniteInteger zero = new InfiniteInteger();
        public static readonly InfiniteInteger one = new InfiniteInteger(1);
        public static readonly InfiniteInteger negativeOne = new InfiniteInteger(-1);

        public InfiniteInteger()
        {
            data = new List<int>();
            data.Add(0);
        }

        public InfiniteInteger(int i)
        {
            if (i < offset)
            {
                SmallValue = i;                
            }
            else
                Initialize(i.ToString());
        }

        public InfiniteInteger(long l)
        {
            if (l < (long)offset)
            {
                SmallValue = (int)l;
            }
            else
                Initialize(l.ToString());
        }

        public InfiniteInteger(string numb)
        {
            Initialize(numb);

            //if (this.ToString() != numb) throw new Exception("Something's going wrong.");            
        }


        public InfiniteInteger(List<int> data)
        {
            this.data = data;
            if (data[0] == 0 && data.Count == 1) this.positive = true;            
        }

        public InfiniteInteger(List<int> data, bool positive)
        {
            this.data = data;
            this.positive = positive;
            if (data[0] == 0 && data.Count == 1) this.positive = true;
        }

        private void Initialize(string numb)
        {
            numb = Normalize(numb);
            this.positive = IsPositiveSign(numb);
            this.data = GetData(numb);
            if (this.data.Count == 0) this.data.Add(0);
            if (data[0] == 0 && data.Count == 1) this.positive = true;
        }

        private List<int> GetData(string numb)
        {
            List<int> retval = new List<int>(numb.Length / 9);
            int part;
            int tmpStart;
            int start, end;

            if (numb.StartsWith("-")) numb = numb.Substring(1);
            for (int i = numb.Length - 1; i >= 0; i -= 9)
            {
                tmpStart = i - 8;
                end = Math.Min(numb.Length - tmpStart, 9);
                start = Math.Max(0, tmpStart);
                end += (tmpStart - start);

                part = 0;
                int.TryParse(numb.Substring(start, end), out part);
                retval.Add(part);
            }
            return retval;
        }

        private bool IsPositiveSign(string numb)
        {
            if (numb.StartsWith("-")) return false;
            else return true;
        }

        private string Normalize(string number)
        {
            number.Trim();
            number.Replace(" ", "");

            int i = 0;
            while (i < number.Length - 1 && number[i] == '0')
            {
                i++;
            }
            number = number.Substring(i);

            return number;
        }

        public static InfiniteInteger operator *(InfiniteInteger n1, InfiniteInteger n2)
        {
            if (n1.data.Count == 1 && n2.data.Count == 1)
                return new InfiniteInteger((long)n1.SmallValue * n2.SmallValue);

            InfiniteInteger retval = GetUnsignedMult(n1, n2);

            retval.positive = (n1.positive && n2.positive) || (!n1.positive && !n2.positive);

            return retval;
        }

        public static InfiniteInteger operator /(InfiniteInteger n1, InfiniteInteger n2)
        {
            if (n1.data.Count == 1 && n2.data.Count == 1)
                return new InfiniteInteger(n1.SmallValue / n2.SmallValue);

            InfiniteInteger retval = GetUnsignedDiv(n1, n2);

            retval.positive = (n1.positive && n2.positive) || (!n1.positive && !n2.positive);

            return retval;
        }

        public static InfiniteInteger operator ++(InfiniteInteger n1)
        {
            if (n1.data[0] < maxDataValue)
            {
                InfiniteInteger newInt = new InfiniteInteger(new List<int>(n1.data), n1.positive);
                if (newInt.positive)
                    newInt.data[0]++;                    
                else
                {
                    newInt.data[0]--;                    
                }

                return newInt;
            }
            else
            {
                return n1 + InfiniteInteger.one;
            }
            
        }

        public static InfiniteInteger operator +(InfiniteInteger n1, InfiniteInteger n2)
        {
            if (n1.data.Count == 1 && n2.data.Count == 1)
                return new InfiniteInteger(n1.SmallValue + n2.SmallValue);

            if (n1.positive && n2.positive)
            {
                return GetUnsignedSum(n1, n2);
            }
            if (!n1.positive && !n2.positive)
            {
                InfiniteInteger retval;
                retval = GetUnsignedSum(n1, n2);
                retval.positive = false;
                return retval;
            }
            else
            {
                InfiniteInteger retval;
                retval = GetUnsignedDifference(n1, n2);

                if (n1.AbsoluteValue > n2.AbsoluteValue)
                    retval.positive = n1.positive;
                else
                    retval.positive = n2.positive;
                return retval;
            }
        }

        public static InfiniteInteger operator -(InfiniteInteger n1, InfiniteInteger n2)
        {
            if (n1.data.Count == 1 && n2.data.Count == 1)
                return new InfiniteInteger(n1.SmallValue - n2.SmallValue);

            if (n1.positive && n2.positive)
            {
                return GetUnsignedDifference(n1, n2);
            }
            if (!n1.positive && !n2.positive)
            {
                InfiniteInteger retval;
                retval = GetUnsignedDifference(n1, n2);
                retval.positive = !retval.positive;
                return retval;
            }
            else
            {
                InfiniteInteger retval;
                retval = GetUnsignedSum(n1, n2);
                retval.positive = n1.positive;
                return retval;
            }
        }

        public static bool operator ==(InfiniteInteger n1, InfiniteInteger n2)
        {
            if (n1.data.Count == 1 && n2.data.Count == 1)
                return n1.SmallValue == n2.SmallValue;

            if (n1.positive != n2.positive) return false;
            else if (n1.data.Count != n2.data.Count) return false;
            else
            {
                for (int i = 0; i < n1.data.Count; i++)
                {
                    if (n1.data[i] != n2.data[i]) return false;
                }
            }
            return true;
        }

        public static InfiniteInteger operator -(InfiniteInteger n1)
        {
            InfiniteInteger newInt = new InfiniteInteger(n1.data, !n1.positive);
            return newInt;
        }

        public static bool operator !=(InfiniteInteger n1, InfiniteInteger n2)
        {
            if (n1.data.Count == 1 && n2.data.Count == 1)
                return n1.SmallValue != n2.SmallValue;

            if (n1.positive != n2.positive) return true;
            else if (n1.data.Count != n2.data.Count) return true;
            else
            {
                for (int i = 0; i < n1.data.Count; i++)
                {
                    if (n1.data[i] != n2.data[i]) return true;
                }
            }
            return false;
        }

        public static bool operator >(InfiniteInteger n1, InfiniteInteger n2)
        {
            if (n1.data.Count == 1 && n2.data.Count == 1)
                return n1.SmallValue > n2.SmallValue;

            if (n1.positive && !n2.positive) return true;
            else if (!n1.positive && n2.positive) return false;
            else if (n1.data.Count > n2.data.Count) return true;
            else if (n2.data.Count > n1.data.Count) return false;
            else
            {
                for (int i = n1.data.Count - 1; i >= 0; i--)
                {
                    if (n1.data[i] < n2.data[i]) return false;
                    if (n1.data[i] > n2.data[i]) return true;
                }
            }
            return false;
        }

        public static bool operator <(InfiniteInteger n1, InfiniteInteger n2)
        {
            if (n1.data.Count == 1 && n2.data.Count == 1)
                return n1.SmallValue < n2.SmallValue;

            if (n1.positive && !n2.positive) return false;
            else if (!n1.positive && n2.positive) return true;
            else if (n1.data.Count < n2.data.Count) return true;
            else if (n2.data.Count < n1.data.Count) return false;
            else
            {
                for (int i = n1.data.Count - 1; i >= 0; i--)
                {
                    if (n1.data[i] > n2.data[i]) return false;
                    if (n1.data[i] < n2.data[i]) return true;
                }
            }
            return false;
        }

        public static bool operator <=(InfiniteInteger n1, InfiniteInteger n2)
        {
            if (n1.data.Count == 1 && n2.data.Count == 1)
                return n1.SmallValue <= n2.SmallValue;

            if (n1.positive && !n2.positive) return false;
            else if (!n1.positive && n2.positive) return true;
            else if (n1.data.Count < n2.data.Count) return true;
            else if (n2.data.Count < n1.data.Count) return false;
            else
            {
                for (int i = n1.data.Count - 1; i >= 0; i--)
                {
                    if (n1.data[i] > n2.data[i]) return false;
                    if (n1.data[i] < n2.data[i]) return true;
                }
            }
            return true;
        }

        public static bool operator >=(InfiniteInteger n1, InfiniteInteger n2)
        {
            if (n1.data.Count == 1 && n2.data.Count == 1)
                return n1.SmallValue >= n2.SmallValue;

            if (n1.positive && !n2.positive) return true;
            else if (!n1.positive && n2.positive) return false;
            else if (n1.data.Count > n2.data.Count) return true;
            else if (n2.data.Count > n1.data.Count) return false;
            else
            {
                for (int i = n1.data.Count - 1; i >= 0; i--)
                {
                    if (n1.data[i] < n2.data[i]) return false;
                    if (n1.data[i] > n2.data[i]) return true;
                }
            }
            return true;
        }

        public static InfiniteInteger GetUnsignedMult(InfiniteInteger n1, InfiniteInteger n2)
        {
            List<int> res = new List<int>(n1.data.Count + n2.data.Count);

            long sum;

            InfiniteInteger tmpSum = new InfiniteInteger(0);
            for (int i = 0; i < n1.data.Count; i++)
            {
                for (int j = 0; j < n2.data.Count; j++)
                {
                    sum = (long)n1.data[i] * n2.data[j];
                    tmpSum = tmpSum + new InfiniteInteger(sum).MultBy10((i + j) * 9);
                }
            }

            return tmpSum;
        }

        public static InfiniteInteger GetUnsignedDiv(InfiniteInteger n1, InfiniteInteger n2)
        {
            if (n1 < n2) return new InfiniteInteger();

            List<int> res = new List<int>(Math.Max(n1.data.Count, n2.data.Count));

            long sum;
            InfiniteInteger reminder = new InfiniteInteger();
            InfiniteInteger tmp = new InfiniteInteger();

            int n2length = n2.ToString().Length;
            string n1str = n1.ToString();
            int pos = 0;
            int c = 0;
            StringBuilder sb = new StringBuilder();

            reminder = new InfiniteInteger(n1str.Substring(0, n2length - 1));
            for (int i = n2length - 1; i < n1str.Length; i++)
            {
                tmp = new InfiniteInteger(reminder.ToString() + n1str.Substring(i, 1));

                c = 0;
                reminder = tmp;
                tmp = tmp - n2;
                while (tmp > InfiniteInteger.zero)
                {
                    reminder = tmp;
                    c++;
                    tmp = tmp - n2;
                }
                if (tmp == InfiniteInteger.zero)
                {
                    reminder = tmp;
                    c++;
                }


                sb.Append(c);
            }

            return new InfiniteInteger(sb.ToString());
        }

        public InfiniteInteger MultBy10()
        {                                    
            return new InfiniteInteger(GetData(this.ToString() + "0"));
        }

        public InfiniteInteger MultBy10(int exp)
        {
            StringBuilder sb = new StringBuilder(exp);
            sb.Append(this.ToString());
            sb.Append('0', exp);            
            return new InfiniteInteger(sb.ToString());            
        }

        public static InfiniteInteger GetUnsignedSum(InfiniteInteger n1, InfiniteInteger n2)
        {
            List<int> res = new List<int>(Math.Max(n1.data.Count, n2.data.Count));

            int i = 0;
            long sum = 0;
            int carry = 0;

            int dataCount1 = n1.data.Count;
            int dataCount2 = n2.data.Count;

            while (carry != 0 || i < dataCount1 || i < dataCount2)
            {
                sum = 0;
                if (i < n1.data.Count)
                    sum += n1.data[i];
                if (i < n2.data.Count)
                    sum += n2.data[i];
                sum += carry;

                if (sum > maxDataValue)
                {
                    carry = (int)(sum / offset);
                    sum = (int)(sum - offset);
                }
                else
                {
                    carry = 0;
                }

                res.Add((int)sum);
                i++;
            }
            return new InfiniteInteger(res);
        }

        public static InfiniteInteger GetUnsignedDifference(InfiniteInteger n1, InfiniteInteger n2)
        {
            bool swapped = false;
            if (n1.AbsoluteValue < n2.AbsoluteValue)
            {
                InfiniteInteger tmp = n1;
                n1 = n2;
                n2 = tmp;
                swapped = true;
            }

            List<int> res = new List<int>(Math.Max(n1.data.Count, n2.data.Count));


            int i = 0;
            int sum = 0;
            int carry = 0;

            int dataCount1 = n1.data.Count;
            int dataCount2 = n2.data.Count;

            while (carry != 0 || i < dataCount1 || i < dataCount2)
            {
                sum = 0;
                if (i <= n1.data.Count - 1)
                    sum += n1.data[i];

                if (i <= n2.data.Count - 1)
                    sum -= n2.data[i];

                sum += carry;

                if (sum < 0)
                {
                    sum = (offset + sum);
                    carry = -1;
                }
                else
                {
                    carry = 0;
                }

                res.Add((int)sum);
                i++;
            }

            return new InfiniteInteger(res, !swapped);
        }

        public override string ToString()
        {
            if (stringValue != null) return stringValue;

            StringBuilder sb = new StringBuilder(data.Count * 9);
            if (!positive) sb.Append("-");

            sb.Append(data[data.Count - 1].ToString());
            for (int i = data.Count - 2; i >= 0; i--)
            {
                sb.Append(data[i].ToString("D9"));
            }

            stringValue = sb.ToString();

            return stringValue;
        }

        public bool Positive
        {
            get { return positive; }
        }

        public bool Negative
        {
            get { return !positive; }
        }

        public InfiniteInteger AbsoluteValue
        {
            get
            {
                return new InfiniteInteger(this.data, true);
            }
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is InfiniteInteger)) return false;

            return (this == (InfiniteInteger)obj);
        }

        public long ToLong()
        {
            return Functions.ToValue(this.ToString());
        }


        public int ToInt()
        {
            return Functions.ToValue(this.ToString());
        }


        public int SmallValue
        {
            get 
            { 
                if (positive)
                    return data[0]; 
                else
                    return -data[0]; 
            }
            set 
            {                
                if (value < 0)
                {
                    if (data == null) data = new List<int>(1) { -value};
                    else data[0] = -value;
                    positive = false;
                }
                else
                {
                    if (data == null) data = new List<int>(1) { value };
                    else data[0] = value;
                    positive = true;
                }
                if (data.Count > 1) data.RemoveRange(1, data.Count - 1);
            }
        }
    }
    

}
