using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NumbersForIdle
{
    public struct IdleNumber
    {
        public float Value;
        public int Degree;

        private const int _tenCubed = 1000;
        
        public IdleNumber(float value, int degree)
        {
            Value = value;
            Degree = degree;

            NormalizedNumber();
        }

        public IdleNumber(float value)
        {
            Value = value;
            Degree = 0;

            NormalizedNumber();
        }

        private void NormalizedNumber()
        {
            while(Mathf.Abs(Value) >= _tenCubed)
            {
                Value /= _tenCubed;
                Degree += 3;
            }
        }

        public static IdleNumber operator+(IdleNumber leftNumber, IdleNumber rightNumber)
        {

            if(leftNumber.Degree >= rightNumber.Degree)
            {
                int difference = leftNumber.Degree - rightNumber.Degree;
                float resultValue = leftNumber.Value + rightNumber.Value / Mathf.Pow(10, difference);

                return new IdleNumber(resultValue, leftNumber.Degree);
            }
            else
            {
                int difference = rightNumber.Degree - leftNumber.Degree;
                float resultValue = rightNumber.Value + leftNumber.Value / Mathf.Pow(10, difference);

                return new IdleNumber(resultValue, rightNumber.Degree);
            }
        }

        public static IdleNumber operator+(IdleNumber idleNumber, float f)
        {
            float resultValue = idleNumber.Value + f/ Mathf.Pow(10, idleNumber.Degree);

            return new IdleNumber(resultValue , idleNumber.Degree);
        }

        public static IdleNumber operator+(IdleNumber idleNumber, int i)
        {
            float resultValue = idleNumber.Value + i / Mathf.Pow(10, idleNumber.Degree);

            return new IdleNumber(resultValue, idleNumber.Degree);
        }

        public static IdleNumber operator-(IdleNumber leftNumber, IdleNumber rightNumber)
        {
            int difference = leftNumber.Degree - rightNumber.Degree;
            float resultValue = leftNumber.Value - rightNumber.Value / Mathf.Pow(10, difference);

            return new IdleNumber(resultValue, leftNumber.Degree);
        }

        public static IdleNumber operator-(IdleNumber idleNumber, float f)
        {
            float resultValue = idleNumber.Value - f / Mathf.Pow(10, idleNumber.Degree);

            return new IdleNumber(resultValue, idleNumber.Degree);
        }

        public static IdleNumber operator*(IdleNumber leftNumber, IdleNumber rightNumber)
        {
            float resultValue = leftNumber.Value * rightNumber.Value;
            int resultDegree = leftNumber.Degree + rightNumber.Degree;

            return new IdleNumber(resultValue, resultDegree);
        }

        public static IdleNumber operator*(IdleNumber idle, float f)
        {
            return new IdleNumber(idle.Value * f, idle.Degree);
        }

        public static IdleNumber operator/(IdleNumber dividend, IdleNumber divider)
        {
            float resultValue = dividend.Value / divider.Value;
            int resultDegree = dividend.Degree - divider.Degree;

            return new IdleNumber(resultValue, resultDegree);
        }

        public static bool operator >(IdleNumber leftNumber, IdleNumber rightNumber)
        {
            if(leftNumber.Degree >= rightNumber.Degree)
            {
                if(leftNumber.Degree == rightNumber.Degree)
                {
                    return leftNumber.Value > rightNumber.Value;
                }

                return true;
            }

            return false;
        }

        public static bool operator >(IdleNumber leftNumber, float f)
        {
            IdleNumber rightNumber = new(f);

            return leftNumber > rightNumber;
        }

        public static bool operator <(IdleNumber leftNumber, IdleNumber rightNumber)
        {
            if (leftNumber.Degree <= rightNumber.Degree)
            {
                if (leftNumber.Degree == rightNumber.Degree)
                {
                    return leftNumber.Value < rightNumber.Value;
                }

                return true;
            }

            return false;
        }

        public static bool operator <(IdleNumber leftNumber, float f)
        {
            IdleNumber rightNumber = new(f);

            return leftNumber < rightNumber;
        }

        public static bool operator >=(IdleNumber leftNumber, IdleNumber rightNumber)
        {
            return !(leftNumber < rightNumber);
        }

        public static bool operator >=(IdleNumber leftNumber, float f)
        {
            IdleNumber rightNumber = new(f);

            return leftNumber >= rightNumber;
        }

        public static bool operator <=(IdleNumber leftNumber, IdleNumber rightNumber)
        {
            return !(leftNumber > rightNumber);
        }

        public static bool operator <=(IdleNumber leftNumber, float f)
        {
            IdleNumber rightNumber = new(f);

            return leftNumber <= rightNumber;
        }

        public static bool operator ==(IdleNumber leftNumber, IdleNumber rightNumber)
        {
            return leftNumber.Degree == rightNumber.Degree && leftNumber.Value == rightNumber.Value;
        }

        public static bool operator ==(IdleNumber leftNumber, float f)
        {
            IdleNumber rightNumber = new(f);

            return leftNumber == rightNumber;
        }

        public static bool operator !=(IdleNumber leftNumber, IdleNumber rightNumber)
        {
            return !(leftNumber == rightNumber);
        }


    }
}


