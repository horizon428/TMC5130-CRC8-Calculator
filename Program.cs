using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("开始运行CRC8计算测试...\n");

        var tests = new CRC8Tests();
        RunTest("测试实际通信数据", () => tests.TestRealCommunicationData());
        RunTest("测试一致性", () => tests.TestConsistency());

        Console.WriteLine("\n按任意键退出...");
        Console.ReadKey();
    }

    static void RunTest(string testName, Action testAction)
    {
        Console.WriteLine($"运行测试: {testName}");
        try
        {
            testAction();
            Console.WriteLine($"✓ {testName} 测试通过\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ {testName} 测试失败");
            Console.WriteLine($"错误信息: {ex.Message}\n");
        }
    }
}
