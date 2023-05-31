using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;

BenchmarkDotNet.Reports.Summary summary = BenchmarkRunner.Run<EnumAsStringBenchmark>();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Benchmark ended!. Press any key to close");
Console.ResetColor();
Console.ReadKey();

[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
public class EnumAsStringBenchmark
{
    private const int Iterations = 10000;
    private string Value { get; set; } = string.Empty;

    private enum MyEnum
    {
        EnumValue
    }

    [Benchmark]
    public void UsingToString()
    {
        for (int i = 0; i < Iterations; i++)
        {
            string value = MyEnum.EnumValue.ToString();
            Value = value;
        }
    }

    [Benchmark]
    public void UsingNameOf()
    {
        for (int i = 0; i < Iterations; i++)
        {
            string value = nameof(MyEnum.EnumValue);
            Value = value;
        }
    }
    [Benchmark]
    public void UsingToStringDiffers()
    {
        for (int i = 0; i < Iterations; i++)
        {
            string value = MyEnum.EnumValue.ToString();
            Value = value;
        }
    }

    [Benchmark]
    public void UsingNameOfDiffers()
    {
        for (int i = 0; i < Iterations; i++)
        {
            string value = nameof(MyEnum.EnumValue);
            Value = value;
        }
    }
}