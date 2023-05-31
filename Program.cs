using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;

CheckSameResult();

void CheckSameResult()
{
    string val = MyEnum.EnumValue.ToString();
    Console.WriteLine("ToString: " + val);
    Console.WriteLine($"String interpolation: {MyEnum.EnumValue}");
    Console.WriteLine($"Nameof: {nameof(MyEnum.EnumValue)}");
    Console.WriteLine($"ToString: {Enum.GetName(MyEnum.EnumValue)}");
}

Console.WriteLine($"Press key to start");

Console.ReadKey();
BenchmarkDotNet.Reports.Summary summary = BenchmarkRunner.Run<EnumAsStringBenchmark>();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Benchmark ended!. Press any key to close");
Console.ResetColor();
Console.ReadKey();

enum MyEnum
{
    EnumValue
}

[RankColumn]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MemoryDiagnoser]
public class EnumAsStringBenchmark
{
    private const int Iterations = 10000;
    private string? Value { get; set; } = string.Empty;

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
    public void UsingStringInterpolation()
    {
        for (int i = 0; i < Iterations; i++)
        {
            string value = $"{MyEnum.EnumValue}";
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
    public void UsingEnumGetName()
    {
        for (int i = 0; i < Iterations; i++)
        {
            string? value = Enum.GetName(MyEnum.EnumValue);
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
    public void UsingStringInterpolationDiffers()
    {
        for (int i = 0; i < Iterations; i++)
        {
            string value = $"{MyEnum.EnumValue}";
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

    [Benchmark]
    public void UsingEnumGetNameDiffers()
    {
        for (int i = 0; i < Iterations; i++)
        {
            string? value = Enum.GetName(MyEnum.EnumValue);
            Value = value;
        }
    }
}