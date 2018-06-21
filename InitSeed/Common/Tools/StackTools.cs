using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DDTek.Oracle;
using System.IO;

using InitSeed.Common.Tools;



//Stack堆栈,后进先出,但通用数据类型object，装箱、拆箱性能下降
//Stack<char> st = new Stack<char>(); 
//  st.Push('A');
//  st.Push('B'); 
//char[] rs = st.ToArray<char>();


namespace InitSeed.Common.Tools
{
    public static class StackTools 
    {
        /// <summary>
        /// 十进制转换为其他进制
        /// </summary>
        /// <param name="number">要转换数字</param>
        /// <param name="target">目标进制</param>
        /// <returns></returns>
        public static string Jinzhi2Jinzhi(int number, int target)
        {
            string result = string.Empty;
            string format = "0123456789ABCDEF";
            MyStack<int> stack = new MyStack<int>(30);
            int mod = 0;
            while (number != 0)
            {
                mod = number % target;
                stack.Push(mod);
                number = number / target;
            }
            while (!stack.IsEmpty())
            {
                int pos = stack.Pop();
                result += format[pos];
            }
            return result;
        }

        /// <summary>
        /// 检查字符串中括号是否成对匹配
        /// bool check = Check("[[([)]]]"); 
        /// </summary>
        /// <param name="charter">待检查的字符串</param>
        /// <returns></returns>
        public static bool Check(string charter)
        {
            bool result = false;
            MyStack<char> stack = new MyStack<char>(30);
            MyStack<char> needStack = new MyStack<char>(30);
            char currentNeed = '0';
            for (int i = 0; i < charter.Length; i++)
            {
                if (charter[i] != currentNeed)
                {
                    char t = charter[i];
                    stack.Push(t);
                    switch (t)
                    {
                        case '[':
                            if (currentNeed != '0')
                            {
                                needStack.Push(currentNeed);
                            }
                            currentNeed = ']';
                            break;
                        case '(':
                            if (currentNeed != '0')
                            {
                                needStack.Push(currentNeed);
                            }
                            currentNeed = ')';
                            break;
                        case '{':
                            if (currentNeed != '0')
                            {
                                needStack.Push(currentNeed);
                            }
                            currentNeed = '}';
                            break;
                    }
                }
                else
                {
                    stack.Pop();
                    currentNeed = needStack.Pop();
                }
            }
            if (stack.IsEmpty())
            {
                result = true;
            }
            return result;
        }
    }

    public class MyStack<T> : IEnumerable<T>, IDisposable
    {
        private int _top = 0;
        private int _size = 0;
        private T[] _stack = null;

        public int Top
        {
            get
            {
                return _top;
            }
        }

        public int Size
        {
            get
            {
                return _size;
            }
        }

        public int Length
        {
            get
            {
                return _top;
            }
        }

        public T this[int index]
        {
            get
            {
                return _stack[index];
            }
        }

        public MyStack(int size)
        {
            _size = size;
            _top = 0;
            _stack = new T[size];
        }

        public bool IsEmpty()
        {
            return _top == 0;
        }

        public bool IsFull()
        {
            return _top == _size;
        }

        public void Clear()
        {
            _top = 0;
        }

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool Push(T node)
        {
            if (!IsFull())
            {
                _stack[_top] = node;
                _top++;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T node = default(T);
            if (!IsEmpty())
            {
                _top--;
                node = _stack[_top];
            }
            return node;
        }

        public void Traverse()
        {
            for (int i = 0; i < _top; i++)
            {
                Console.WriteLine(_stack[i]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _stack.Length; i++)
            {
                if (_stack[i] != null)
                {
                    yield return _stack[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            _stack = null;
        }
    }

}

