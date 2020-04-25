﻿using System;
using System.Text;

namespace ComplexAndVector {
    class Vector<T> :IEquatable<Vector<T>> , ICloneable, IComparable<Vector<T>>, IComparable where T: new () {
        T[] _valuesArray;

        public Vector() { }
        public Vector(T[] array) {
            _valuesArray = array;
        }

        public Vector(int size) {
            T[] a = new T[size];
            for(int i = 0; i < size; i++) {
                a[i] = (dynamic)0;
            }
            _valuesArray = a;
        }

        public int Size => _valuesArray.Length;

        public static implicit operator Vector<T>(T[] numArray) => new Vector<T>(numArray);
        public static implicit operator T[](Vector<T> numArray) => (T[])numArray._valuesArray.Clone() ;


        private static bool CheckSize(Vector<T> v1, Vector<T> v2) {
            return v1.Size== v2.Size;
        }

        public T this[int i] {
            get { return _valuesArray[i]; }
            set { _valuesArray[i] = value; }
        }

        
        //todo возвращать для комплексного квадрат суммы модулей
        public T Module() {
            T res = new T();
            if (this[0] is Complex) {
                for (int i = 0; i < this.Size; i++) {
                    res += (dynamic)Complex.Pow((dynamic)this[i], 2);                    
                }

            }
            else {
                for (int i = 0; i < this.Size; i++) {
                    res += (dynamic)this[i] * (dynamic)this[i];
                }
            }
            return Math.Sqrt((dynamic)res);
        }

        public static T ScalarMultiply(Vector<T> left,Vector<T> right) {
            if (!CheckSize(left, right))
                throw new ArgumentException("Incorrect size of vectors");
            T sum = (dynamic)0;
            for(int i = 0; i < left.Size; i++) {
                sum += (dynamic)left[i] * right[i];
            }
            return sum;
        }

        public static Vector<T> Add(Vector<T> left, T right) {
            Vector<T> result = new Vector<T>(left.Size);
            for(int i = 0; i < left.Size; i++) {
                result[i] = (dynamic)left[i] + right;
            }
            return result;
        }

        public static Vector<T> Add(Vector<T> left, Vector<T> right) {
            if (!CheckSize(left, right))
                throw new ArgumentException("Different size of vectors!");
            Vector<T> result = new Vector<T>(left.Size);
            for (int i = 0; i < left.Size; i++)
                result[i] = (dynamic)right[i] + left[i];

            return result;  
        }

        public static Vector<T> Subtract(Vector<T> left, Vector<T> right) {
            if (!CheckSize(left, right))
                throw new ArgumentException("Different size if vectors!");
            Vector<T> result = new Vector<T>(left.Size);
            for (int i = 0; i < left.Size; i++)
                result[i] = (dynamic)left[i] - right[i];
            return result;
        }

        public static Vector<T> Multiply(Vector<T> left, T right) {
            Vector<T> result = new Vector<T>(left.Size);
            for (int i = 0; i < left.Size; i++) {
                result[i] = (dynamic)left[i] * right;
            }
            return result;
        }


        public static Vector<T> operator +(Vector<T> left, T right) {
            return Add(left, right);
        }

        public static Vector<T> operator +(Vector<T> left, Vector<T> right) {
            return Add(left, right);
        }
        public static Vector<T> operator -(Vector<T> left, Vector<T> right) {
            return Subtract(left, right);
        }

        public static Vector<T> operator *(Vector<T> left, T right) {
            return Multiply(left, right);
        }

        public static Vector<T> operator *(T left, Vector<T> right){
            return Multiply(right, left);

        }
        

        public static Vector<T>[] Orthogonolization(Vector<T>[] vectorsArray) {
            Vector<T>[] result = new Vector<T>[vectorsArray.Length];
            result[0] = new Vector<T>(vectorsArray[0]._valuesArray);            
            for (int i = 1; i < vectorsArray.Length; i++) {
                result[i] = (Vector<T>)vectorsArray[i].Clone();
                for (int j = 0; j < i; j++) {   
                    result[i] -= (dynamic)ScalarMultiply(vectorsArray[i], result[j]) /
                              ScalarMultiply(result[j], result[j]) * result[j];
                }               
            }
            return result;
        }


        public override string ToString() {
            StringBuilder result = new StringBuilder();
            
            result.Append("(");
            for (int i = 0; i < Size; i++) {
                if (i == Size - 1) {                 
                    result.Append((dynamic)this[i]);    
                }
                else {                  
                    result.Append((dynamic)this[i]).Append(",");
                }             
            }
            result.Append(")");
            return result.ToString();
        }

        public object Clone() {
            return new Vector<T>(_valuesArray);
        }

        public int CompareTo(Vector<T> A) {
            if (A[0] is Complex) {
                return (dynamic)A.Module() == this.Module();
            }
            else {
                return ((double)(dynamic)Module()).CompareTo(A.Module());
            }
        }

        int IComparable.CompareTo(object obj) {
            if (obj is null) {
                throw new ArgumentNullException("NULL", nameof(obj));
            }
            if (!(obj is Vector<T>)) {
                throw new ArgumentException("Это не вектор", nameof(obj));
            }
            return CompareTo((Vector<T>)obj);
        }

        public bool Equals( Vector<T> other) {
            if(!CheckSize(this, other)) {
                return false;
            }
            for(int i = 0; i < Size; i++) {
                if ((dynamic)this[i] != other[i])
                    return false;
            }
            return true;
        }
    }

    
}
