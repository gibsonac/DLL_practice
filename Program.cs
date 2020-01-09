using System;

namespace dll_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DoublyLinkedList aList = new DoublyLinkedList();
            aList.Add(0);
            aList.Add(1);
            aList.Add(2);
            aList.Add(3);
            aList.Add(4);
            aList.Add(5);
            aList.Add(6);
            aList.Add(7);
            aList.Add(8);
            aList.Add(9);
            aList.Add(10);
            aList.PrintValues();
            aList.Remove(2);
            aList.PrintValues();
            aList.Reverse();
            aList.PrintValues();
        }
    }

    public class DLLNode
    {
        public int Value;
        public DLLNode Next;
        public DLLNode Prev;
        public DLLNode(int val)
        {
            Value = val;
            Next = null;
            Prev = null;
        }
    }
    public class DoublyLinkedList
    {
        public DLLNode Head;
        public DoublyLinkedList()
        {
            Head = null;
        }
        public void PrintValues()
        {
            if (Head == null)
            {
                Console.WriteLine("there isn't a list!");
            }
            else
            {
                DLLNode runner = Head;
                while (runner.Next != null)
                {
                    Console.WriteLine(runner.Value);
                    runner = runner.Next;
                }
                Console.WriteLine(runner.Value);
            }
        }
        public void Add(int value)
        {
            DLLNode newNode = new DLLNode(value);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                DLLNode runner = Head;
                while (runner.Next != null)
                {
                    runner = runner.Next;
                }
                runner.Next = newNode;
                newNode.Prev = runner;
            }
        }
        public void Remove(int value)
        {
            if (Head == null)
            {
                Console.WriteLine("there aren't any nodes in the list!");
            }
            else
            {
                if (Head.Value == value)
                {
                    if (Head.Next == null)
                    {
                        Head = null;
                    }
                    else
                    {
                        Head = Head.Next;
                        Head.Prev = null;
                    }
                }
                else
                {
                    DLLNode runner = Head;
                    while (runner.Next.Next != null)
                    {
                        if (runner.Next.Value == value)
                        {
                            runner.Next = runner.Next.Next;
                            runner.Next.Next.Prev = runner;
                            break;
                        }
                        runner = runner.Next;
                    }
                }
            }
        }
        public void Reverse()
        {
            if (Head == null)
            {
                Console.WriteLine("there aren't any nodes in the list!");
            }
            else
            {
                DLLNode runner = Head;
                while (runner.Next != null)
                {
                    runner = runner.Next;
                }
                DLLNode start = runner;
                runner.Next = runner.Prev;
                runner.Prev = null;
                while (runner.Next != Head)
                {
                    DLLNode temp = runner.Next;
                    temp.Next = temp.Prev;
                    temp.Prev = runner;
                    runner = temp;
                }
                Head.Prev = runner;
                Head.Next = null;
                Head = start;
            }
        }
    }
}
