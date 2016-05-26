using System;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApplication1
{
    class Program
    {
        private delegate long TaskDelegate(int s,long end);
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;

            TaskDelegate task = Factorial;
            IAsyncResult asyncResult = task.BeginInvoke(2, 200000000,asycnCollback,task);
            long s = 0;
            //s=Factorial(2, 200000000);
            //while (!asyncResult.AsyncWaitHandle.WaitOne(1,false))
            //{
            //    Console.WriteLine(s);
            //}
            //long result = task.EndInvoke(asyncResult);
            ThreadStart threadStart = new ThreadStart(ssss);
            Thread thread = new Thread(threadStart);
            thread.Start();
            while (thread.ThreadState != ThreadState.Stopped)
            {
                Console.WriteLine("……");
            }
            Console.WriteLine(s);
            Console.WriteLine((DateTime.Now - dt));
            Console.Read();

        }
        /// <summary>
        /// 计算&#D;阶乘
        /// </summary>
        /// <param name="start">起始</param>
        /// <param name="end">结束</param>
        /// <returns></returns>
        static long Factorial(int start, long end)
        {
            long result = 1;
            for (long i = end; i >= start; i--)
            {
                result = result * i;
            }
            return 10;
        }
        static  void asycnCollback(IAsyncResult Asyncresult)
        {

            if (Asyncresult == null || Asyncresult.AsyncState == null)
            {
                Console.WriteLine("failed");
                return;
            }
            long result = (Asyncresult.AsyncState as TaskDelegate).EndInvoke(Asyncresult);
            Console.WriteLine("任务完成，结果：" + result);
        }
        static void ssss()
        {
            Console.WriteLine("failed");
        }
    }
}
